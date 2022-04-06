import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CityViewModel } from 'src/app/models/city/cityViewModel';
import { environment } from 'src/environments/environment';

const url = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private http: HttpClient) { }

  loadCities() {
    return this.http.get<CityViewModel[]>(`${url}/city/all`);
  }
}
