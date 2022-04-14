import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddToCartResultModel } from 'src/app/models/cart/addToCartResultModel';
import { CartDeliveryViewModel } from 'src/app/models/cart/cartDeliveryViewModel';
import { CartViewModel } from 'src/app/models/cart/cartViewModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpClient: HttpClient) { }

  AddItem(gunId: number): Observable<AddToCartResultModel> {
    return this.httpClient.post<AddToCartResultModel>(`${environment.apiUrl}/cart/add`, gunId);
  }

  GetItems(): Observable<CartViewModel[]> {
    return this.httpClient.get<CartViewModel[]>(`${environment.apiUrl}/cart/get`);
  }

  GetItemsCountAndPrice(): Observable<any> {
    return this.httpClient.get<any>(`${environment.apiUrl}/cart/getProductCountAndPrice`);
  }

  RemoveItem(itemId: number) : Observable<Object> {
    return this.httpClient.delete(`${environment.apiUrl}/cart/delete`, {
      params: { itemId }
    });
  }

  GetCartDeliveryData(): Observable<CartDeliveryViewModel>{
    return this.httpClient.get<CartDeliveryViewModel>(`${environment.apiUrl}/cart/deliveryData`);
  }
}
