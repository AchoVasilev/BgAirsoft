import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AllGunsViewModel } from 'src/app/models/products/guns/AllGunsViewModel';
import { SubCategoryViewModel } from 'src/app/models/subCategory/subCategoryViewModel';
import { CategoryService } from 'src/app/services/categoryService/category.service';
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

  dealerFormGroup: FormGroup;

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private formBuilder: FormBuilder
  ) { }
  
  ngOnInit(): void {
    this.getGunSubCategories();
    this.getAllGuns();

    this.dealerFormGroup = this.formBuilder.group({
      dealers: this.formBuilder.array([])
    });
    // if (this.isLoaded) {
    //   this.AddCheckBoxes();
    // }
  }

  // private AddCheckBoxes() {
  //   this.guns.dealers.forEach(() => this.dealersFromArray.push(new FormControl(false)));
  // }

  getGunSubCategories(): void {
    this.categoryService.loadGunSubcategories()
      .subscribe(subs => this.subCategories = subs);
  }

  getAllGuns(): void {
    this.productService.getAllGuns()
      .subscribe(
        g => {
          this.guns = g;
          setTimeout(() => {
            this.isLoaded = true;
            this.isLoading = false;
          }, 500);
        }
    )
  }

  onChange(name: string, isChecked: any) {
    const gunsArr = (this.dealerFormGroup.controls['dealers'] as FormArray);

    if (isChecked.checked) {
      gunsArr.push(new FormControl(name));
    } else {
      const index = gunsArr.controls.findIndex(x => x.value === name);
      gunsArr.removeAt(index);
    }
  }

  filterByDealers() {
    const data = this.dealerFormGroup.value.dealers

    console.log(data);
  }
}
