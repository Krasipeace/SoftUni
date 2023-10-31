function solve(words, text) {
    const specialWord = words.split(', ');
    const allWords = text.split(' ');
  
    for (let i = 0; i < allWords.length; i++) {
        if (allWords[i].includes('*')) {
            const word = specialWord.find(word => word.length === allWords[i].length);
            if (word) {
                allWords[i] = word;
            }
        }
    }
  
    return allWords.join(' ');
}

console.log(solve('great, learning', 'softuni is ***** place for ******** new programming languages')); // softuni is great place for learning new programming languages