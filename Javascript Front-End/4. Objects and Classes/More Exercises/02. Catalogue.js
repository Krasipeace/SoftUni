function printCatalogue(input) {
    function populateCatalogue(input) {
        let catalogue = {};

        for (let line of input) {
            let [name, price] = line.split(' : ');
            price = Number(price);
            let letter = name[0];

            if (!catalogue.hasOwnProperty(letter)) {
                catalogue[letter] = {};
            }

            catalogue[letter][name] = price;
        }

        return catalogue;
    }
    
    function printSortedCatalogue(catalogue) {
        let sortedLetters = Object.keys(catalogue).sort((a, b) => a.localeCompare(b));
        
        for (let letter of sortedLetters) {
            console.log(letter);
            
            let sortedProducts = Object.keys(catalogue[letter]).sort((a, b) => a.localeCompare(b));
            
            for (let product of sortedProducts) {
                console.log(`  ${product}: ${catalogue[letter][product]}`);
            }
        }
    }
    
    let catalogue = populateCatalogue(input);
    printSortedCatalogue(catalogue);
}

printCatalogue([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]);
// A
// Anti - Bug Spray: 15
// Apple: 1.25
// Appricot: 20.4
// B
// Boiler: 300
// D
// Deodorant: 10
// F
// Fridge: 1500
// T
// T - Shirt: 10
// TV: 1499
printCatalogue([
    'Omlet : 5.4',
    'Shirt : 15',
    'Cake : 59'
]);
// C
// Cake: 59
// O
// Omlet: 5.4
// S
// Shirt: 15