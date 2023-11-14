function sumDigits(number) {
    let sum = 0;
    let digits = number.toString();

    for (let i = 0; i < digits.length; i++) {
        sum += Number(digits[i]);
    }

    console.log(sum);
}

sumDigits(245678); // 32
sumDigits(97561); // 28
sumDigits(543); // 12