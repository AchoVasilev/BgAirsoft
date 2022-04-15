import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, map, switchMap } from 'rxjs';
import { AllGunsViewModel } from 'src/app/models/products/guns/AllGunsViewModel';
import { GunsViewModel } from 'src/app/models/products/guns/gunsViewModel';
import { SubCategoryViewModel } from 'src/app/models/subCategory/subCategoryViewModel';
import { CartService } from 'src/app/services/cart/cart.service';
import { CategoryService } from 'src/app/services/categoryService/category.service';
import { DataService } from 'src/app/services/data/data.service';
import { ProductService } from 'src/app/services/product/product.service';
import { UserService } from 'src/app/services/user/user.service';

@Component({
  selector: 'app-gun-list',
  templateUrl: './gun-list.component.html',
  styleUrls: ['./gun-list.component.css']
})
export class GunListComponent implements OnInit {
  subCategories: SubCategoryViewModel[];
  // guns: AllGunsViewModel;
  isLoading: boolean = true;
  isLoaded: boolean = false;
  categoryName: string = null;

  canAdd: boolean;

  dealerFormGroup: FormGroup;
  manufacturersFormGroup: FormGroup;
  colorsFormGroup: FormGroup;
  powersFormGroup: FormGroup;
  sortingFormGroup: FormGroup;

  page: number = 1;
  itemsPerPage: number = 9;
  private orderBy: string = 'alphabetical';
  private dealers: string[] = [];
  private manufacturers: string[] = [];
  private colors: string[] = [];
  private powers: number[] = [];
  private price: number = 0;
  itemsCount: number = 0;

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

  get cartItemsPrice(): number {
    return this.dataService.cartItemsPrice;
  }
  set cartItemsPrice(value: number) {
    this.dataService.cartItemsPrice = value;
  }

  private pageChanges = new BehaviorSubject(undefined);
  allGuns: GunsViewModel;

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private cartService: CartService,
    private userService: UserService,
    private toastr: ToastrService,
    private dataService: DataService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute
  ) { 

  }

  ngOnInit(): void {
    // this.route.params.subscribe(
    //   params => {
    //     if (params['name'] !== undefined) {
    //       this.categoryName = params['name'];
    //     };

    //     this.getAllGuns();
    //   }
    // )

    this.canAdd = this.userService.isAuthenticated() && this.userService.isClient();
    this.getAllGuns();

    // this.productService
    //   .getAllGunsQuery(this.categoryName, this.itemsPerPage, this.orderBy, this.dealers, this.manufacturers, this.colors, this.powers, this.page)
    //   .subscribe(res => {
    //     this.allGuns = res;
    //     console.log(this.allGuns)
    //   });
    
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

  getAllGuns() {
    this.pageChanges;
    this.route.params.pipe(
      map(params => params['name'] ? this.categoryName = params['name'] : this.categoryName = null),
      switchMap(() =>
        this.productService
          .getAllGunsQuery(this.categoryName, this.itemsPerPage, this.orderBy, this.dealers, this.manufacturers, this.colors, this.powers, this.page))
    ).subscribe(res => {
      this.allGuns = res;
      this.isLoaded = true;
      this.isLoading = false;
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

  // queryGuns() {
  //   this.productService
  //     .queryGuns(this.categoryName, this.itemsPerPage, this.orderBy, this.dealers, this.manufacturers, this.colors, this.powers, this.page)
  //     .subscribe(g => this.allGuns = g);
  // }

  sortingCheck() {
    const count = this.countElement.nativeElement.value;
    const orderBy = this.orderByElement.nativeElement.value;
    this.itemsPerPage = count;
    this.orderBy = orderBy;

    this.getAllGuns();
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
    const data: string[] = this.dealerFormGroup.value['dealers'];
    this.dealers = data;

    this.getAllGuns();
  }

  filterByManufacturers() {
    const data: string[] = this.manufacturersFormGroup.value['manufacturers'];
    this.manufacturers = data;

    this.getAllGuns();
  }

  filterByColors() {
    const data: string[] = this.colorsFormGroup.value['colors'];
    this.colors = data;

    this.getAllGuns();
  }

  filterByPowers() {
    const data: number[] = this.powersFormGroup.value['powers'];
    this.powers = data;

    this.getAllGuns();
  }

  addToBasket(gunId: number, price: number) {
    this.isLoaded = false;
    this.isLoading = true;
    this.cartService.AddItem(gunId)
      .subscribe({
        next: (result) => {
          this.toastr.success("Успешно добавяне!");
          this.itemsCount = this.cartItemsCount + 1;
          this.cartItemsCount = this.itemsCount;

          this.price = +price;
          this.price = (+this.cartItemsPrice) + (+this.price);
          this.cartItemsPrice = this.price;
        },
        error: (err) => {
          if (err.status == 400) {
            this.toastr.error(err.error.ErrorMessage);
          }
        },
        complete: () => {
          this.isLoaded = true;
          this.isLoading = false;
        }
    })
  }

  goOnePageBack() {
    this.page--;
    this.getAllGuns();
  }

  goOnePageForward() {
    this.page++;
    this.getAllGuns();
  }
}