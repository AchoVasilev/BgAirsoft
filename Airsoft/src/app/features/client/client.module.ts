import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrationComponent } from './registration/registration.component';
import { ClientRoutingModule } from './client-routing.module';
import { ClientService } from '../../services/clientService/client.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { ProfileComponent } from './profile/profile.component';
import { EditComponent } from './edit/edit.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatDialogModule } from '@angular/material/dialog'; 


@NgModule({
  declarations: [
    RegistrationComponent,
    ProfileComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ClientRoutingModule,
    FormsModule,
    ToastrModule,
    MatProgressSpinnerModule,
    MatDialogModule
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
