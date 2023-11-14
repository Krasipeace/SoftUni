function rotateArray (arrayNumbers, rotations) {
    for (let i = 0; i < rotations; i++) {
        const firstElement = arrayNumbers.shift();
        arrayNumbers.push(firstElement);
    }

    return arrayNumbers.join(' ');
}

console.log(rotateArray(['2', '4', '15', '31'], 5)) // 4 15 31 2
