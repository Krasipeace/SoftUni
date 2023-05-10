function sameNumbers(number) {
    let numString = number.toString();
    let sum = 0;
    let isSame = true;

    for (let i = 0; i < numString.length; i++) {
        sum += Number(numString[i]);
        if (i > 0 && numString[i] != numString[i - 1]) {
            isSame = false;
        }
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(2222222); // true, 14
sameNumbers(1234); // false, 10