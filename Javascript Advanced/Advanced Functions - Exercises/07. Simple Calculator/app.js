function calculator() {
    let inputNumOne;
    let inputNumTwo;
    let output;

    let init = (first, second, result) => {
        inputNumOne = document.querySelector(first);
        inputNumTwo = document.querySelector(second);
        output = document.querySelector(result);
    };

    let add = () => {
        output.value = Number(inputNumOne.value) + Number(inputNumTwo.value);
    };

    let subtract = () => {
        output.value = Number(inputNumOne.value) - Number(inputNumTwo.value);
    };

    return {
        init,
        add,
        subtract
    };
}

let calculate = calculator();
calculate.init('#num1', '#num2', '#result');