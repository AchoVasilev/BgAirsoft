import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrdersRoutingModule } from './orders-routing.module';
import { ClientComponent } from './client/client.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { DetailsComponent } from './details/details.component';



@NgModule({
  declarations: [
    ClientComponent,
    DetailsComponent
  ],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    MatProgressSpinnerModule
  ]
})
export class OrderModule { }
