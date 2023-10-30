function solve(text, wordToSearch) {
    const words = text.split(' ');
    const count = words.filter(w => w === wordToSearch).length;

    console.log(count);
}

solve("This is a word and it also is a sentence", "is"); // 2
solve("This is a word and it also is a sentence", "word"); // 1