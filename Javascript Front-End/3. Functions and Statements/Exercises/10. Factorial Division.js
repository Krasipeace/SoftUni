function factorialDivision(numOne, numTwo) {
    function factorial(num) {
        if (num === 0) {
            return 1;
        }

        return num * factorial(num - 1);
    }

    return (factorial(numOne) / factorial(numTwo)).toFixed(2);
}

console.log(factorialDivision(5, 2)); // 60.00
console.log(factorialDivision(6, 2)); // 360.00