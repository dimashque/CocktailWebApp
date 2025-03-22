// Wait for the document to fully load before running the code
document.addEventListener('DOMContentLoaded', function () {

    // Example of a random drink suggestion that pops up
    setTimeout(function () {
        alert("Need inspiration? How about trying a 'Margarita' today!");
    }, 5000);

    // Smooth scrolling for anchor links (e.g., navigating between sections)
    const scrollLinks = document.querySelectorAll('a[href^="#"]');

    scrollLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();
            const targetId = this.getAttribute('href').slice(1);
            const targetElement = document.getElementById(targetId);
            targetElement.scrollIntoView({ behavior: 'smooth' });
        });
    });

    // Animation effect on page load for Category page
    if (document.body.classList.contains('page-category')) {
        const cardBodies = document.querySelectorAll('.card-body');
        cardBodies.forEach((card, index) => {
            setTimeout(() => {
                card.classList.add('fade-in');
            }, index * 100);
        });
    }

    // Add fade-in effect to elements when they enter the viewport
    const fadeInElements = document.querySelectorAll('.fade-in');
    window.addEventListener('scroll', function () {
        fadeInElements.forEach(element => {
            if (element.getBoundingClientRect().top < window.innerHeight - 100) {
                element.classList.add('visible');
            }
        });
    });

});
