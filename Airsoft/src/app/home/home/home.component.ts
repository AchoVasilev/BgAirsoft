import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  private slideIndex: number = 1;
  private startIndex: number = 0;
  isLoaded: boolean = false;
  isLoading: boolean = true;  
  constructor() { }

  ngOnInit(): void {
    this.isLoaded = true;
    this.isLoading = false;
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

    if (slides.length > 0) {
      if (n > slides.length) {
        this.slideIndex = 1;
      }

      if (n < 1) {
        this.slideIndex = slides.length;
      }

      for (i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
      }

      if (this.slideIndex - 1 < 0) {
        this.slideIndex = 0;
      }

      slides[this.slideIndex - 1].style.display = 'block';
    }
  }

  autoShowSlides() {
    var i;
    var slides = document.getElementsByClassName('field-image') as HTMLCollectionOf<HTMLElement>;

    if (slides.length > 0) {
      for (i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
      }

      if (this.startIndex == undefined) {
        this.startIndex = 0;
      }

      this.startIndex++;
      if (this.startIndex > slides.length) {
        this.startIndex = 1;
      }

      slides[this.startIndex - 1].style.display = 'block';

      setTimeout(this.autoShowSlides, 4000); // Change image every 2 seconds
    }
  }
}
