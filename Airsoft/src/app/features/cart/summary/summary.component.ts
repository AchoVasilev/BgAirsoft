import { Component, OnInit } from '@angular/core';
import { CartViewModel } from 'src/app/models/cart/cartViewModel';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { DataService } from 'src/app/services/data/data.service';

@Component({
  selector: 'app-summary',
  templateUrl: './summary.component.html',
  styleUrls: ['./summary.component.css']
})
export class SummaryComponent implements OnInit {
  
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

  constructor(private dataService: DataService) { }

  ngOnInit(): void {
  }

}
