import { Component, OnInit } from '@angular/core';
import { UserDealerViewModel } from 'src/app/models/dealer/userDealerViewModel';
import { DealerService } from 'src/app/services/dealer/dealer.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  dealer: UserDealerViewModel
  constructor(private dealerService: DealerService) { }

  ngOnInit(): void {
    this.getProfile();
  }

  getProfile() {
    this.dealerService.getDealerData()
      .subscribe(d => this.dealer = d);
  }
}
