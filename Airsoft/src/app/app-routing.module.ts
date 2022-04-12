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
    path: 'client',
    loadChildren: () => import('./client/client.module').then(x => x.ClientModule)
  },
  {
    path: 'dealer',
    loadChildren: () => import('./dealer/dealer.module').then(x => x.DealerModule)
  },
  {
    path: 'cart',
    loadChildren: () => import('./cart/cart.module').then(x => x.CartModule)
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
