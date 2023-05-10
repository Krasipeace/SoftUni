function sortingNumbers(input) {
    let sortedNumbers = [];
    input.sort((first, second) => first - second);

    while (input.length > 0) {
        sortedNumbers.push(input.shift());
        sortedNumbers.push(input.pop());
    }

    return sortedNumbers.filter(num => num != undefined);
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])); // -3, 65, 1, 63, 3, 56, 18, 52, 31, 48