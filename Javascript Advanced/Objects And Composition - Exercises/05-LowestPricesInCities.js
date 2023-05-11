function lowestPricesInCities(input) {
    let products = {};

    for (let line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        if (!products.hasOwnProperty(product)) {
            products[product] = {};
        }

        products[product][town] = price;
    }

    for (let product in products) {
        let sortedTowns = Object
            .entries(products[product])
            .sort((a, b) => a[1] - b[1]);

        console.log(`${product} -> ${sortedTowns[0][1]} (${sortedTowns[0][0]})`);
    }
}

//lowestPricesInCities(['Sample Town | Sample Product | 1000', 'Sample Town | Orange | 2', 'Sample Town | Peach | 1', 'Sofia | Orange | 3', 'Sofia | Peach | 2', 'New York | Sample Product | 1000.1', 'New York | Burger | 10']);
// Sample Product -> 1000 (Sample Town)
// Orange -> 2 (Sample Town)
// Peach -> 1 (Sample Town)
// Burger -> 10 (New York)