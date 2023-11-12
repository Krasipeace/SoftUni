function wordsTracker(input) {
    let words = input.shift().split(' ');
    let wordsCount = {};

    for (let word of words) {
        wordsCount[word] = 0;
    }

    for (let word of input) {
        if (wordsCount.hasOwnProperty(word)) {
            wordsCount[word]++;
        }
    }

    Object.entries(wordsCount)
        .sort((a, b) => b[1] - a[1]) // count DESC
        .forEach(word => console.log(`${word[0]} - ${word[1]}`));
}

wordsTracker([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]);
// this - 3
// sentence - 2