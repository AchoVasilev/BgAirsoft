import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DealerIdObj } from 'src/app/models/dealer/dealerIdObj';
import { LoginInputModel } from 'src/app/shared/login/loginModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  login(body: LoginInputModel){
    return this.httpClient.post(`${environment.apiUrl}/user/login`, body);
  }

  isAuthenticated(): boolean{
    const token = localStorage.getItem('token');
    if (token) {
      return true;
    }

    return false;
  }

  getDealerId(): Observable<DealerIdObj>{
    return this.httpClient.get<DealerIdObj>(`${environment.apiUrl}/user/getDealerId`)
  }

  isClient(): boolean{
    const isClient = localStorage.getItem('isClient');
    if (isClient == "true") {
      return true;
    }

    return false;
  }

  logOut() {
    localStorage.removeItem('token');
  }
}
