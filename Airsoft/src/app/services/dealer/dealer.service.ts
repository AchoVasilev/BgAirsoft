import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDealerViewModel } from 'src/app/models/dealer/userDealerViewModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DealerService {

  constructor(private httpClient: HttpClient) { }

  register(body: FormData) {
    return this.httpClient.post(`${environment.apiUrl}/dealer/Register`, body, { withCredentials: true });
  }

  getDealerData(): Observable<UserDealerViewModel> {
    return this.httpClient.get<UserDealerViewModel>(`${environment.apiUrl}/dealer/profile`);
  }
}
