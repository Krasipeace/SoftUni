function getListOfNames (names) {
    const sorted = names.sort((a, b) => a.localeCompare(b)); // sort ASC by Name
    const result = sorted.map((name, index) => `${index + 1}.${name}`)

    console.log(result.join('\n'));
}

getListOfNames(['John', 'Bob', 'Christina', 'Ema']); // 1.Bob 2.Christina 3.Ema 4.John