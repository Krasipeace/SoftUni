function wordsUppercase(input) {
    let pattern = input.match(/\b\w+\b/g);
    
    let upperWords = pattern.map(word => word.toUpperCase());

    console.log(upperWords.join(", "));
}

wordsUppercase("Hi, how are you?"); // HI, HOW, ARE, YOU