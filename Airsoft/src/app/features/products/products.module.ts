import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductsRoutingModule } from './products-routing.module';
import { RouterModule } from '@angular/router';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';
import { GunListComponent } from './gun-list/gun-list.component';



@NgModule({
  declarations: [
    CreateComponent,
    DetailsComponent,
    ListComponent,
    GunListComponent,
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
