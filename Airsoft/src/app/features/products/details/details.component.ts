import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DealerIdObj } from 'src/app/models/dealer/dealerIdObj';
import { GunDetailsViewModel } from 'src/app/models/products/guns/gunDetailsViewModel';
import { CartService } from 'src/app/services/cart/cart.service';
import { DataService } from 'src/app/services/data/data.service';
import { ProductService } from 'src/app/services/product/product.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  isLoading: boolean = true;
  isLoaded: boolean = false;
  isLoggedIn: boolean;
  isClient: boolean;
  isOwner: boolean;
  dealerObj: DealerIdObj;
  private itemsCount: number = 0;
  private price: number = 0;
  private gunId = this.route.snapshot.params['id'];

  get gun(): GunDetailsViewModel {
    return this.dataService.gun;
  }
  set gun(value) {
    this.dataService.gun = value;
  }

  get cartItemsCount(): number {
    return this.dataService.cartItemsCount
  }
  set cartItemsCount(value: number) {
    this.dataService.cartItemsCount = value;
  }

  get cartItemsPrice(): number {
    return this.dataService.cartItemsPrice;
  }
  set cartItemsPrice(value: number) {
    this.dataService.cartItemsPrice = value;
  }

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    private userService: UserService,
    private cartService: CartService,
    private toastr: ToastrService,
    private dataService: DataService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getGunDetails();
    this.getDealerId();
    this.isLoggedIn = this.userService.isAuthenticated();
    this.isClient = this.userService.isClient();

    this.isOwner = this.isLoggedIn && this.dealerObj?.dealerId == this.gun?.dealerId
    this.isLoading = false;
    this.isLoaded = true;
  }

  getGunDetails() {
    this.productService.getGunDetails(this.gunId)
      .subscribe(res => this.gun = res);
  }

  getDealerId(): void {
    this.userService.getDealerId()
      .subscribe(res => {
        this.dealerObj = res;
      });
  }

  addToBasket(gunId: number, price: number) {
    this.isLoading = true;
    this.isLoaded = false;

    this.cartService.AddItem(gunId)
      .subscribe({
        next: (result) => {
          this.toastr.success("Успешно добавяне!");
          this.itemsCount = this.cartItemsCount + 1;
          this.cartItemsCount = this.itemsCount;

          this.price = +price;
          this.price = (+this.cartItemsPrice) + (+this.price);
          this.cartItemsPrice = this.price;
        },
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.ErrorMessage);
          }
        },
        complete: () => {
          this.isLoading = false;
          this.isLoaded = true;
        }
      })
  }

  onDelete(gunId: number) {
    this.isLoading = true;
    this.isLoaded = false;
    this.productService.deleteGun(gunId)
      .subscribe({
        next: () => {
          this.toastr.success("Успешно изтриване");
          this.isLoading = false;
          this.isLoaded = true;

          this.router.navigate(['/products/mine']);
        },
        error: () => {
          this.toastr.error("Нещо се обърка");
          this.isLoading = false;
          this.isLoaded = true;
        }
    })
  }
}
