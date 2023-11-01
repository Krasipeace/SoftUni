function solve(base, increment) {
    const pyramidTopOddBase = 1;
    const pyramidTopEvenBase = 4;
    const fivethFloor = 5;
    const squareSides = 4;
    const corners = 4;
    let totalMarble = 0;
    let totalStone = 0;
    let totalLapis = 0;
    let pyramidHeight = 0;

    while (base > 2) {
        const marble = base * squareSides - corners;
        const stone = base * base - marble;

        totalStone += stone;
        pyramidHeight++;
        pyramidHeight % fivethFloor === 0 
            ? totalLapis += marble 
            : totalMarble += marble;
        base -= 2;
    }

    pyramidHeight++;
    let totalGold = base === pyramidTopOddBase 
        ? pyramidTopOddBase 
        : pyramidTopEvenBase;

    console.log(`Stone required: ${Math.ceil(totalStone * increment)}`);
    console.log(`Marble required: ${Math.ceil(totalMarble * increment)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(totalLapis * increment)}`);
    console.log(`Gold required: ${Math.ceil(totalGold * increment)}`);
    console.log(`Final pyramid height: ${Math.floor(pyramidHeight * increment)}`);
}

solve(12, 1);
// Stone required: 220
// Marble required: 128
// Lapis Lazuli required: 12
// Gold required: 4
// Final pyramid height: 6
solve(23, 0.5); 
// Stone required: 886
// Marble required: 228
// Lapis Lazuli required: 36
// Gold required: 1
// Final pyramid height: 6