function checkMultiplySign(numOne, numTwo, numThree) {
    let negativeNumbers = [numOne, numTwo, numThree].filter(x => x < 0).length;

    return negativeNumbers === 1 || negativeNumbers === 3 ? 'Negative' : 'Positive';
}

console.log(checkMultiplySign(5, 12, -15)); //Negative
console.log(checkMultiplySign(-6, -12, 14)); //Positive
console.log(checkMultiplySign(-1, -2, -3)); //Negative
console.log(checkMultiplySign(-5, 1, 1)); //Negative