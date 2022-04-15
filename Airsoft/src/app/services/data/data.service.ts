import { Injectable } from '@angular/core';
import { CartViewModel } from 'src/app/models/cart/cartViewModel';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { GunDetailsViewModel } from 'src/app/models/products/guns/gunDetailsViewModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  cartItemsCount: number = 0;
  cartItemsPrice: number = 0;
  finalPrice: number;
  userData: UserClientViewModel;
  cartItems: CartViewModel[];
  gun: GunDetailsViewModel;
  courierId: number;
  courierName: string;
  courierDeliveryPrice: number;
  paymentType: string;

  constructor() { }
}
