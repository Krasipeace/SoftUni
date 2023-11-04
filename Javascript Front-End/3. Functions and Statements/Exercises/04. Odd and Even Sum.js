function oddAndEvenSumOfDigits(number) {
    let oddSum = 0;
    let evenSum = 0;
    let numberAsString = number.toString();

    for (let i = 0; i < numberAsString.length; i++) {
        let currentDigit = Number(numberAsString[i]);

        currentDigit % 2 === 0 ? evenSum += currentDigit : oddSum += currentDigit;
    }

    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`;
}

console.log(oddAndEvenSumOfDigits(1000435)); //Odd sum = 9, Even sum = 4
console.log(oddAndEvenSumOfDigits(3495892137259234)); //Odd sum = 54, Even sum = 22