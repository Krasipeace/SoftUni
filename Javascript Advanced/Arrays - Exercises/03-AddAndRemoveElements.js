function addAndRemoveElements(input) {
    let array = [];

    for (let i = 0; i < input.length; i++) {
        if (input[i] === "add") {
            array.push(i + 1);
        } else if (input[i] === "remove") {
            array.pop();
        }
    }

    if (array.length === 0) {
        console.log("Empty");
    } else {
        console.log(array.join("\n"));
    }
}

addAndRemoveElements(['add', 'add', 'add', 'add']); // 1 2 3 4
console.log();
addAndRemoveElements(['remove', 'remove', 'remove']); // Empty