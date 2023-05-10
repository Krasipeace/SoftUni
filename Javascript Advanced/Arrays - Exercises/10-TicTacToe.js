function ticTacToe(input) {

    let field = [[false, false, false],
                [false, false, false],
                [false, false, false]];

    let winner = false;
    let isDraw = false;

    for (let i = 0; i < input.length; i++) {
        let [row, col] = input[i].split(" ").map(Number);

        if (field[row][col] !== false) {
            console.log("This place is already taken. Please choose another!");
            continue;
        }

        if (i % 2 === 0) {
            field[row][col] = "X";
        } else {
            field[row][col] = "O";
        }

        if (checkForWinner(field)) {
            winner = true;
            break;
        }

        if (checkForDraw(field)) {
            isDraw = true;
            break;
        }
    }

    if (winner) {
        if (input.length % 2 === 0) {
            console.log("Player X wins!");
        } else {
            console.log("Player O wins!");
        }
    } else if (isDraw) {
        console.log("The game ended! Nobody wins :(");
    }

    printField(field); 
    
    function checkForWinner(field) {
        let isWinner = false;
    
        for (let i = 0; i < field.length; i++) {
            let row = field[i];
            let col = field.map((num) => num[i]);
    
            if (row.every((num) => num === "X") || col.every((num) => num === "X")) {
                isWinner = true;
                break;
            }
    
            if (row.every((num) => num === "O") || col.every((num) => num === "O")) {
                isWinner = true;
                break;
            }
        }
    
        let diagonalOne = field.map((num, index) => num[index]);
        let diagonalTwo = field.map((num, index) => num[num.length - 1 - index]);
    
        if (diagonalOne.every((num) => num === "X") || diagonalTwo.every((num) => num === "X")) {
            isWinner = true;
        }
    
        if (diagonalOne.every((num) => num === "O") || diagonalTwo.every((num) => num === "O")) {
            isWinner = true;
        }
    
        return isWinner;
    }
    
    function checkForDraw(field) {
        let isDraw = true;
    
        for (let i = 0; i < field.length; i++) {
            let row = field[i];
    
            if (row.some((num) => num === false)) {
                isDraw = false;
                break;
            }
        }
    
        return isDraw;
    }
    
    function printField(field) {
        for (let i = 0; i < field.length; i++) {
            console.log(field[i].join("\t"));
        }
    }
}

ticTacToe(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]); // Player O wins!

console.log();

ticTacToe(["0 0",
"0 0",
"1 1",
"0 1",
"1 2",
"0 2",
"2 2",
"1 2",
"2 2",
"2 1"]); // Player X wins!

console.log();

ticTacToe(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]); // The game ended! Nobody wins :(