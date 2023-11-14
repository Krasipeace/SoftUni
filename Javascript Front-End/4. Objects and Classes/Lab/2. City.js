function printCityInfo(city) {
    for (let property in city) {
        console.log(`${property} -> ${city[property]}`);
    }
}

printCityInfo({ name: "Sofia", area: 492, population: 1238438, country: "Bulgaria", postCode: "1000" });