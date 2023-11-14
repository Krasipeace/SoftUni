function extractWordFromText(word, text) {
    const words = text.split(' ');
    const found = words.find(w => w.toLowerCase() === word.toLowerCase());

    console.log(found ? word : `${word} not found!`);
}

extractWordFromText('javascript', 'JavaScript is the best programming language') // javascript
extractWordFromText('python', 'JavaScript is the best programming language') // python not found!