function printDNA(helixLength) {
    const sequence = "ATCGTTAGGG";
    let sequenceIndex = 0;
    let helixIndex = 0;

    for (let i = 0; i < helixLength; i++) {
        if (helixIndex === 0) {
            console.log(`**${sequence[sequenceIndex++ % sequence.length]}${sequence[sequenceIndex++ % sequence.length]}**`);
        } else if (helixIndex === 1) {
            console.log(`*${sequence[sequenceIndex++ % sequence.length]}--${sequence[sequenceIndex++ % sequence.length]}*`);
        } else if (helixIndex === 2) {
            console.log(`${sequence[sequenceIndex++ % sequence.length]}----${sequence[sequenceIndex++ % sequence.length]}`);
        } else if (helixIndex === 3) {
            console.log(`*${sequence[sequenceIndex++ % sequence.length]}--${sequence[sequenceIndex++ % sequence.length]}*`);
        }

        helixIndex = (helixIndex + 1) % 4;
    }
}

printDNA(4);
printDNA(10);