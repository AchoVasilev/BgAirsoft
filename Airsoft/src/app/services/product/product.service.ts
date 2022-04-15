import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AllGunsViewModel } from 'src/app/models/products/guns/AllGunsViewModel';
import { GunDetailsViewModel } from 'src/app/models/products/guns/gunDetailsViewModel';
import { GunsViewModel } from 'src/app/models/products/guns/gunsViewModel';
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

  getAllGuns(): Observable<AllGunsViewModel> {
    return this.httpClient.get<AllGunsViewModel>(`${environment.apiUrl}/product/getAllGuns`);
  }

  // getGunsByManufacturers(manufacturers: string[]): Observable<AllGunViewModel[]> {
  //   return this.httpClient.get<AllGunViewModel[]>(`${environment.apiUrl}/product/gunsByManufacturer`, {
  //     params: {
  //       manufacturers
  //     }
  //   });
  // }

  // getGunsByDealers(dealers: string[]): Observable<AllGunViewModel[]> {
  //   return this.httpClient.get<AllGunViewModel[]>(`${environment.apiUrl}/product/gunsByDealer`, {
  //     params: {
  //       dealers
  //     }
  //   });
  // }

  // getGunsByColors(colors: string[]): Observable<AllGunViewModel[]> {
  //   return this.httpClient.get<AllGunViewModel[]>(`${environment.apiUrl}/product/gunsByColor`, {
  //     params: {
  //       colors
  //     }
  //   });
  // }

  // getGunsByPowers(powers: number[]): Observable<AllGunViewModel[]> {
  //   return this.httpClient.get<AllGunViewModel[]>(`${environment.apiUrl}/product/gunsByPower`, {
  //     params: {
  //       powers
  //     }
  //   });
  // }

  // getGunsByCategory(categoryName: string): Observable<AllGunsViewModel>{
  //   return this.httpClient.get<AllGunsViewModel>(`${environment.apiUrl}/product/gunsByCategory`, {
  //     params: {
  //       categoryName
  //     }
  //   });
  // }

  // queryGuns(categoryName: string,
  //   itemsPerPage: number,
  //   orderBy: string, dealers: string[], manufacturers: string[], colors: string[], powers: number[], page: number): Observable<GunsViewModel> {
  //   return this.httpClient.get<GunsViewModel>(`${environment.apiUrl}/product/queryGuns`, {
  //     params: {
  //       categoryName,
  //       itemsPerPage,
  //       orderBy,
  //       dealers,
  //       manufacturers,
  //       colors,
  //       powers,
  //       page
  //     }
  //   })
  // }

  getAllGunsQuery(categoryName: string,
    itemsPerPage: number,
    orderBy: string, dealers: string[], manufacturers: string[], colors: string[], powers: number[], page: number): Observable<GunsViewModel>{
    return this.httpClient.get<GunsViewModel>(`${environment.apiUrl}/product/all`, {
      params: {
        categoryName,
        itemsPerPage,
        orderBy,
        dealers,
        manufacturers,
        colors,
        powers,
        page
      }
    })
  }

  getGunDetails(gunId: number): Observable<GunDetailsViewModel>{
    return this.httpClient.get<GunDetailsViewModel>(`${environment.apiUrl}/product/details`, {
      params: {
        gunId
      }
    })
  }
}
