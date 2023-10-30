function solve(number, elements) {
    let result = elements.slice(0, number);
    let reverse = result.reverse().join(' ');

    console.log(reverse);
}

solve(3, [10, 20, 30, 40, 50]); // 30 20 10