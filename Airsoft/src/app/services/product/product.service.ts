import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  createGun(body: FormData): Observable<string> {
    return this.httpClient.post<string>(`${environment.apiUrl}/product/createGun`, body);
  }
}
