function printPhoneBook(input) {
    let phoneBook = {};

    for (let line of input) {
        let [name, phone] = line.split(' ');
        phoneBook[name] = phone;
    }

    for (let name in phoneBook) {
        console.log(`${name} -> ${phoneBook[name]}`);
    }
}

printPhoneBook(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344']); // Tim -> 0876566344 Peter -> 0877547887 Bill -> 0896543112