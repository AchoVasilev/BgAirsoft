import { Component, OnInit } from '@angular/core';
import { AllGunsViewModel } from 'src/app/models/products/guns/AllGunsViewModel';
import { SubCategoryViewModel } from 'src/app/models/subCategory/subCategoryViewModel';
import { CategoryService } from 'src/app/services/categoryService/category.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  subCategories: SubCategoryViewModel[];
  guns: AllGunsViewModel[];
  isLoading: boolean = true;
  isLoaded: boolean = false;

  constructor(private productService: ProductService, private categoryService: CategoryService) { }

  ngOnInit(): void {
  }

  // subCategories

  // getAllGuns(): void {
  //   this.productService.getAllGuns()
  //     .subscribe({
  //       next: (res: AllGunsViewModel[]) => {
  //         this.guns = res;
  //         setTimeout(() => {
  //           this.isLoaded = true;
  //           this.isLoading = false;
  //         }, 500);
  //       }
  //     }
  //   )
  // }
}
