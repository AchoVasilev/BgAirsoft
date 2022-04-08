import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
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

  isClient(): boolean{
    const isClient = localStorage.getItem('isClient');
    if (isClient) {
      return true;
    }

    return false;
  }

  logOut() {
    localStorage.removeItem('token');
  }
}
