function solve(elements) {
    const evenSum = elements
        .filter(num => num % 2 === 0)
        .reduce((acc, curr) => acc + curr, 0);
    const oddSum = elements
        .filter(num => num % 2 !== 0)
        .reduce((acc, curr) => acc + curr, 0);

    console.log(evenSum - oddSum);
}

solve([1, 2, 3, 4, 5, 6]) // 3
solve([3, 5, 7, 9]) // -24
solve([2, 4, 6, 8, 10]) // 30