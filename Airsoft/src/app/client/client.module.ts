import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { ClientRoutingModule } from './client-routing.module';
import { ClientService } from '../services/clientService/client.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ClientRoutingModule,
    FormsModule,
    ToastrModule
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
