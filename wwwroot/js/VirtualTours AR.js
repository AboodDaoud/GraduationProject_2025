function toggleAnswer(element) {
    const answer = element.nextElementSibling;
    const arrow = element.querySelector('.arrow-icon');

    // Toggle active class on answer
    answer.classList.toggle('active');
    arrow.classList.toggle('active');

    // Close other answers
    const allAnswers = document.querySelectorAll('.accordion-answer');
    const allArrows = document.querySelectorAll('.arrow-icon');

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