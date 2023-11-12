function towns(input) {
    let towns = [];
    for (let i = 0; i < input.length; i++) {
        let [town, latitude, longitude] = input[i].split(' | ');

        let obj = {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        }

        towns.push(obj);
    }
    for (let town of towns) {
        console.log(town);
    }
}

towns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
// { town: 'Sofia', latitude: '42.70', longitude: '23.33' }
// { town: 'Beijing', latitude: '39.91', longitude: '116.36' }