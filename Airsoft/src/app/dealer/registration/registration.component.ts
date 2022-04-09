import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CityViewModel } from 'src/app/models/city/cityViewModel';
import { DealerInputModel } from 'src/app/models/dealer/DealerInputModel';
import { CityService } from 'src/app/services/cityService/city.service';
import { DealerService } from 'src/app/services/dealer/dealer.service';
import { UserService } from 'src/app/services/user/user.service';
import { passwordMatch } from 'src/app/shared/utils';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  cities: CityViewModel[];
  file: File;
  
  passwordControl = new FormControl('', [Validators.required, Validators.minLength(6)]);

  get passwordsGroup(): FormGroup {
    return this.registerFormGroup.controls['passwords'] as FormGroup;
  }

  registerFormGroup: FormGroup = this.formBuilder.group({
    'name': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'dealerNumber': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'streetName': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'image': new FormControl(null, [Validators.required]),
    'siteUrl': new FormControl(null),
    'cityName': new FormControl('', [Validators.required]),
    'phone': new FormControl('', [Validators.required, Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$")]),
    'email': new FormControl('', [Validators.required, Validators.email]),
    'username': new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(40)]),
    'passwords': new FormGroup({
      'password': this.passwordControl,
      'repeatPassword': new FormControl('', [passwordMatch(this.passwordControl)])
    })
  })

  constructor(
    private cityService: CityService,
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router,
    private dealerService: DealerService,
    private toastr: ToastrService
  ) {
    this.loadCities();
  }

  ngOnInit(): void {
    if (this.userService.isAuthenticated()) {
      this.router.navigate(['/']);
    }
  }

  loadCities(): void {
    this.cities = undefined;
    this.cityService.loadCities()
      .subscribe(c => this.cities = c);
  }

  shouldShowErrorForControl(controlName: string, sourceGroup: FormGroup = this.registerFormGroup) {
    return sourceGroup.controls[controlName].touched && sourceGroup.controls[controlName].invalid;
  }

  onChange(event: any) {
    this.file = <File>event.target.files[0];
  }

  handleRegistration() {
    const { name, dealerNumber, streetName, cityName, phone, email, image, siteUrl, username, passwords } = this.registerFormGroup.value;

    const body = new FormData();
    body.append('name', name);
    body.append('dealerNumber', dealerNumber);
    body.append('streetName', streetName);
    body.append('cityName', cityName);
    body.append('phone', phone);
    body.append('email', email);
    body.append('image', this.file);
    body.append('siteUrl', siteUrl);
    body.append('username', username);
    body.append('password', passwords.password);
    
    this.dealerService.register(body)
      .subscribe({
        next: () => this.router.navigate(['/login']),
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.errorMessage)
          }
        }
      });
  }
}