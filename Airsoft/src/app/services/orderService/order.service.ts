import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderDetailsModel } from 'src/app/models/orders/orderDetailsModel';
import { OrderInputModel } from 'src/app/models/orders/orderInputModel';
import { OrderListModel } from 'src/app/models/orders/orderListModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient: HttpClient) { }

  createOrder(data: OrderInputModel): Observable<number> {
    return this.httpClient.post<number>(`${environment.apiUrl}/order/create`, data);
  }

  getClientOrders(): Observable<OrderListModel[]> {
    return this.httpClient.get<OrderListModel[]>(`${environment.apiUrl}/order/clientOrders`);
  }

  getOrderDetails(orderId: string): Observable<OrderDetailsModel> {
    return this.httpClient.get<OrderDetailsModel>(`${environment.apiUrl}/order/getDetails`, {
      params: { orderId }
    })
  }
}
