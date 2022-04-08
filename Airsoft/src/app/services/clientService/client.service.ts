import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClientInputModel } from 'src/app/models/clientModels/clientInputModel';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private httpClient: HttpClient) { }

  register(body: ClientInputModel): Observable<ClientInputModel> {
    return this.httpClient.post<ClientInputModel>(`${environment.apiUrl}/client/Register`, body, { withCredentials: true });
  }

  getClientData(): Observable<UserClientViewModel> {
    return this.httpClient.get<UserClientViewModel>(`${environment.apiUrl}/client/profile`);
  }
}
