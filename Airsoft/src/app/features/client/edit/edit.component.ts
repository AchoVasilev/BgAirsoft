import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CityViewModel } from 'src/app/models/city/cityViewModel';
import { EditClientModel } from 'src/app/models/clientModels/editClientModel';
import { UserClientViewModel } from 'src/app/models/clientModels/userClientViewModel';
import { CityService } from 'src/app/services/cityService/city.service';
import { ClientService } from 'src/app/services/clientService/client.service';
import { DataService } from 'src/app/services/data/data.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  client: UserClientViewModel;
  cities: CityViewModel[];
  isLoading: boolean = true;
  isLoaded: boolean = false;

  get userData(): UserClientViewModel {
    return this.dataService.userData;
  }

  editFormGroup: FormGroup = this.formBuilder.group({
    'firstName': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'lastName': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'streetName': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'cityName': new FormControl('', [Validators.required]),
    'phone': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
    'email': new FormControl('', [Validators.required, Validators.email]),
  });

  constructor(
    private clientService: ClientService,
    private cityService: CityService,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private dataService: DataService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.getClientData();
    this.loadCities();
    this.isLoaded = true;
    this.isLoading = false;

    this.editFormGroup.patchValue({
      firstName: this.userData.client.firstName,
      lastName: this.userData.client.lastName,
      streetName: this.userData.client.address.streetName,
      cityName: this.userData.client.address.city.name,
      phone: this.userData.client.phoneNumber,
      email: this.userData.email
    });
  }

  getClientData(): void {
    this.clientService.getClientData()
      .subscribe(clientData => {
        this.client = clientData;
      });
  }

  loadCities(): void {
    this.cities = undefined;
    this.cityService.loadCities()
      .subscribe(c => this.cities = c);
  }

  shouldShowErrorForControl(controlName: string, sourceGroup: FormGroup = this.editFormGroup) {
    return sourceGroup.controls[controlName].touched && sourceGroup.controls[controlName].invalid;
  }

  editData() {
    const { firstName, lastName, streetName, cityName, phone, email } = this.editFormGroup.value;
    const editModel: EditClientModel = {
      firstName,
      lastName,
      streetName,
      cityName,
      phone,
      email
    };

    this.clientService.edit(editModel)
      .subscribe({
        next: (res: any) => {
          this.toastr.success(res.message);
          this.editFormGroup.reset();
          this.router.navigate(['/client/profile']);
        },
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.errorMessage);
          }

          console.log(err);
        }
    })
  }
  
  closeEdit() {
    this.editFormGroup.reset();
    this.router.navigate(['/client/profile']);
  }
}
