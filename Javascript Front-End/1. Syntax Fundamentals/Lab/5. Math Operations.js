function executeMathOperation(numberOne, numberTwo, operator) {
  const operations = {
    '+': (numberOne, numberTwo) => numberOne + numberTwo,
    '-': (numberOne, numberTwo) => numberOne - numberTwo,
    '*': (numberOne, numberTwo) => numberOne * numberTwo,
    '/': (numberOne, numberTwo) => numberOne / numberTwo,
    '%': (numberOne, numberTwo) => numberOne % numberTwo,
    '**': (numberOne, numberTwo) => numberOne ** numberTwo
  };

  const operation = operations[operator];
  const result = operation(numberOne, numberTwo);

  console.log(result);
}

executeMathOperation(5, 6, '+'); // 11
executeMathOperation(3, 5.5, '*'); // 16.5
executeMathOperation(4, 2, '**'); // 16
executeMathOperation(3, 5, '/'); // 0.6
executeMathOperation(5, 3, '%'); // 2
executeMathOperation(5, 3, '-'); // 2