import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { ClientRoutingModule } from './client-routing.module';
import { ClientService } from '../services/clientService/client.service';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    RegistrationComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    FormsModule
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
