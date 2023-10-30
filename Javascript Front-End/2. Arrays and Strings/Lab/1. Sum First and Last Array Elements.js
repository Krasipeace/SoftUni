function solve(inputNumbers) {
    let firstNumber = Number(inputNumbers[0]);
    let lastNumber = Number(inputNumbers[inputNumbers.length - 1]);
    let sum = firstNumber + lastNumber;

    console.log(sum);
}

solve(['20', '30', '40']); // 60
solve(['5', '10']); // 15