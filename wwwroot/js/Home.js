function toggleLanguage() {
    const languageButton = document.getElementById('languageButton');
    if (languageButton.textContent === 'EN') {
        languageButton.textContent = 'AR';
    } else {
        languageButton.textContent = 'EN';
    }
}


function toggleNotifications() {
    const notificationButton = document.getElementById('notificationButton');
    if (notificationButton.textContent === '🔔') {
        notificationButton.textContent = '🔕';
    } else {
        notificationButton.textContent = '🔔';
    }
}



let slideIndex = 1;
showSlides(slideIndex);

function showSlides(n) {
    let slides = document.querySelectorAll('.slides');
    let dots = document.querySelectorAll('.dot');
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }
    for (let i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(' active', '');
    }
    slides[slideIndex - 1].style.display = 'block';
    dots[slideIndex - 1].className += ' active';
}

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

// 7
let currentPosition = 0;
const gallery = document.getElementById('gallery2');
const items = document.querySelectorAll('.gallery-item');
const itemWidth = 250; // عرض العنصر مع التباعد

function moveSlide(direction) {
    const maxPosition = -(items.length - Math.floor(gallery.clientWidth / itemWidth)) * itemWidth;
    currentPosition += direction * itemWidth;

    if (currentPosition > 0) {
        currentPosition = 0; // لا تذهب إلى اليسار أكثر مما ينبغي
    } else if (currentPosition < maxPosition) {
        currentPosition = maxPosition; // لا تذهب إلى اليمين أكثر مما ينبغي
    }

    gallery.style.transform = `translateX(${currentPosition}px)`;
}