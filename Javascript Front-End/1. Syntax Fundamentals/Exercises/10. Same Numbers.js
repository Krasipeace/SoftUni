function solve(number) {
    let sum = 0;
    let digits = number.toString();

    for (let i = 0; i < digits.length; i++) {
        sum += Number(digits[i]);
    }

    console.log(sum / digits.length === Number(digits[0]) ? 'true' : 'false');
    console.log(sum);
}

solve(2222222); // true 14
solve(1234); // false 10