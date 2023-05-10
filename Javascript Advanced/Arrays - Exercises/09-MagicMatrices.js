function magicMatrices(inputMatrix) {
    let sum = inputMatrix[0].reduce((accumulator, currentValue) => accumulator + currentValue)
    let isMagic = true

    for (let i = 0; i < inputMatrix.length; i++) {
        let rowSum = inputMatrix[i].reduce((accumulator, currentValue) => 
            accumulator + currentValue)

        let colSum = inputMatrix.map((num) => 
            num[i]).reduce((accumulator, currentValue) => 
                accumulator + currentValue)

        if (rowSum !== sum || colSum !== sum) {
            isMagic = false
            break;
        }
    }

    console.log(isMagic)
}

magicMatrices([[4, 5, 6],
               [6, 5, 4],
               [5, 5, 5]]) // true
console.log()
magicMatrices([[11, 32, 45],
               [21, 0, 1],
               [21, 1, 1]]) // false