function rotateArray(input, rotations) {
    for (let i = 0; i < rotations; i++) {
        let lastElement = input.pop();
        input.unshift(lastElement);
    }

    console.log(input.join(" "));
}

rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 15) // Orange Coconut Apple Banana