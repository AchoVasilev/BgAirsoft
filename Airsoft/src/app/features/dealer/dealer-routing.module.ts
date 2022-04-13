import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { DealerGuard } from 'src/app/guards/dealer.guard';
import { ProfileComponent } from './profile/profile.component';
import { RegistrationComponent } from './registration/registration.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'register',
        component: RegistrationComponent,
        pathMatch: 'full'
      },
      {
        path: 'profile',
        component: ProfileComponent,
        pathMatch: 'full',
        canActivate: [AuthGuard, DealerGuard]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DealerRoutingModule { }
