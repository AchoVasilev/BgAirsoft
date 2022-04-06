import { Component, OnInit } from '@angular/core';
import { CategoryViewModel } from 'src/app/models/category/categoryViewModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private slideIndex: number = 1;
  private startIndex: number = 0;
  private categories: CategoryViewModel[] | undefined;
  
  constructor() { }

  ngOnInit(): void {
    this.showSlides(this.slideIndex);
    this.autoShowSlides();
  }

  // Next/previous controls
  plusSlides(n: any) {
    this.showSlides(this.slideIndex += n);
  }

  // Thumbnail image controls
  currentSlide(n: any) {
    this.showSlides(this.slideIndex = n);
  }

  showSlides(n: any) {
    var i;
    var slides = document.getElementsByClassName('field-image') as HTMLCollectionOf<HTMLElement>;

    if (n > slides.length) {
      this.slideIndex = 1;
    }

    if (n < 1) {
      this.slideIndex = slides.length;
    }

    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = 'none';
    }

    slides[this.slideIndex - 1].style.display = 'block';
  }

  autoShowSlides() {
    var i;
    var slides = document.getElementsByClassName('field-image') as HTMLCollectionOf<HTMLElement>;
    for (i = 0; i < slides.length; i++) {
      slides[i].style.display = 'none';
    }

    this.startIndex++;
    if (this.startIndex > slides.length) {
      this.startIndex = 1;
    }

    slides[this.startIndex - 1].style.display = 'block';

    setTimeout(this.autoShowSlides, 4000); // Change image every 2 seconds
  }
}
