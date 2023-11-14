function getSequences(arrStrings) {
    let sequences = [];

    for (let arrString of arrStrings) {
        let sequence = sortElementsInSequences(arrString);
        extractUniques(sequences, sequence);
    }

    let sortedSequences = sortSequences(sequences);
    printResult(sortedSequences);
   
    function sortElementsInSequences(arrString) {
        return JSON.parse(arrString).map(Number).sort((a, b) => b - a);
    }

    function extractUniques(sequences, sequence) {
        let sequenceString = sequence.join(', ');
        if (!sequences.includes(sequenceString)) {
            sequences.push(sequenceString);
        }
    }

    function sortSequences(sequences) {
        return sequences.sort((a, b) => a.split(', ').length - b.split(', ').length);
    }

    function printResult(sortedSequences) {
        for (let sequence of sortedSequences) {
            console.log(`[${sequence}]`);
        }
    }
}

getSequences([
    "[-3, -2, -1, 0, 1, 2, 3, 4]",
    "[10, 1, -17, 0, 2, 13]",
    "[4, -3, 3, -2, 2, -1, 1, 0]"
]);
// [13, 10, 2, 1, 0, -17]
// [4, 3, 2, 1, 0, -1, -2, -3]
getSequences([
    "[7.14, 7.180, 7.339, 80.099]",
    "[7.339, 80.0990, 7.140000, 7.18]",
    "[7.339, 7.180, 7.14, 80.099]"
]);
// [80.099, 7.339, 7.18, 7.14]