function solve() {
    let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let countAnswers = 0;
    let index = 0;

    Array
        .from(document.querySelectorAll('.answer-text'))
        .map(x => x.addEventListener('click', function nextSection(e) {
            if (correctAnswers.includes(e.target.textContent)) {
                countAnswers++;
            }

            let currentSection = document.querySelectorAll('section')[index];
            currentSection.style.display = 'none';

            if (index === 2) {
                document.querySelector('#results').style.display = 'block';

                document.querySelector('#results h1').textContent = countAnswers === 3
                    ? 'You are recognized as top JavaScript fan!'
                    : `You have ${countAnswers} right answers`;
            } else {
                let nextSection = document.querySelectorAll('section')[++index];
                nextSection.style.display = 'block';
            }
    }));
}