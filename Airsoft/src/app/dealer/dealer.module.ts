import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './profile/profile.component';
import { RegistrationComponent } from './registration/registration.component';
import { DealerRoutingModule } from './dealer-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    ProfileComponent,
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    DealerRoutingModule,
    FormsModule,
    ToastrModule
  ]
})
export class DealerModule { }
