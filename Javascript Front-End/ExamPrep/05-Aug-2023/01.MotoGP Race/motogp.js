function solve(input) {
    let n = parseInt(input[0]);
    let riders = {};

    for (let i = 1; i <= n; i++) {
        let [name, fuelCapacity, position] = input[i].split('|');
        riders[name] = createRider(name, parseFloat(fuelCapacity), parseInt(position));
    }

    let index = n + 1;
    while (index < input.length && input[index] !== "Finish") {
        let [action, riderName, fuel, position] = input[index].split(' - ');

        if (action === "StopForFuel") {
            stopForFuel(riders[riderName], parseFloat(fuel), parseInt(position));
        } else if (action === "Overtaking") {
            overtake(riders[riderName], riders[fuel]);
        } else if (action === "EngineFail") {
            engineFail(riders[riderName], parseInt(fuel));
            delete riders[riderName];
        }

        index++;
    }

    for (let riderName in riders) {
        printFinalPosition(riders[riderName]);
    }

    function createRider(name, fuelCapacity, position) {
        return {
            name,
            fuelCapacity,
            position
        };
    }

    function stopForFuel(rider, minFuel, newPos) {
        if (rider.fuelCapacity < minFuel) {
            console.log(`${rider.name} stopped to refuel but lost his position, now he is ${newPos}.`);
            rider.position = newPos;
        } else {
            console.log(`${rider.name} does not need to stop for fuel!`);
        }
    }

    function overtake(rider1, rider2) {
        if (rider1.position < rider2.position) {
            [rider1.position, rider2.position] = [rider2.position, rider1.position];
            console.log(`${rider1.name} overtook ${rider2.name}!`);
        }
    }

    function engineFail(rider, lapsLeft) {
        console.log(`${rider.name} is out of the race because of a technical issue, ${lapsLeft} laps before the finish.`);
    }

    function printFinalPosition(rider) {
        console.log(`${rider.name}`);
        console.log(`  Final position: ${rider.position}`);
    }
}
