function solve(text, wordToCensor) {
    let result = text.replace(wordToCensor, '*'.repeat(wordToCensor.length));

    while (result.includes(wordToCensor)) {
        result = result.replace(wordToCensor, '*'.repeat(wordToCensor.length));
    }

    console.log(result);
}

solve("A small sentence with some words", "small"); // A ***** sentence with some words