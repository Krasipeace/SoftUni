function functionalSum(input) {
    let sum = 0;
    sum += input;

    let add = num => {
        sum += num;

        return add;
    };

    add.toString = function () {
        return sum;
    };

    return add;
}

console.log(functionalSum(1)(6)(-3).toString()); // 4