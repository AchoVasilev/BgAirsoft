var slideIndex = 1;
showSlides(slideIndex);

var startIndex = 0;
autoShowSlides();

// Next/previous controls
function plusSlides(n) {
    showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName('field-image');

    if (n > slides.length) {
        slideIndex = 1;
    }

    if (n < 1) {
        slideIndex = slides.length;
    }

    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }

    slides[slideIndex - 1].style.display = 'block';
}

showSlides();

function autoShowSlides() {
    var i;
    var slides = document.getElementsByClassName('field-image');
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }

    startIndex++;
    if (startIndex > slides.length) {
        startIndex = 1;
    }

    slides[startIndex - 1].style.display = 'block';
    
    setTimeout(autoShowSlides, 4000); // Change image every 2 seconds
} 

    const btn = document.getElementById('catalog-btn');
    btn.addEventListener('click', clickHandler);

function clickHandler() {
    let catalog = document.getElementById('nav-catalog');
    if (catalog.style.display == '') {
        catalog.style.display = 'block';
    } else {
        catalog.style.display = '';
    }

    const icon = document.querySelector('#catalog-btn > i');

    if (icon.classList.contains('fa-bars')) {
        icon.classList.remove('fa-bars');
        icon.classList.add('fa-xmark');
    } else if (icon.classList.contains('fa-xmark')) {
        icon.classList.remove('fa-xmark');
        icon.classList.add('fa-bars');
    }
}