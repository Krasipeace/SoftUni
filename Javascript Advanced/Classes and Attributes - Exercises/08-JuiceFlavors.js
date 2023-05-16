function juiceFlavors(input) {

    let juices = [];
    let bottles = [];

    class Juice {
        constructor(name) {
            this.name = name;
            this.quantity = 0;
            this.bottles = 0;
        }
    }

    getBottles();

    return getResult();

    function getBottles() {
        for (let flavor of input) {
            let flavors = flavor.split(' => ');
            let name = flavors[0];
            let quantity = Number(flavors[1]);

            if (!juices.some(j => j.name === name)) {
                juices.push(new Juice(name));
            }

            let currentQuantity = juices.find(j => j.name == name);
            currentQuantity.quantity += quantity;

            createBottle(currentQuantity);
        }
    }

    function createBottle(currentQuantity) {
        while (currentQuantity.quantity >= 1000) {
            currentQuantity.bottles++;
            currentQuantity.quantity -= 1000;

            if (!bottles.some(j => j.name === currentQuantity.name)) {
                bottles.push(currentQuantity);
            }
        }
    }

    function getResult() {
        let result = '';

        for (let bottle of bottles) {
            result += `${bottle.name} => ${bottle.bottles}\n`;
        }

        return result.trimEnd();
    }
}

console.log(juiceFlavors(['Orange => 2000', 'Peach => 1432', 'Banana => 450', 'Peach => 600', 'Strawberry => 549'])); // Orange => 2 Peach => 2