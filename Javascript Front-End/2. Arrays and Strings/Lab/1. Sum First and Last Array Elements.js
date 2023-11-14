function sumFirstAndLastElementsOfArray(inputNumbers) {
    let firstNumber = Number(inputNumbers[0]);
    let lastNumber = Number(inputNumbers[inputNumbers.length - 1]);
    let sum = firstNumber + lastNumber;

    console.log(sum);
}

sumFirstAndLastElementsOfArray(['20', '30', '40']); // 60
sumFirstAndLastElementsOfArray(['5', '10']); // 15