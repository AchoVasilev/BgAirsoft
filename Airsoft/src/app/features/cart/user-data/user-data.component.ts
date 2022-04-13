import { Component, OnInit } from '@angular/core';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { ClientService } from 'src/app/services/clientService/client.service';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  client: UserClientViewModel;
  isLoaded: boolean = false;
  isLoading: boolean = true;

  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.getUserData();
    this.isLoaded = true;
    this.isLoading = false;
  }

  getUserData(): void{
    this.clientService.getClientData()
      .subscribe(res => this.client = res);
  }
}
