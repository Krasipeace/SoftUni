function breakfastRobot() {
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let orders = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    };

    let restock = (element, quantity) => {
        ingredients[element] += Number(quantity);

        return "Success";
    };

    let prepare = (order, quantity) => {
        let recipeIngredients = orders[order];

        for (let element of Object.keys(recipeIngredients)) {
            if (recipeIngredients[element] * Number(quantity) > ingredients[element]) {
                return `Error: not enough ${element} in stock`;
            }
        }

        for (let ingredient of Object.keys(recipeIngredients)) {
            ingredients[ingredient] -= recipeIngredients[ingredient] * Number(quantity);
        }

        return "Success";
    };

    let report = () => {
        return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
    };

    return function (input) {
        let [command, element, quantity] = input.split(" ");
        
        if (command === "restock") {
            return restock(element, quantity);
        }
        else if (command === "prepare") {
            return prepare(element, quantity);
        }
        else {
            return report();
        }
    };
}

let manager = breakfastRobot();
console.log(manager("restock flavour 50")); // Success
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock