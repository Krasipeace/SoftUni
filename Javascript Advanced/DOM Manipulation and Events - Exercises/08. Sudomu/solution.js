function solve() {
    let [checkButton, clearButton] = document.querySelectorAll('button');
    let board = document.getElementsByTagName('table')[0];
    let message = document.querySelector('#check p');

    checkButton.addEventListener('click', check);
    clearButton.addEventListener('click', clear);

    function check() {
        let boardTable = Array
            .from(document.querySelectorAll('tbody tr'))
            .map(row => Array.from(row.querySelectorAll('input'))
                .map(x => Number(x.value)));

        solveBoard(boardTable);
    }

    function clear() {
        Array
            .from(board.querySelectorAll('input'))
            .map(x => x.value = '');

        message.textContent = '';
        board.style.border = 'none';
    }

    function solveBoard(boardTable) {
        let isSolved = isValid(boardTable);

        board.style.border = isSolved
            ? '2px solid green'
            : '2px solid red';
        message.style.color = isSolved
            ? 'green'
            : 'red';
        message.textContent = isSolved
            ? 'You solve it! Congratulations!'
            : 'NOP! You are not done yet...';
    }

    function isValid(line) {
        for (let row = 0; row < line.length; row++) {
            let rowData = getChecker(line);
            let colData = getChecker(line);

            for (let col = 0; col < line[row].length; col++) {
                let currRowCell = line[row][col];
                let currColCell = line[col][row];
                rowData[currRowCell]++;
                colData[currColCell]++;
            }

            let rowValues = Object.values(rowData);
            let colValues = Object.values(colData);
            let isValidRow = rowValues.some(x => x !== 1);
            let isValidCol = colValues.some(x => x !== 1);

            if (rowValues.length > line.length ||
                colValues.length > line.length ||
                isValidRow ||
                isValidCol) {
                return false;
            }
        }

        return true;
    }

    function getChecker(arr) {
        let obj = {};

        for (let i = 0; i < arr.length; i++) {
            obj[i + 1] = 0;
        }

        return obj;
    }
}