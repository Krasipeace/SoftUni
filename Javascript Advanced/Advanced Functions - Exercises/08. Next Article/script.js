function getArticleGenerator(articles) {
    let content = document.getElementById('content');

    return function () {
        if (articles.length > 0) {
            let article = document.createElement('article');
            article.textContent = articles.shift();
            content.appendChild(article);
        }
    }
}
