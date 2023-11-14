function substringFromIndex(word, startIndex, count) {
    let result = word.substr(startIndex, count);

    console.log(result);
}

substringFromIndex("ASentence", 1, 8); // Sentence
substringFromIndex("SkipWord", 4, 7); // Word