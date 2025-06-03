let currentIndex1 = 0;
let currentIndex2 = 0;
const slides1 = document.querySelectorAll("#slider1 .slayt .slaytkart");
const slides2 = document.querySelectorAll("#slider2 .slayt .slaytkart");

const totalSlides1 = slides1.length;
const totalSlides2 = slides2.length;

const slidesPerView = 3;

function updateSlide(sliderId) {
    const slides = document.querySelectorAll(`#${sliderId} .slayt .slaytkart`);
    const currentIndex = sliderId === "slider1" ? currentIndex1 : currentIndex2;

    slides.forEach((slide, index) => {
        slide.style.display = (index >= currentIndex && index < currentIndex + slidesPerView) ? "flex" : "none";
    });
}

function changeSlide(sliderId, direction) {
    if (sliderId === "slider1") {
        currentIndex1 += direction * slidesPerView;
        if (currentIndex1 < 0) {
            currentIndex1 = totalSlides1 - slidesPerView;
        } else if (currentIndex1 >= totalSlides1) {
            currentIndex1 = 0;
        }
        updateSlide("slider1");
    } else if (sliderId === "slider2") {
        currentIndex2 += direction * slidesPerView;
        if (currentIndex2 < 0) {
            currentIndex2 = totalSlides2 - slidesPerView;
        } else if (currentIndex2 >= totalSlides2) {
            currentIndex2 = 0;
        }
        updateSlide("slider2");
    }
}

document.addEventListener("DOMContentLoaded", () => {
    updateSlide("slider1");
    updateSlide("slider2");
});


// Modal ve Yazı Seçimi
var modal = document.getElementById("priceModal");
var priceLink = document.getElementById("priceLink");
var span = document.getElementsByClassName("close")[0];

// Yazıya tıklanınca modal'ı göster
priceLink.onclick = function() {
    modal.style.display = "block";
}

// Kapatma butonuna tıklanınca modal'ı kapat
span.onclick = function() {
    modal.style.display = "none";
}

// Modal dışına tıklanırsa da modal'ı kapat
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
