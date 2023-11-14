// A perfect number is a positive integer that is equal to the sum of its proper positive divisors.
function isPerfectNumber(number) {
    let sum = 0;
    for (let i = 1; i <= number / 2; i++) {
        number % i === 0 ? sum += i : sum;
    }
    return sum === number ? 'We have a perfect number!' : 'It\'s not so perfect.';
}

console.log(isPerfectNumber(6)); // We have a perfect number!
console.log(isPerfectNumber(28)); // We have a perfect number!
console.log(isPerfectNumber(1236498)); // It's not so perfect.