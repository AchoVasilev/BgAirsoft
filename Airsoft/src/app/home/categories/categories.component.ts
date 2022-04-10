import { Component, OnInit } from '@angular/core';
import { BasicCategoryViewModel } from 'src/app/models/category/basicCategoryViewModel';
import { CategoryService } from 'src/app/services/categoryService/category.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {
  isLoaded: boolean = false;
  isLoading: boolean = true;
  categories: BasicCategoryViewModel[];

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.loadNewestCategories();
  }

  loadNewestCategories() {
    this.categoryService.loadNewestCategories()
      .subscribe({
        next: (res: BasicCategoryViewModel[]) => {
          this.categories = res;
          setTimeout(() => {
            this.isLoaded = true;
            this.isLoading = false;
          }, 700);
        },
        error: (err) => {
          this.isLoaded = true;
          this.isLoading = false;
        }
    })
  }
}
