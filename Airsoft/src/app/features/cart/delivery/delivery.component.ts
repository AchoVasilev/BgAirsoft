import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartDeliveryViewModel } from 'src/app/models/cart/cartDeliveryViewModel';
import { CartService } from 'src/app/services/cart/cart.service';
import { DataService } from 'src/app/services/data/data.service';

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrls: ['./delivery.component.css']
})
export class DeliveryComponent implements OnInit {
  deliveryData: CartDeliveryViewModel;
  isLoaded: boolean = false;
  isLoading: boolean = true;
  deliveryPrice: number = 0;
  finalPrice: number = 0;

  @ViewChildren('firms')
  couriers: QueryList<any>;

  @ViewChild('cash')
  cash: ElementRef;

  @ViewChild('card')
  card: ElementRef;

  get itemsPrice(): number {
    return this.dataService.cartItemsPrice;
  }

  get courierId(): number{
    return this.dataService.courierId;
  }
  set courierId(value){
    this.dataService.courierId = value;
  }

  get courierPrice(): number {
    return this.dataService.courierDeliveryPrice;
  }
  set courierPrice(value) {
    this.dataService.courierDeliveryPrice = value;
  }

  get courierName(): string {
    return this.dataService.courierName;
  }
  set courierName(value) {
    this.dataService.courierName = value;
  }

  get paymentType(): string{
    return this.dataService.paymentType;
  }
  set paymentType(value) {
    this.dataService.paymentType = value;
  }

  get totalPrice(): number {
    return this.dataService.finalPrice;
  }
  set totalPrice(value) {
    this.dataService.finalPrice = value;
  }

  constructor(private cartService: CartService, private dataService: DataService, private router: Router) { }

  ngOnInit(): void {
    this.getDeliveryData();
    this.isLoaded = true;
    this.isLoading = false;
  }

  getDeliveryData(): void {
    this.cartService.GetCartDeliveryData()
      .subscribe(data => this.deliveryData = data);
  }

  radioBtnClick(event: any) {
    if (event.target.id == this.card.nativeElement.id) {
      this.card.nativeElement.checked = true;
      this.cash.nativeElement.checked = false;
    } else if (event.target.id == this.cash.nativeElement.id) {
      this.cash.nativeElement.checked = true;
      this.card.nativeElement.checked = false;
    }

    this.paymentType = event.target.id;
  }

  courierBtnClick(event: any, courierId: number, courierName: string) {
    this.couriers.toArray().forEach(courier => {
      courier.nativeElement.classList.remove('selected');
    });

    this.finalPrice = this.itemsPrice;
    event.currentTarget.classList.add('selected');
    for (const courier of this.deliveryData.couriers) {
      if (event.currentTarget.id == courier.name && this.itemsPrice < 500) {
        this.deliveryPrice = courier.deliveryPrice;
      }
    }

    this.courierId = courierId;
    this.courierName = courierName;
    this.courierPrice = this.deliveryPrice;
    this.finalPrice = (+this.finalPrice) + (+this.deliveryPrice);
    this.totalPrice = this.finalPrice;
  }

  summaryBtnClick() {
    this.router.navigate(['/cart/summary']);
  }
}
