import { Component, OnInit } from '@angular/core';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { ClientService } from 'src/app/services/clientService/client.service';
import { DataService } from 'src/app/services/data/data.service';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  client: UserClientViewModel;
  isLoaded: boolean = false;
  isLoading: boolean = true;

  get userData(): UserClientViewModel{
    return this.dataService.userData;
  }
  set userData(value) {
    this.dataService.userData = value;
  }

  constructor(private clientService: ClientService, private dataService: DataService) { }

  ngOnInit(): void {
    this.getUserData();
    this.isLoaded = true;
    this.isLoading = false;
    console.log(this.userData);
  }

  getUserData(): void{
    this.clientService.getClientData()
      .subscribe(res => {
        this.client = res;
        this.userData = res;
        console.log(res);
      });
  }
}
