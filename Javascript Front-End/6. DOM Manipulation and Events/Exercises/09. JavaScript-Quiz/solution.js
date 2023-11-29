function solve() {
    let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let rightAnswers = 0;
    let index = 0;

    Array.from(document.querySelectorAll('.answer-text'))
        .map(x => x.addEventListener('click', function (e) {
            checkAnswer(e.target.innerHTML);
            navigateToNextSection();
        }));

    function checkAnswer(answer) {
        if (correctAnswers.includes(answer)) {
            rightAnswers++;
        }
    }

    function navigateToNextSection() {
        let currentSection = document.querySelectorAll('section')[index];

        currentSection.style.display = 'none';

        if (document.querySelectorAll('section')[index + 1] !== undefined) {
            let nextSection = document.querySelectorAll('section')[index + 1];

            nextSection.style.display = 'block';
            index++;
        } else {
            displayResults();
        }
    }

    function displayResults() {
        document.getElementById('results').style.display = 'block';
        if (rightAnswers !== 3) {
            document.querySelector('#results h1').innerHTML = `You have ${rightAnswers} right answers`;
        } else {
            document.querySelector('#results h1').innerHTML = 'You are recognized as top JavaScript fan!';
        }
    }
}