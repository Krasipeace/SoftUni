function piccolo(input) {
    let parking = {};

    for (let car of input) {
        let [direction, number] = car.split(', ');

        switch (direction) {
            case 'IN':
                parking[number] = 1;
                break;
            case 'OUT':
                delete parking[number];
                break;
        }
    }

    let sorted = Object.entries(parking).sort((a, b) => a[0].localeCompare(b[0])); // number ASC

    sorted.length > 0
        ? sorted.forEach(car => console.log(car[0]))
        : console.log('Parking Lot is Empty');
}

piccolo([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);
// CA2822UU
// CA2844AA
// CA9876HH
// CA9999TT
piccolo([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'OUT, CA1234TA'
]);
// Parking Lot is Empty