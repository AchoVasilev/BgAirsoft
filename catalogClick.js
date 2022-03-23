const btn = document.getElementById('catalog-btn');
btn.addEventListener('click', clickHandler);
let catalog = document.getElementById('nav-catalog');

function clickHandler() {
    btn.addEventListener('click', clickHandler);
    if (catalog.style.display == 'none') {
        catalog.style.display = 'block';
    } else {
        catalog.style.display = 'none';
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

document.addEventListener('mouseup', e => documentClickHandler(e));

function documentClickHandler(e) {
    e.preventDefault();
    if (catalog.contains(e.target)) {
        return;
    }
    
    catalog.style.display = 'none';
    
    const icon = document.querySelector('#catalog-btn > i');
    if (icon.classList.contains('fa-xmark')) {
        icon.classList.remove('fa-xmark');
        icon.classList.add('fa-bars');
    }
    return;
}