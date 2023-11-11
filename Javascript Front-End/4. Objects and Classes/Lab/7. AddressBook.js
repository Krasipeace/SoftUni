function addressBook(input) {
    let addressBook = {};

    for (let line of input) {
        let [name, address] = line.split(':');
        addressBook[name] = address;
    }

    let sorted = Object.entries(addressBook);
    sorted.sort((a, b) => a[0].localeCompare(b[0]));  // sorted by name ASC

    for (let [name, address] of sorted) {
        console.log(`${name} -> ${address}`);
    }
}

addressBook(['Tim:Doe Crossing', 'Bill:Nelson Place', 'Peter:Carlyle Ave', 'Bill:Ornery Rd']);
// Bill -> Ornery Rd
// Peter -> Carlyle Ave
// Tim -> Doe Crossing