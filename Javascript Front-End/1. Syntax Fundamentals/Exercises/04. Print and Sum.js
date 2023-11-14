function printAndSum(startNumber, endNumber) {
    let sum = 0;
    let numbersRange = '';

    if (startNumber <= endNumber) {
        for (let i = startNumber; i <= endNumber; i++) {
            sum += i;
            numbersRange += i + ' ';
        }
    } else {
        for (let i = startNumber; i >= endNumber; i--) {
            sum += i;
            numbersRange += i + ' ';
        }
    }
    console.log(numbersRange);
    console.log(`Sum: ${sum}`);
}

printAndSum(5, 10); // 5 6 7 8 9 10 Sum: 45
printAndSum(-5, 5); // -5 -4 -3 -2 -1 0 1 2 3 4 5 Sum: 0