function listOfName (input) {
    input.sort((first, second) => first.localeCompare(second))

    for (let i = 0; i < input.length; i++) {
        console.log(`${i + 1}.${input[i]}`)
    }
}

listOfName(["John", "Bob", "Christina", "Ema"]) // 1.Bob 2.Christina 3.Ema 4.John