function solve(input) {
    let n = Number(input.shift());
    let baristas = {};

    for (let i = 0; i < n; i++) {
        let [name, shift, ...coffeeTypes] = input.shift().split(' ');
        coffeeTypes = coffeeTypes.join(' ').split(',');
        baristas[name] = { shift, coffeeTypes };
    }

    while (input.length > 0) {
        let command = input.shift().split(' / ');
        if (command[0] === "Closed") break;

        let [action, baristaName, shift, coffeeType] = command;
        if (action === "Prepare") {
            if (baristas[baristaName] && baristas[baristaName].shift === shift && baristas[baristaName].coffeeTypes.includes(coffeeType)) {
                console.log(`${baristaName} has prepared a ${coffeeType} for you!`);
            } else {
                console.log(`${baristaName} is not available to prepare a ${coffeeType}.`);
            }

        } else if (action === "Change Shift") {
            let newShift = shift;

            if (baristas[baristaName]) {
                baristas[baristaName].shift = newShift;
                console.log(`${baristaName} has updated his shift to: ${newShift}`);
            }

        } else if (action === "Learn") {
            let newCoffeeType = shift;

            if (baristas[baristaName]) {
                if (baristas[baristaName].coffeeTypes.includes(newCoffeeType)) {
                    console.log(`${baristaName} knows how to make ${newCoffeeType}.`);
                } else {
                    baristas[baristaName].coffeeTypes.push(newCoffeeType);
                    console.log(`${baristaName} has learned a new coffee type: ${newCoffeeType}.`);
                }
            }

        }
    }

    for (let barista in baristas) {
        console.log(`Barista: ${barista}, Shift: ${baristas[barista].shift}, Drinks: ${baristas[barista].coffeeTypes.join(', ')}`);
    }
}

solve(['3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed']);