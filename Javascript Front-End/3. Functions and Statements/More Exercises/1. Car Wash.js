function carWash(commands) {
    let actions = {
        "soap": (x) => x + 10,
        "water": (x) => x + x * 0.2,
        "vacuum cleaner": (x) => x + x * 0.25,
        "mud": (x) => x - x * 0.1,
    };

    let value = 0;

    for (let i = 0; i < commands.length; i++) {
        let command = commands[i];
        value = actions[command](value);
    }

    console.log(`The car is ${value.toFixed(2)}% clean.`);
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water']); // The car is 39.00% clean.
carWash(["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"]); // The car is 13.12% clean.