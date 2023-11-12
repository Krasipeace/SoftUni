class Vehicle {
    constructor(type, model, parts, fuel) {
        this.type = type;
        this.model = model;
        this.parts = parts;
        this.parts = {
            engine: this.parts.engine,
            power: this.parts.power,
            quality: this.parts.engine * this.parts.power
        }
        this.fuel = fuel;
    }

    drive(usedFuel) {
        this.fuel -= usedFuel;
    }
}

let parts = { engine: 6, power: 100 };
let vehicle = new Vehicle('a', 'b', parts, 200);
vehicle.drive(100);
console.log(vehicle.fuel);
console.log(vehicle.parts.quality);
console.log("\n");
parts = { engine: 9, power: 500 };
vehicle = new Vehicle('l', 'k', parts, 840);
vehicle.drive(20);
console.log(vehicle.fuel);