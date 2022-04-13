import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ProductsComponent } from './products/products.component';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home/home.component';
import { CategoriesComponent } from './categories/categories.component';



@NgModule({
  declarations: [
    HomeComponent,
    ProductsComponent,
    CategoriesComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    HomeRoutingModule,
    MatProgressSpinnerModule
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
