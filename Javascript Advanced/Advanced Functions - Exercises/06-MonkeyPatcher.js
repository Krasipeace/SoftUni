function call(input) {
    let post = this;

    switch (input) {
        case 'upvote':
            post.upvotes++;
            break;
        case 'downvote':
            post.downvotes++;
            break;
        case 'score':
            return score(post);
    }

    function score(post) {
        let upvotes = post.upvotes;
        let downvotes = post.downvotes;
        let totalVotes = upvotes + downvotes;
        let balance = upvotes - downvotes;
        let rating = '';

        if (totalVotes < 10) {
            rating = 'new';
        } else if (upvotes > totalVotes * 0.66) {
            rating = 'hot';
        } else if (balance >= 0 && (upvotes > 100 || downvotes > 100)) {
            rating = 'controversial';
        } else if (balance < 0) {
            rating = 'unpopular';
        } else {
            rating = 'new';
        }

        if (totalVotes > 50) {
            let votesToAdd = Math.ceil(Math.max(upvotes, downvotes) * 0.25);

            upvotes += votesToAdd;
            downvotes += votesToAdd;
        }

        return [upvotes, downvotes, balance, rating];
    }
}
