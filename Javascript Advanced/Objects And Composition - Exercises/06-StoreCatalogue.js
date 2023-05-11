function storeCatalogue(input) {
    let catalogue = {};

    for (const line of input) {
        let [product, price] = line.split(' : ');
        price = Number(price);
        let catLetter = product[0];

        if (!catalogue.hasOwnProperty(catLetter)) {
            catalogue[catLetter] = {};
        }

        catalogue[catLetter][product] = price;
    }

    let sortedKeys = Object
        .keys(catalogue)
        .sort((a, b) => a.localeCompare(b));

    for (const key of sortedKeys) {
        console.log(key);

        let sortedProducts = Object
            .keys(catalogue[key])
            .sort((a, b) => a.localeCompare(b));

        for (const product of sortedProducts) {
            console.log(`  ${product}: ${catalogue[key][product]}`);
        }
    }
}

storeCatalogue(['Appricot : 20.4', 'Fridge : 1500', 'TV : 1499', 'Deodorant : 10', 'Boiler : 300', 'Apple : 1.25', 'Anti-Bug Spray : 15', 'T-Shirt : 10']);
// A
//   Anti-Bug Spray: 15
//   Apple: 1.25
//   Appricot: 20.4
// B
//   Boiler: 300
// D
//   Deodorant: 10
// F
//   Fridge: 1500
// T
//   T-Shirt: 10
//   TV: 1499