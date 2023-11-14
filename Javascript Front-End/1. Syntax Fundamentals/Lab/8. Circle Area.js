function getCircleArea(input) {
    if (typeof input === 'number') {
        let result = Math.PI * input * input;
        console.log(result.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof input}.`);
    }
}

getCircleArea(5); // 78.54
getCircleArea('name'); // We can not calculate the circle area, because we receive a string.