function solve(x1, y1, x2, y2) {
    const isValid = (x, y) => Number.isInteger(Math.sqrt(x ** 2 + y ** 2));

    console.log(`{${x1}, ${y1}} to {0, 0} is ${isValid(x1, y1) 
        ? 'valid' 
        : 'invalid'}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${isValid(x2, y2) 
        ? 'valid' 
        : 'invalid'}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${isValid(x2 - x1, y2 - y1) 
        ? 'valid' 
        : 'invalid'}`);
}

solve(3, 0, 0, 4);
solve(2, 1, 1, 1);