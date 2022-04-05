import { Component } from '@angular/core';
import { CategoryViewModel } from '../models/category/categoryViewModel';
import { CategoryService } from '../services/categoryService/category.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  categories: CategoryViewModel[] | undefined;

  constructor(private categoryService: CategoryService) {
    this.getCategories();
  }

  getCategories(): void {
    this.categories = undefined;
    this.categoryService
      .loadCategories()
      .subscribe(categories => this.categories = categories);
  }
}
