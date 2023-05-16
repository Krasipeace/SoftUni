function aeCompany(input) {

    class Car {

        constructor(brand) {
            this.brand = brand;
            this.models = {};
        }

        getCar = (model, cars) => {
            if (!this.models[model]) {
                this.models[model] = Number(cars);
            } else {
                this.models[model] += Number(cars);
            }
        }

        toString = () => {
            let report = `${this.brand}\n`;

            for (let model of Object.keys(this.models)) {
                report += `###${model} -> ${this.models[model]}\n`
            }

            return report.trimEnd();
        }
    }

    let producedCars = getCars();

    return getResult();

    function getCars() {
        let producedCars = {};

        input.forEach(car => {
            let splitted = car.split(` | `);
            let brand = splitted[0];
            let model = splitted[1];
            let cars = splitted[2];

            if (!producedCars[brand]) {
                producedCars[brand] = new Car(brand);
            }

            producedCars[brand].getCar(model, cars);
        });

        return producedCars;
    }

    function getResult() {
        let result = ``;

        for (let car of Object.keys(producedCars)) {
            result += `${producedCars[car].toString()}\n`;
        }

        return result.trimEnd();
    }
}

console.log(aeCompany(['Audi | Q7 | 1000', 'Audi | Q6 | 100', 'BMW | X5 | 1000', 'BMW | X6 | 100', 'Citroen | C4 | 123', 'Volga | GAZ-24 | 1000000', 'Lada | Niva | 1000000', 'Lada | Jigula | 1000000', 'Citroen | C4 | 22', 'Citroen | C5 | 10'])); // Audi Q7 -> 1000 Audi Q6 -> 100 BMW X5 -> 1000 BMW X6 -> 100 Citroen C4 -> 145 Citroen C5 -> 10 Volga GAZ-24 -> 1000000 Lada Niva -> 1000000 Lada Jigula -> 1000000