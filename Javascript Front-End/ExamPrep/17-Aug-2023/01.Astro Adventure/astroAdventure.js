function solve(input) {
    const n = Number(input.shift());
    const astronauts = new Map();

    for (let i = 0; i < n; i++) {
        const [name, oxygen, energy] = input.shift().split(' ');
        astronauts.set(name, { oxygen: Number(oxygen), energy: Number(energy) });
    }

    const printAstronauts = () => {
        for (const [name, astronaut] of astronauts) {
            console.log(`Astronaut: ${name}, Oxygen: ${astronaut.oxygen}, Energy: ${astronaut.energy}`);
        }
    };

    while (input[0] !== 'End') {
        const [action, name, amount] = input.shift().split(' - ');
        const astronaut = astronauts.get(name);

        switch (action) {
            case 'Explore':
                if (astronaut.energy >= amount) {
                    astronaut.energy -= amount;
                    console.log(`${name} has successfully explored a new area and now has ${astronaut.energy} energy!`);
                } else {
                    console.log(`${name} does not have enough energy to explore!`);
                }
                break;
            case 'Refuel':
                const energyBeforeRefuel = astronaut.energy;
                astronaut.energy = Math.min(200, astronaut.energy + Number(amount));
                console.log(`${name} refueled their energy by ${astronaut.energy - energyBeforeRefuel}!`);
                break;
            case 'Breathe':
                const oxygenBeforeBreath = astronaut.oxygen;
                astronaut.oxygen = Math.min(100, astronaut.oxygen + Number(amount));
                console.log(`${name} took a breath and recovered ${astronaut.oxygen - oxygenBeforeBreath} oxygen!`);
                break;
        }
    }

    printAstronauts();
}

solve([
    '3',
    'John 50 120',
    'Kate 80 180',
    'Rob 70 150',
    'Explore - John - 50',
    'Refuel - Kate - 30',
    'Breathe - Rob - 20',
    'End'
]);