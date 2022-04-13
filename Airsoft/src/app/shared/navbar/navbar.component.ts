import { ApplicationRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart/cart.service';
import { DataService } from 'src/app/services/data/data.service';
import { UserService } from 'src/app/services/user/user.service';
import { CategoryViewModel } from '../../models/category/categoryViewModel';
import { CategoryService } from '../../services/categoryService/category.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  categories: CategoryViewModel[] | undefined;

  get isLoggedIn(): boolean {
    return this.userService.isAuthenticated();
  }

  get isClient(): boolean {
    return this.userService.isClient();
  }

  get cartItemsCount(): number {
    return this.dataService.cartItemsCount;
  }
  set cartItemsCount(value) {
    this.dataService.cartItemsCount = value;
  }

  get cartItemsPrice(): number {
    return this.dataService.cartItemsPrice;
  }
  set cartItemsPrice(value) {
    this.dataService.cartItemsPrice = value;
  }

  constructor(
    private categoryService: CategoryService,
    private userService: UserService,
    private dataService: DataService,
    private cartService: CartService,
    private router: Router
  ) { }
  
  ngOnInit(): void {
    this.getCartData();
    this.getCategories();
  }

  getCartData(): void{
    this.cartService.GetItemsCountAndPrice()
      .subscribe(res => {
        this.cartItemsCount = res.itemsCount;
        this.cartItemsPrice = res.totalPrice.toFixed(2);
    })
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

  mouseOut(): void {
    let catalog = document.getElementById('nav-catalog')!;
    const icon = document.querySelector('#catalog-btn > i')!;
    catalog.style.display = 'none';

    if (icon.classList.contains('fa-xmark')) {
      icon.classList.remove('fa-xmark');
      icon.classList.add('fa-bars');
    }
  }

  logOut(): void {
    this.userService.logOut();
    this.router.navigate(['/'])
    this.cartItemsCount = 0;
    this.cartItemsPrice = 0;
  }
}
