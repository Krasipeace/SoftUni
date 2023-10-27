function solve(num1, operator, num2) {
    const operations = {
      '+': (a, b) => a + b,
      '-': (a, b) => a - b,
      '*': (a, b) => a * b,
      '/': (a, b) => a / b
    };
  
    const operation = operations[operator];
    if (!operation) {
      console.log('Invalid operator');
      return;
    }
  
    const result = operation(num1, num2);
    console.log(result.toFixed(2));
}

solve(5, '+', 10); // 15.00
solve(25.5, '-', 3); // 22.50