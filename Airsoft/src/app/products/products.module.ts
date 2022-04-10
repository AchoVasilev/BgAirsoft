import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { DetailsComponent } from './details/details.component';
import { RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { GunListComponent } from './gun-list/gun-list.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';



@NgModule({
  declarations: [
    CreateComponent,
    DetailsComponent,
    ListComponent,
    GunListComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    ProductsRoutingModule,
    MatProgressSpinnerModule,
    FormsModule,
  ]
})
export class ProductsModule { }
