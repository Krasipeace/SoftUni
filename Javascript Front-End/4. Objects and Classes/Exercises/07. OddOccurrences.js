function oddOccurrences(input) {
    let words = input.toLowerCase().split(' ');
    let wordsCount = {};

    for (let word of words) {
        wordsCount[word] = 0;
    }

    for (let word of words) {
        if (wordsCount.hasOwnProperty(word)) {
            wordsCount[word]++;
        }
    }

    let result = [];

    Object.entries(wordsCount)
        .filter(word => word[1] % 2 !== 0)
        .map(word => word[0])
        .forEach(word => result.push(word));
    
    console.log(result.join(' '));
}

oddOccurrences('Java C# Php PHP Java PhP 3 C# 3 1 5 C#'); // c# php 1 5
oddOccurrences('Cake IS SWEET is Soft CAKE sweet Food'); //soft food