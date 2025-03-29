
function toggleAnswer(element) {
    const answer = element.nextElementSibling;
    const arrow = element.querySelector('.faq-arrow');

    // Toggle active class on answer
    answer.classList.toggle('active');
    arrow.classList.toggle('active');

    // Close other answers
    const allAnswers = document.querySelectorAll('.faq-answer');
    const allArrows = document.querySelectorAll('.faq-arrow');

    allAnswers.forEach(item => {
        if (item !== answer && item.classList.contains('active')) {
            item.classList.remove('active');
        }
    });

    allArrows.forEach(item => {
        if (item !== arrow && item.classList.contains('active')) {
            item.classList.remove('active');
        }
    });
}