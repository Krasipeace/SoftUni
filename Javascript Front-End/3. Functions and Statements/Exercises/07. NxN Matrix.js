function printMatrixNxN(number) {
    let matrix = '';

    for (let row = 0; row < number; row++) {
        for (let col = 0; col < number; col++) {
            matrix += `${number} `;
        }
        matrix += '\n';
    }

    return matrix;
}

console.log(printMatrixNxN(3)); 
// 3 3 3
// 3 3 3
// 3 3 3 
console.log(printMatrixNxN(7));
// 7 7 7 7 7 7 7
// 7 7 7 7 7 7 7
// 7 7 7 7 7 7 7
// 7 7 7 7 7 7 7
// 7 7 7 7 7 7 7
// 7 7 7 7 7 7 7
// 7 7 7 7 7 7 7
console.log(printMatrixNxN(2));
// 2 2
// 2 2