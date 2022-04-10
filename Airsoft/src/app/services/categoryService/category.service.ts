import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BasicCategoryViewModel } from 'src/app/models/category/basicCategoryViewModel';
import { CategoryViewModel } from 'src/app/models/category/categoryViewModel';
import { GunSubcategoryViewModel } from 'src/app/models/category/gunSubcategoryViewModel';
import { environment } from 'src/environments/environment';

const apiUrl = environment.apiUrl;

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }

  loadCategories() {
    return this.httpClient.get<CategoryViewModel[]>(`${apiUrl}/Categories/All`);
  }

  loadNewestCategories() {
    return this.httpClient.get<BasicCategoryViewModel[]>(`${apiUrl}/categories/newest`);
  }

  loadGunSubcategories() {
    return this.httpClient.get<GunSubcategoryViewModel[]>(`${apiUrl}/categories/gunSubcategories`);
  }
}
