import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map, switchMap } from 'rxjs';
import { AllGunsViewModel } from 'src/app/models/products/guns/AllGunsViewModel';
import { SubCategoryViewModel } from 'src/app/models/subCategory/subCategoryViewModel';
import { CartService } from 'src/app/services/cart/cart.service';
import { CategoryService } from 'src/app/services/categoryService/category.service';
import { DataService } from 'src/app/services/data/data.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-gun-list',
  templateUrl: './gun-list.component.html',
  styleUrls: ['./gun-list.component.css']
})
export class GunListComponent implements OnInit {
  subCategories: SubCategoryViewModel[];
  guns: AllGunsViewModel;
  isLoading: boolean = true;
  isLoaded: boolean = false;
  categoryName: string = null;

  dealerFormGroup: FormGroup;
  manufacturersFormGroup: FormGroup;
  colorsFormGroup: FormGroup;
  powersFormGroup: FormGroup;
  sortingFormGroup: FormGroup;

  @ViewChild('orderBy')
  orderByElement: ElementRef;

  @ViewChild('count')
  countElement: ElementRef;

  get cartItemsCount():number {
    return this.dataService.cartItemsCount
  }
  set cartItemsCount(value: number) {
    this.dataService.cartItemsCount = value;
  }

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private cartService: CartService,
    private toastr: ToastrService,
    private dataService: DataService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // this.route.params.subscribe(
    //   params => {
    //     if (params['name'] !== undefined) {
    //       this.categoryName = params['name'];
    //     };

    //     this.getAllGuns();
    //   }
    // )

    this.route.params.pipe(
      map(params => params['name'] ? this.categoryName = params['name'] : this.categoryName = null),
      switchMap(() => this.productService.getGunsByCategory(this.categoryName))
    ).subscribe(res => {
      this.guns = res;
      this.isLoaded = true;
      this.isLoading = false;
    });

    this.getGunSubCategories();

    this.dealerFormGroup = this.formBuilder.group({
      dealers: this.formBuilder.array([])
    });

    this.manufacturersFormGroup = this.formBuilder.group({
      manufacturers: this.formBuilder.array([])
    });

    this.colorsFormGroup = this.formBuilder.group({
      colors: this.formBuilder.array([])
    });

    this.powersFormGroup = this.formBuilder.group({
      powers: this.formBuilder.array([])
    });

    this.sortingFormGroup = this.formBuilder.group({
      'orderBy': new FormControl('alphabetical')
    });

  }

  getGunSubCategories(): void {
    this.categoryService.loadGunSubcategories()
      .subscribe(subs => this.subCategories = subs);
  }

  // getAllGuns(): void {
  //   this.productService.getGunsByCategory(this.categoryName)
  //     .subscribe(
  //       g => {
  //         this.guns = g;
  //         setTimeout(() => {
  //           this.isLoaded = true;
  //           this.isLoading = false;
  //         }, 500);
  //       }
  //   )
  // }

  sortingCheck() {
    const count = this.countElement.nativeElement.value;
    const orderBy = this.orderByElement.nativeElement.value;

    this.productService.getSortedGuns(this.categoryName, count, orderBy)
      .subscribe(g => this.guns.allGuns = g);
  }

  onChange(itemName: any, formGroup: FormGroup, groupName: string, isChecked: any) {
    const itemsArr = (formGroup.controls[groupName] as FormArray);

    if (isChecked.checked) {
      itemsArr.push(new FormControl(itemName));
    } else {
      const index = itemsArr.controls.findIndex(x => x.value === itemName);
      itemsArr.removeAt(index);
    }
  }

  filterByDealers() {
    const data = this.dealerFormGroup.value['dealers'];

    this.productService.getGunsByDealers(data)
      .subscribe(res => this.guns.allGuns = res);
  }

  filterByManufacturers() {
    const data: string[] = this.manufacturersFormGroup.value['manufacturers'];

    this.productService.getGunsByManufacturers(data)
      .subscribe(res => this.guns.allGuns = res);
  }

  filterByColors() {
    const data: string[] = this.colorsFormGroup.value['colors'];

    this.productService.getGunsByColors(data)
      .subscribe(res => this.guns.allGuns = res);
  }

  filterByPowers() {
    const data: number[] = this.powersFormGroup.value['powers'];

    this.productService.getGunsByPowers(data)
      .subscribe(res => this.guns.allGuns = res);
  }

  addToBasket(gunId: number) {
    this.cartService.AddItem(gunId)
      .subscribe({
        next: (result) => {
          this.toastr.success("Успешно добавяне!");
          this.cartItemsCount = result.itemsCount;
        },
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.ErrorMessage);
          }
        }
    })
  }
}