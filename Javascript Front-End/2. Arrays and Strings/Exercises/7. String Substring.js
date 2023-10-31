function solve(word, text) {
    const words = text.split(' ');
    const found = words.find(w => w.toLowerCase() === word.toLowerCase());

    console.log(found ? word : `${word} not found!`);
}

solve('javascript', 'JavaScript is the best programming language') // javascript
solve('python', 'JavaScript is the best programming language') // python not found!