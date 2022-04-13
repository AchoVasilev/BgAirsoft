import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/services/cart/cart.service';
import { DataService } from 'src/app/services/data/data.service';
import { UserService } from 'src/app/services/user/user.service';
import { LoginInputModel } from './loginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginFormGroup: FormGroup = this.formBuilder.group({
    'username': new FormControl('', [Validators.required]),
    'password': new FormControl('', [Validators.required, Validators.minLength(6)])
  });

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
    private formBuilder: FormBuilder,
    private userService: UserService,
    private dataService: DataService,
    private cartService: CartService,
    private router: Router,
    private toastr: ToastrService,
  ) { }

  ngOnInit(): void {
    if (this.userService.isAuthenticated()) {
      this.router.navigate(['/']);
    }
  }

  loginHandler() {
    const { username, password } = this.loginFormGroup.value;
    const body: LoginInputModel = {
      username,
      password
    };

    this.userService.login(body)
      .subscribe({
        next: (res: any) => {
          localStorage.setItem('token', res.token);
          localStorage.setItem('isClient', res.isClient);
          this.router.navigate(['/home']);
          this.getCartData();
        },
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.errorMessage)
          }
        }
      }
      );
  }

  getCartData(): void {
    this.cartService.GetItemsCountAndPrice()
      .subscribe(res => {
        this.cartItemsCount = res.itemsCount;
        this.cartItemsPrice = res.totalPrice.toFixed(2);
      })
  }
}
