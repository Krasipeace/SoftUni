function addAndSubtract(numOne, numTwo, numThree) {
    function sum(numOne, numTwo) {
        return numOne + numTwo;
    }

    function subtract(numOne, numTwo) {
        return numOne - numTwo;
    }

    return subtract(sum(numOne, numTwo), numThree);
}

console.log(addAndSubtract(23, 6, 10)); // 19
console.log(addAndSubtract(1, 17, 30)); // -12
console.log(addAndSubtract(42, 58, 100)); // 0