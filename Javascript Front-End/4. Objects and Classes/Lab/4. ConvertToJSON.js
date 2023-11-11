function convertToJSON(name, lastName, hairColor) {
    let person = {
        name,
        lastName,
        hairColor
    }
    console.log(JSON.stringify(person));
}

convertToJSON('George', 'Jones', 'Brown');
convertToJSON('Peter', 'Smith', 'Blond');