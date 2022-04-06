import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CityViewModel } from 'src/app/models/city/cityViewModel';
import { CityService } from 'src/app/services/cityService/city.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  cities: CityViewModel[] | undefined;

  registerFormGroup: FormGroup = this.formBuilder.group({
    firstName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    lastName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    streetName: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)])
  })
  
  constructor(private formBuilder: FormBuilder, private cityService: CityService) {
    this.loadCities();
  }

  ngOnInit(): void {
  }

  loadCities(): void {
    this.cities = undefined;
    this.cityService.loadCities()
      .subscribe(c => this.cities = c);
  }

  onSubmit() {
  }
}
