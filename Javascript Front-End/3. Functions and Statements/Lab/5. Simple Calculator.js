function solve(firstNumber, secondNumber, operator) {
    const operations = {
        'add': (a, b) => a + b,
        'subtract': (a, b) => a - b,
        'multiply': (a, b) => a * b,
        'divide': (a, b) => a / b
    };

    return operations[operator](firstNumber, secondNumber);
}

console.log(solve(5, 5, 'multiply')); //25
console.log(solve(40, 8, 'divide')); //5
console.log(solve(2, 2, 'add')); //4
console.log(solve(2, 2, 'subtract')); //0