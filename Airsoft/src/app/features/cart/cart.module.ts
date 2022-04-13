import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart/cart.component';
import { CartRoutingModule } from './cart-routing.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { EmptyComponent } from './empty/empty.component';
import { UserDataComponent } from './user-data/user-data.component';



@NgModule({
  declarations: [
    CartComponent,
    EmptyComponent,
    UserDataComponent
  ],
  imports: [
    CommonModule,
    CartRoutingModule,
    MatProgressSpinnerModule
  ]
})
export class CartModule { }
