function subtraction() {
    let output = document.getElementById("result");
    let firstNumber = Number(document.getElementById("firstNumber").value);
    let secondNumber = Number(document.getElementById("secondNumber").value);
    let subtraction = firstNumber - secondNumber;
    output.textContent = subtraction;
}
