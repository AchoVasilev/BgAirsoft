import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';
import { LoginComponent } from './shared/login/login.component';
import { UnderConstructionComponent } from './shared/under-construction/under-construction.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'products',
    loadChildren: () => import('./products/products.module').then(x => x.ProductsModule),
  },
  {
    path: 'building',
    component: UnderConstructionComponent
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
