function solve(text) {
    return console.log(text
        .match(/\w+/g)
        .map(word => word.toUpperCase())
        .join(', '));
}

solve('Hi, how are you?'); // HI, HOW, ARE, YOU
solve('hello'); // HELLO