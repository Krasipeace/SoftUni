function convertToUpperCase(text) {
    return console.log(text
        .match(/\w+/g)
        .map(word => word.toUpperCase())
        .join(', '));
}

convertToUpperCase('Hi, how are you?'); // HI, HOW, ARE, YOU
convertToUpperCase('hello'); // HELLO