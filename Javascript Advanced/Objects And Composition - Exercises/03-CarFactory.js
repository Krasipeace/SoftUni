function carFactory(input) {
    const car = {
        model: input.model,
        engine: (
            Number(input.power),
            Number(input.volume)
        ),
        carriage: (
            input.color,
            input.type
        ),
        wheels: Number(input.wheelsize)
    };

    if (input.power <= 90) {
        car.engine = { power: 90, volume: 1800 };
    } else if (input.power <= 120) {
        car.engine = { power: 120, volume: 2400 };
    } else {
        car.engine = { power: 200, volume: 3500 };
    }

    car.carriage = { type: input.carriage, color: input.color };

    if (input.wheelsize % 2 === 0) {
        input.wheelsize--;
    }

    car.wheels = [input.wheelsize, input.wheelsize, input.wheelsize, input.wheelsize];

    return car;
}

console.log(carFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));
// {
//     model: 'VW Golf II',
//     engine: { power: 90, volume: 1800 },
//     carriage: { type: 'hatchback', color: 'blue' },
//     wheels: [ 13, 13, 13, 13 ]
// }