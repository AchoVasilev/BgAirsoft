import { Component, OnInit } from '@angular/core';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { ClientService } from 'src/app/services/clientService/client.service';
import { DataService } from 'src/app/services/data/data.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  client: UserClientViewModel;
  isLoaded: boolean = false;
  isLoading: boolean = true;


  get userData(): UserClientViewModel {
    return this.dataService.userData;
  }
  set userData(value) {
    this.dataService.userData = value;
  }

  constructor(private clientService: ClientService, private dataService: DataService) { }

  ngOnInit(): void {
    this.getClientData();
    this.isLoaded = true;
    this.isLoading = false;
  }

  getClientData(): void {
    this.clientService.getClientData()
      .subscribe(clientData => {
        this.client = clientData;
        this.userData = clientData;
      });
  }

}
