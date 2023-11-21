function solve() {
    let input = document.getElementById('input');
    let selectMenuTo = document.getElementById('selectMenuTo');
    let button = document.getElementsByTagName('button')[0];
    let result = document.getElementById('result');

    let options = [
        createOption('binary', 'Binary'),
        createOption('hexadecimal', 'Hexadecimal')
    ];

    getOptions(selectMenuTo, options);

    button.addEventListener('click', () => {
        let base = selectMenuTo.value === 'binary' ? 2 : 16;
        result.value = convertNumber(input.value, base).toUpperCase();
    });

    function createOption(value, text) {
        let option = document.createElement('option');
        option.value = value;
        option.textContent = text;

        return option;
    }

    function getOptions(select, options) {
        options.forEach(option => select.appendChild(option));
    }

    function convertNumber(input, base) {
        return Number(input).toString(base);
    }
}