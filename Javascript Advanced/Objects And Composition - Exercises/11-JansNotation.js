function jansNotation(input) {
    let numbers = [];
    let result = 0;

    for (let i = 0; i < input.length; i++) {
        if (Number(input[i])) {
            numbers.push(Number(input[i]));
        } else {
            let operator = input[i];
            let numTwo = numbers.pop();
            let numOne = numbers.pop();

            if (numOne === undefined || numTwo === undefined) {
                console.log("Error: not enough operands!");

                return;
            }

            switch (operator) {
                case "+":
                    result = numOne + numTwo;
                    numbers.push(result);
                    break;
                case "-":
                    result = numOne - numTwo;
                    numbers.push(result);
                    break;
                case "*":
                    result = numOne * numTwo;
                    numbers.push(result);
                    break;
                case "/":
                    result = numOne / numTwo;
                    numbers.push(result);
                    break;
            }
        }
    }

    if (numbers.length > 1) {
        console.log("Error: too many operands!");
    } else {
        console.log(numbers[0]);
    }
}

jansNotation([3, 4, "+"]); // 7
jansNotation([5, 3, 4, "*", "-"]); // -7
jansNotation([7, 33, 8, "-"]); // Error: too many operands!
jansNotation([15, "/"]); // Error: not enough operands!
jansNotation([31, 2, "+", 11, "/"]); // 3