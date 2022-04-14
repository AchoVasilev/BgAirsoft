import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CartComponent } from './cart/cart.component';
import { CartRoutingModule } from './cart-routing.module';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { EmptyComponent } from './empty/empty.component';
import { UserDataComponent } from './user-data/user-data.component';
import { DeliveryComponent } from './delivery/delivery.component';
import { SummaryComponent } from './summary/summary.component';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CartComponent,
    EmptyComponent,
    UserDataComponent,
    DeliveryComponent,
    SummaryComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CartRoutingModule,
    MatProgressSpinnerModule
  ]
})
export class CartModule { }
