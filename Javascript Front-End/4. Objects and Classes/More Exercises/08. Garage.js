function storeCarsInGarage(arrStrings) {
    let garages = [];

    for (let line of arrStrings) {
        let [garage, carInfo] = line.split(' - ');
        let currentGarage = getGarage(garages, garage);
        addCarToGarage(currentGarage, carInfo);
    }

    printResult(garages);

    function getGarage(garages, garage) {
        let currentGarage = garages.find(g => g.garage === garage);

        if (!currentGarage) {
            currentGarage = { garage: garage, cars: [] };
            garages.push(currentGarage);
        }

        return currentGarage;
    }

    function addCarToGarage(garage, carInfo) {
        garage.cars.push(carInfo);
    }

    function printResult(garages) {
        for (let info of garages) {
            console.log(`Garage № ${info.garage}`);
            for (let carInfo of info.cars) {
                console.log(`--- ${carInfo.replace(/: /g, ' - ')}`);
            }
        }
    }
}

storeCarsInGarage([
    '1 - color: blue, fuel type: diesel',
    '1 - color: red, manufacture: Audi',
    '2 - fuel type: petrol',
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'
]);
// Garage № 1
// --- color - blue, fuel type - diesel
// --- color - red, manufacture - Audi
// Garage № 2
// --- fuel type - petrol
// Garage № 4
// --- color - dark blue, fuel type - diesel, manufacture - Fiat
storeCarsInGarage([
    '1 - color: green, fuel type: petrol',
    '1 - color: dark red, manufacture: WV',
    '2 - fuel type: diesel',
    '3 - color: dark blue, fuel type: petrol'
]);
// Garage № 1
// --- color - green, fuel type - petrol
// --- color - dark red, manufacture - WV
// Garage № 2
// --- fuel type - diesel
// Garage № 3
// --- color - dark blue, fuel type - petrol