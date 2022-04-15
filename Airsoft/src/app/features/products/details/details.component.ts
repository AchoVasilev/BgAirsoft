import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
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
  gun: GunDetailsViewModel;
  isLoading: boolean = true;
  isLoaded: boolean = false;
  isLoggedIn: boolean;
  isClient: boolean;
  private itemsCount: number = 0;
  private price: number = 0;

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
    private dataService: DataService
  ) { }

  ngOnInit(): void {
    this.getGunDetails();
    this.isLoggedIn = this.userService.isAuthenticated();

    this.isLoading = false;
    this.isLoaded = true;
  }

  getGunDetails() {
    const gunId = this.route.snapshot.params['id'];
    this.productService.getGunDetails(gunId)
      .subscribe(res => this.gun = res);
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
}
