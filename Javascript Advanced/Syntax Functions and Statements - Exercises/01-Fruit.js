function calculateFruitCost(fruit, grams, priceKg) {
        var weight = grams / 1000;
        var finalPrice = weight * priceKg;

        console.log(`I need $${finalPrice.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}

calculateFruitCost('orange', 2500, 1.80);
