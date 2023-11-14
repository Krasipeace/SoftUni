function getStoreProvisions(currentStock, orderedStock) {
    let products = {};
    for (let i = 0; i < currentStock.length; i += 2) {
        products[currentStock[i]] = Number(currentStock[i + 1]);
    }

    for (let i = 0; i < orderedStock.length; i += 2) {
        products.hasOwnProperty(orderedStock[i])
            ? products[orderedStock[i]] += Number(orderedStock[i + 1])
            : products[orderedStock[i]] = Number(orderedStock[i + 1]);
    }

    for (const key in products) {
        console.log(`${key} -> ${products[key]}`);
    }
}

getStoreProvisions(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
);
// Chips -> 5
// CocaCola -> 9
// Bananas -> 44
// Pasta -> 11
// Beer -> 2
// Flour -> 44
// Oil -> 12
// Tomatoes -> 70
console.log("\n");
getStoreProvisions(
    ['Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'],
    ['Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30']
);
// Salt -> 2
// Fanta -> 4
// Apple -> 21
// Water -> 4
// Juice -> 5
// Sugar -> 44
// Oil -> 12
// Tomatoes -> 7
// Bananas -> 30