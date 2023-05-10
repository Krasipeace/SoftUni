function sortArrBy2Criteria(input) {
    input.sort((first, second) => 
        first.length - second.length || first.localeCompare(second))
    console.log(input.join('\n'))
}

sortArrBy2Criteria(['alpha', 'beta', 'gamma']) // beta alpha gamma
console.log()
sortArrBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']) // Jack Isacc George Theodor Harrison
console.log()
sortArrBy2Criteria(['test', 'Deny', 'omen', 'Default']) // Deny omen test Default