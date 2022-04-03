document.addEventListener('click', e => documentClickHandler(e));

function documentClickHandler(e) {
    let catalog = document.getElementById('nav-catalog');
    const icon = document.querySelector('#catalog-btn > i');
    if (e.target.id == 'catalog-btn' || e.target.id == 'catalog-btn-icon') {
        if (catalog.style.display == '' || catalog.style.display == 'none') {
            catalog.style.display = 'block';
        } else {
            catalog.style.display = 'none';
        }

        if (icon.classList.contains('fa-bars')) {
            icon.classList.remove('fa-bars');
            icon.classList.add('fa-xmark');
        } else if (icon.classList.contains('fa-xmark')) {
            icon.classList.remove('fa-xmark');
            icon.classList.add('fa-bars');
        }
    }
    else {
        catalog.style.display = 'none';

        if (icon.classList.contains('fa-xmark')) {
            icon.classList.remove('fa-xmark');
            icon.classList.add('fa-bars');
        }
    }
}