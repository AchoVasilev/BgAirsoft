import { Component, OnInit } from '@angular/core';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { ClientService } from 'src/app/services/clientService/client.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  client: UserClientViewModel;
  isLoaded: boolean = false;
  isLoading: boolean = true;

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.getClientData();
    this.isLoaded = true;
    this.isLoading = false;
  }

  getClientData(): void{
    this.clientService.getClientData()
      .subscribe(clientData => this.client = clientData);
  }

}
