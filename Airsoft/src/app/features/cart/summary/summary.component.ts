import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartViewModel } from 'src/app/models/cart/cartViewModel';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { OrderInputModel } from 'src/app/models/orders/orderInputModel';
import { DataService } from 'src/app/services/data/data.service';
import { OrderService } from 'src/app/services/orderService/order.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {
  orderData: OrderInputModel;

  get courierId() : number {
    return this.dataService.courierId;
  }

  get courierName(): string{
    return this.dataService.courierName;
  }
  
  get deliveryPrice(): number{
    return this.dataService.courierDeliveryPrice
  }

  get userData(): UserClientViewModel{
    return this.dataService.userData;
  }

  get cartItems(): CartViewModel[]{
    return this.dataService.cartItems;
  }

  get paymentType(): string{
    return this.dataService.paymentType;
  }

  get finalPrice(): number {
    return this.dataService.finalPrice;
  }

  get cartItemsCount(): number{
    return this.dataService.cartItemsCount;
  }
  set cartItemsCount(value) {
    this.dataService.cartItemsCount = value;
  }

  get cartItemsPrice(): number {
    return this.dataService.cartItemsPrice;
  }
  set cartItemsPrice(value) {
    this.dataService.cartItemsPrice = value;
  }


  constructor(private dataService: DataService, private orderService: OrderService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
  }

  sendOrder() {
    const gunsIds: number[] = [];
    this.cartItems.forEach(el => {
      gunsIds.push(el.id);
    });

    this.orderData = {
      totalPrice: this.finalPrice,
      paymentType: this.paymentType,
      courierId: this.courierId,
      gunsIds
    };

    this.orderService.createOrder(this.orderData)
      .subscribe({
        next: (res: any) => {
          this.toastr.success(res.message);
          this.cartItemsCount = 0;
          this.cartItemsPrice = 0;
          this.router.navigate(['/orders/client']);
        },
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.errorMessage);
          }

          console.log(err);
        }
    })
  }
}
