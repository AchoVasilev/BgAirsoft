import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { ClientRoutingModule } from './client-routing.module';
import { ClientService } from '../services/clientService/client.service';



@NgModule({
  declarations: [
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
