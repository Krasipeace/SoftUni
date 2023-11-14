function getSimpleCalculation(firstNumber, secondNumber, operator) {
    const operations = {
        'add': (firstNumber, secondNumber) => firstNumber + secondNumber,
        'subtract': (firstNumber, secondNumber) => firstNumber - secondNumber,
        'multiply': (firstNumber, secondNumber) => firstNumber * secondNumber,
        'divide': (firstNumber, secondNumber) => firstNumber / secondNumber
    };

    return operations[operator](firstNumber, secondNumber);
}

console.log(getSimpleCalculation(5, 5, 'multiply')); //25
console.log(getSimpleCalculation(40, 8, 'divide')); //5
console.log(getSimpleCalculation(2, 2, 'add')); //4
console.log(getSimpleCalculation(2, 2, 'subtract')); //0