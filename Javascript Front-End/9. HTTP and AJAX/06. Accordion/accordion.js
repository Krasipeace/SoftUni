async function solution() {
    const articles = await fetchArticles();
    const main = document.getElementById('main');
    main.innerHTML = '';

    articles.forEach(article => {
        const accordion = createAccordion(article);
        main.appendChild(accordion);
    });

    async function fetchArticles() {
        const response = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');

        return await response.json();
    }

    function createAccordion(article) {
        const accordionDiv = document.createElement('div');
        accordionDiv.classList.add('accordion');

        const headDiv = document.createElement('div');
        headDiv.classList.add('head');
        accordionDiv.appendChild(headDiv);

        const span = document.createElement('span');
        span.textContent = article.title;
        headDiv.appendChild(span);

        const moreButton = document.createElement('button');
        moreButton.classList.add('button');
        moreButton.id = article._id;
        moreButton.textContent = 'More';
        moreButton.addEventListener('click', toggleArticleDetails);
        headDiv.appendChild(moreButton);

        const extraDiv = document.createElement('div');
        extraDiv.classList.add('extra');
        extraDiv.style.display = 'none';
        accordionDiv.appendChild(extraDiv);

        const p = document.createElement('p');
        extraDiv.appendChild(p);

        return accordionDiv;
    }

    async function toggleArticleDetails(event) {
        const button = event.target;
        const accordion = button.parentNode.parentNode;
        const extraDiv = accordion.querySelector('.extra');
        const p = extraDiv.querySelector('p');

        if (extraDiv.style.display === 'none') {
            const article = await fetchArticleDetails(button.id);

            p.textContent = article.content;
            extraDiv.style.display = 'block';
            button.textContent = 'Less';
        } else {
            p.textContent = '';
            extraDiv.style.display = 'none';
            button.textContent = 'More';
        }
    }

    async function fetchArticleDetails(id) {
        const response = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);

        return await response.json();
    }
}

solution();