function calculateSpiceHarvesting(startingYield) {
    let days = 0;
    let totalAmount = 0;

    while (startingYield >= 100) {
        days++;
        totalAmount += startingYield - 26;
        startingYield -= 10;
    }

    if (totalAmount >= 26) {
        totalAmount -= 26;
    }

    return console.log(`${days}\n${totalAmount}`);
}

calculateSpiceHarvesting(111); // 2 134
calculateSpiceHarvesting(450); // 36 8938