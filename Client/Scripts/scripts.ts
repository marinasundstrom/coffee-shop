interface Window {
    topFunction(): void;
}

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        document.getElementById("scrollTopButton")!.style.display = "block";
    } else {
        document.getElementById("scrollTopButton")!.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
window.topFunction = function () {
    window.scrollTo({
        top: 0,
        left: 0,
        behavior: 'smooth'
    });
}