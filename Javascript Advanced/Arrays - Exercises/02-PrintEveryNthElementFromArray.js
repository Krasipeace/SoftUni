function printEveryNthElementFromArray(input, step) {   
    let newArray = [];
    
    for (let i = 0; i < input.length; i += step) {
        newArray.push(input[i]);
    }

    return newArray;
}

console.log(printEveryNthElementFromArray(['5', '20', '31', '4', '20'], 2)); // [ '5', '31', '20' ]