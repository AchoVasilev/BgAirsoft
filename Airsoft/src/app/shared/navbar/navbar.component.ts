import { Component } from '@angular/core';
import { CategoryViewModel } from '../../models/category/categoryViewModel';
import { CategoryService } from '../../services/categoryService/category.service';

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

  catalogClick(): void {
    let catalog = document.getElementById('nav-catalog')!;
    const icon = document.querySelector('#catalog-btn > i')!;

    if (catalog.style.display == '' || catalog.style.display == 'none') {
      catalog.style.display = 'block';
    } else {
      catalog.style.display = 'none';
    }

    if (icon.classList.contains('fa-bars')) {
      icon.classList.remove('fa-bars');
      icon.classList.add('fa-xmark');
    } else if (icon.classList.contains('fa-xmark')) {
      icon.classList.remove('fa-xmark');
      icon.classList.add('fa-bars');
    }
  }

  mouseOut(): void{
    let catalog = document.getElementById('nav-catalog')!;
    const icon = document.querySelector('#catalog-btn > i')!;
    catalog.style.display = 'none';

    if (icon.classList.contains('fa-xmark')) {
      icon.classList.remove('fa-xmark');
      icon.classList.add('fa-bars');
    }
  }
}
