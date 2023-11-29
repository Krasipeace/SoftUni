function solve() {
    let table = document.querySelector('table');
    let checkBtn = document.getElementsByTagName('button')[0];
    let clearBtn = document.getElementsByTagName('button')[1];
    let result = document.querySelector('#check > p');

    checkBtn.addEventListener('click', check);
    clearBtn.addEventListener('click', clear);

    function check() {
        let matrix = [];
        let isValid = true;

        for (let row = 0; row < 3; row++) {
            matrix[row] = [];
            for (let col = 0; col < 3; col++) {
                let cell = document.querySelector(`#exercise > table > tbody > tr:nth-child(${row + 1}) > td:nth-child(${col + 1}) > input`);
                matrix[row][col] = cell.value;
            }
        }

        for (let row = 0; row < 3; row++) {
            let rowSum = matrix[row].reduce((a, b) => Number(a) + Number(b), 0);
            let colSum = matrix.map((x) => x[row]).reduce((a, b) => Number(a) + Number(b), 0);

            if (rowSum !== 6 || colSum !== 6) {
                isValid = false;
                break;
            }
        }

        if (isValid) {
            result.textContent = 'You solve it! Congratulations!';
            result.style.color = 'green';
            table.style.border = '2px solid green';
        } else {
            result.textContent = 'NOP! You are not done yet...';
            result.style.color = 'red';
            table.style.border = '2px solid red';
        }
    }

    function clear() {
        let cells = Array.from(document.querySelectorAll('input'));

        cells.forEach(cell => cell.value = '');
        result.textContent = '';
        table.style.border = 'none';
    }
}