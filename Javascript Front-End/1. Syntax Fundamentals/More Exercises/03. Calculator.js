function calculator(num1, operator, num2) {
    const operations = {
      '+': (num1, num2) => num1 + num2,
      '-': (num1, num2) => num1 - num2,
      '*': (num1, num2) => num1 * num2,
      '/': (num1, num2) => num1 / num2
    };
  
    const operation = operations[operator];
    if (!operation) {
      console.log('Invalid operator');
      return;
    }
  
    const result = operation(num1, num2);
    console.log(result.toFixed(2));
}

calculator(5, '+', 10); // 15.00
calculator(25.5, '-', 3); // 22.50