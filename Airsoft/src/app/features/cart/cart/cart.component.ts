import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CartViewModel } from 'src/app/models/cart/cartViewModel';
import { CartService } from 'src/app/services/cart/cart.service';
import { DataService } from 'src/app/services/data/data.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  isLoaded: boolean = false;
  isLoading: boolean = true;
  private price: number = 0;

  get totalPrice(): number{
    return this.dataService.cartItemsPrice;
  }
  set totalPrice(value) {
    this.dataService.cartItemsPrice = value;
  }

  get items(): CartViewModel[] {
    return this.dataService.cartItems;
  }
  set items(value) {
    this.dataService.cartItems = value;
  }

  get itemsCount(): number {
    return this.dataService.cartItemsCount;
  }
  set itemsCount(value) {
    this.dataService.cartItemsCount = value;
  }

  constructor(private cartService: CartService, private toastr: ToastrService, private dataService: DataService) { 
  }
  
  ngOnInit(): void {
    this.loadCartItems();
  }

  loadCartItems(): void{
    this.cartService.GetItems()
      .subscribe(res => {
        this.items = res;
        this.isLoaded = true;
        this.isLoading = false;
      });
  }

  onItemRemove(itemId: number, itemPrice:number, event:Event): void {
    event.preventDefault();
    this.isLoaded = false;
    this.isLoading = true;
    
    this.cartService.RemoveItem(itemId)
      .subscribe({
        next: (res: any) => {
          this.items.map((model, index) => {
            if (model.id == itemId) {
              this.items.splice(index, 1);
            }
          });

          this.price = (+this.totalPrice) - (+itemPrice);
          this.totalPrice = this.price;
          this.itemsCount = this.items.length;
          this.isLoaded = true;
          this.isLoading = false;
          this.toastr.success(res.message);
        },
        error: (err) => {
          this.isLoaded = true;
          this.isLoading = false;
          this.toastr.error(err.error.errorMessage);
        }
    })
  }
}
