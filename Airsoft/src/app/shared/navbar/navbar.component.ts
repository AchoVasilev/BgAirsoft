import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';
import { CategoryViewModel } from '../../models/category/categoryViewModel';
import { CategoryService } from '../../services/categoryService/category.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {
  categories: CategoryViewModel[] | undefined;

  get isLoggedIn(): boolean {
    return this.userService.isAuthenticated();
  }

  get isClient(): boolean{
    return this.userService.isClient();
  }

  constructor(private categoryService: CategoryService, private userService: UserService, private router: Router) {
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

  logOut(): void{
    this.userService.logOut();
    this.router.navigate(['/'])
  }
}
