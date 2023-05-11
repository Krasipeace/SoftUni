function orbit(input) {
    let [width, height, starRow, starCol] = input; // rows/cols/starPosX/starPosY
    let starField = [];

    for (let i = 0; i < width; i++) {
        starField.push([]);
    }

    for (let row = 0; row < starField.length; row++) {
        for (let col = 0; col < height; col++) {
            starField[row][col] = Math.max(Math.abs(row - starRow), 
                                  Math.abs(col - starCol)) + 1;
        }
    }

    console.log(starField.map(row => row.join(" ")).join("\n"));
}

orbit([4, 4, 0, 0]); 
console.log();
orbit([5, 5, 2, 2]);
console.log();
orbit([3, 3, 2, 2]);