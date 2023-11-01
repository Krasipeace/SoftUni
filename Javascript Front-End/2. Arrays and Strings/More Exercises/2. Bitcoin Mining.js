function solve(shifts) {
    const goldGramPrice = 67.51;
    const bitcoinPrice = 11949.16;
    const thirdShift = 3
    const goldReducement = 0.7;
    let totalGold = 0;
    let totalBitcoins = 0;
    let startDay = 0;

    for (let i = 0; i < shifts.length; i++) {
        let minedGold = shifts[i];

        if ((i + 1) % thirdShift === 0) {
            minedGold *= goldReducement;
        }

        totalGold += minedGold;

        while (totalGold * goldGramPrice >= bitcoinPrice) {
            totalGold -= bitcoinPrice / goldGramPrice;
            totalBitcoins++;

            if (totalBitcoins === 1) {
                startDay = i + 1;
            }
        }
    }

    console.log(`Bought bitcoins: ${totalBitcoins}`);

    if (totalBitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${startDay}`);
    }

    console.log(`Left money: ${(totalGold * goldGramPrice).toFixed(2)} lv.`);
}

solve([100, 200, 300]); // Bought bitcoins: 2 Day of the first purchased bitcoin: 2 Left money: 10531.78 lv.
solve([50, 100]); // Bought bitcoins: 0 Left money: 10126.50 lv.