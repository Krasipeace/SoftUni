function fibonacci () {
    let first = 0;
    let second = 1;

    return function () {
        let result = first + second;
        first = second;
        second = result;

        return first;
    }
}

let fib = fibonacci();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
console.log(fib()); // 21