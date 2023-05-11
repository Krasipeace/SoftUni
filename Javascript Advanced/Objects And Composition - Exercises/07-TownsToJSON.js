function townsToJson(input) {
    let towns = [];

    for (let i = 1; i < input.length; i++) {
        let [town, latitude, longitude] = input[i]
            .split('|')
            .filter(x => x !== '')
            .map(x => x.trim());

        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        towns.push({
            Town: town,
            Latitude: Number(latitude),
            Longitude: Number(longitude)
        });
    }

    console.log(JSON.stringify(towns));
}

townsToJson(['| Town | Latitude | Longitude |', '| Sofia | 42.696552 | 23.32601 |', '| Beijing | 39.913818 | 116.363625 |']);
// [{"Town":"Sofia","Latitude":42.70,"Longitude":23.33},{"Town":"Beijing","Latitude":39.91,"Longitude":116.36}]