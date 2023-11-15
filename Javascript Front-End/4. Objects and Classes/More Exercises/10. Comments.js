function comments(input) {
    let users = {};
    let articles = {};

    for (let line of input) {
        if (line.includes('user')) {
            let user = line.split(' ')[1];
            addUser(users, user);
        } else if (line.includes('article')) {
            let article = line.split(' ')[1];
            addArticle(articles, article);
        } else {
            addPost(users, articles, line);
        }
    }

    let sortedArticles = sortArticles(articles);
    printComments(articles, sortedArticles);

    function addUser(users, user) {
        users[user] = [];
    }

    function addArticle(articles, article) {
        articles[article] = [];
    }

    function addPost(users, articles, inputLine) {
        let [user, post] = inputLine.split(' posts on ');
        let [article, comment] = post.split(': ');

        if (users.hasOwnProperty(user) && articles.hasOwnProperty(article)) {
            let currentComment = `${article} ${user}: ${comment}`;
            articles[article].push(currentComment);
        }
    }

    function sortArticles(articles) {
        return Object.keys(articles).sort((a, b) => articles[b].length - articles[a].length);
    }

    function printComments(articles, sortedArticles) {
        for (let article of sortedArticles) {
            console.log(`Comments on ${article}`);
            let sortedComments = articles[article].sort((a, b) => a.localeCompare(b));

            for (let sortedComment of sortedComments) {
                let replaceArticleToFromUser = sortedComment.replace(article, 'From user');
                let replaceCommasWithDash = replaceArticleToFromUser.replace(/,/g, ' -');

                console.log(`--- ${replaceCommasWithDash}`);
            }
        }
    }
}

comments([
    'user aUser123', 'someUser posts on someArticle: NoTitle, stupidComment', 'article Books', 'article Movies', 'article Shopping', 'user someUser', 'user uSeR4', 'user lastUser', 'uSeR4 posts on Books: I like books, I do really like them', 'uSeR4 posts on Movies: I also like movies, I really do', 'someUser posts on Shopping: title, I go shopping every day', 'someUser posts on Movies: Like, I also like movies very much'
]);
// Comments on Movies
// --- From user someUser: Like - I also like movies very much
// --- From user uSeR4: I also like movies - I really do
// Comments on Books
// --- From user uSeR4: I like books - I do really like them
// Comments on Shopping
// --- From user someUser: title - I go shopping every day
comments([
    'user Mark', 'Mark posts on someArticle: NoTitle, stupidComment', 'article Bobby', 'article Steven', 'user Liam', 'user Henry', 'Mark posts on Bobby: Is, I do really like them', 'Mark posts on Steven: title, Run', 'someUser posts on Movies: Like'
]);
// Comments on Bobby
// --- From user Mark: Is - I do really like them
// Comments on Steven
// --- From user Mark: title - Run