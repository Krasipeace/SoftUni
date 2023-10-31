function solve (arrayNumbers, step) {
    const result = [];
    for (let i = 0; i < arrayNumbers.length; i += step) {
        result.push(arrayNumbers[i]);
    }

    return result;
}

console.log(solve(['5', '20', '31', '4', '20'], 2)) // [ '5', '31', '20' ]