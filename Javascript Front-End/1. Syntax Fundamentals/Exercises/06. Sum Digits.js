function solve(number) {
    let sum = 0;
    let digits = number.toString();

    for (let i = 0; i < digits.length; i++) {
        sum += Number(digits[i]);
    }

    console.log(sum);
}

solve(245678); // 32
solve(97561); // 28
solve(543); // 12