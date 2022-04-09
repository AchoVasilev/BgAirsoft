import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InitialGunViewModel } from 'src/app/models/products/guns/InitialGunViewModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  createGun(body: FormData): Observable<string> {
    return this.httpClient.post<string>(`${environment.apiUrl}/product/createGun`, body);
  }

  getNewestEightGuns(): Observable<InitialGunViewModel[]> {
    return this.httpClient.get<InitialGunViewModel[]>(`${environment.apiUrl}/product/getNewestGuns`);
  }
}
