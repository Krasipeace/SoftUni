function solve(numberOne, numberTwo, operator) {
    const operations = {
      '+': (a, b) => a + b,
      '-': (a, b) => a - b,
      '*': (a, b) => a * b,
      '/': (a, b) => a / b,
      '%': (a, b) => a % b,
      '**': (a, b) => a ** b
    };
  
    const operation = operations[operator];
    const result = operation(numberOne, numberTwo);

    console.log(result);
}

solve(5, 6, '+'); // 11
solve(3, 5.5, '*'); // 16.5
solve(4, 2, '**'); // 16
solve(3, 5, '/'); // 0.6
solve(5, 3, '%'); // 2
solve(5, 3, '-'); // 2