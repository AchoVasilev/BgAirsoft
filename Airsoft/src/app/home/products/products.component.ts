import { Component, OnInit } from '@angular/core';
import { InitialGunViewModel } from 'src/app/models/products/guns/InitialGunViewModel';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  isLoaded: boolean = false;
  isLoading: boolean = true;
  guns: InitialGunViewModel[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.getNewestGuns();
  }

  getNewestGuns(): void{
    this.productService.getNewestEightGuns()
      .subscribe({
        next: (res: InitialGunViewModel[]) => {
          this.guns = res;
          setTimeout(() => {
            this.isLoaded = true;
            this.isLoading = false;
          }, 700);
        },
        error: (err) => { 
          this.isLoaded = true;
          this.isLoading = false;
        }
      });
  }
}
