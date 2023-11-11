function convertToObject(input) {
    let person = JSON.parse(input);
    for (let key in person) {
        console.log(`${key}: ${person[key]}`);
    }
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');
convertToObject('{"name": "Peter", "age": 35, "town": "Plovdiv"}');