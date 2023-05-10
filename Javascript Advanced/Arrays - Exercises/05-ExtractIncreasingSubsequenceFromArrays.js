function extractISFA (input) {
    let subsequence = [];
    let biggest = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < input.length; i++) {     
        if (input[i] >= biggest) {
            subsequence.push(input[i]);
            biggest = input[i];
        }
    }

    return subsequence;
}

console.log(extractISFA([1, 3, 8, 4, 10, 12, 3, 2, 24])); // [ 1, 3, 8, 10, 12, 24 ]