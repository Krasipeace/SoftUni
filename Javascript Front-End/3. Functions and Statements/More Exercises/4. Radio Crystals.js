function radioCrystals(params) {
    const desiredFinalThickness = Number(params[0]);
    const cutValue = 4;
    const lapValue = 0.8;
    const grindValue = 20;
    const etchValue = 2;

    for (let i = 1; i < params.length; i++) {
        let crystalThickness = Number(params[i]);
        console.log(`Processing chunk ${crystalThickness} microns`);
        
        crystalThickness = cut(crystalThickness);
        crystalThickness = lap(crystalThickness);
        crystalThickness = grind(crystalThickness);
        crystalThickness = etch(crystalThickness);
        
        if (crystalThickness + 1 === desiredFinalThickness) {
            crystalThickness = xRay(crystalThickness);
        }
        
        console.log(`Finished crystal ${Math.floor(crystalThickness)} microns`);
    }

    function cut(crystalThickness) {
        let cutCount = 0;
        while (crystalThickness / cutValue >= desiredFinalThickness) {
            crystalThickness /= cutValue;
            cutCount++;
        }
        
        if (cutCount > 0) {
            console.log(`Cut x${cutCount}`);
            console.log('Transporting and washing');
        }

        return crystalThickness;
    }

    function lap(crystalThickness) {
        let lapCount = 0;
        while (crystalThickness * lapValue >= desiredFinalThickness) {
            crystalThickness *= lapValue;
            lapCount++;
        }

        if (lapCount > 0) {
            console.log(`Lap x${lapCount}`);
            console.log('Transporting and washing');
        }

        return crystalThickness;
    }

    function grind(crystalThickness) {
        let grindCount = 0;
        while (crystalThickness - grindValue >= desiredFinalThickness) {
            crystalThickness -= grindValue;
            grindCount++;
        }

        if (grindCount > 0) {
            console.log(`Grind x${grindCount}`);
            console.log('Transporting and washing');
        }

        return crystalThickness;
    }

    function etch(crystalThickness) {
        let etchCount = 0;
        while (crystalThickness - etchValue >= desiredFinalThickness - 1) {
            crystalThickness -= etchValue;
            etchCount++;
        }

        if (etchCount > 0) {
            console.log(`Etch x${etchCount}`);
            console.log('Transporting and washing');
        }

        return crystalThickness;
    }

    function xRay(crystalThickness) {
        console.log('X-ray x1');
        return ++crystalThickness;
    }
}

radioCrystals([1375, 50000]); 
radioCrystals([1000, 4000, 8100]);