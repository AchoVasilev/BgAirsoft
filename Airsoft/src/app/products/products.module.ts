import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { DetailsComponent } from './details/details.component';



@NgModule({
  declarations: [
    CreateComponent,
    DetailsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ProductsRoutingModule,
    FormsModule,
  ]
})
export class ProductsModule { }
