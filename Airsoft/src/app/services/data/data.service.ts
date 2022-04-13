import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  cartItemsCount: number = 0;
  cartItemsPrice: number = 0;
  
  constructor() { }
}
