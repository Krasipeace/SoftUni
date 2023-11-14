function getArmies(arrStrings) {
    let armies = [];

    for (let line of arrStrings) {
        if (line.includes('arrives')) {
            let leader = line.replace(' arrives', '');
            addLeader(armies, leader);
        } else if (line.includes(': ')) {
            let [leader, armyInfo] = line.split(': ');
            addArmy(armies, leader, armyInfo);
        } else if (line.includes('+')) {
            let [armyName, armyCount] = line.split(' + ');
            addArmyCount(armies, armyName, armyCount);
        } else if (line.includes('defeated')) {
            let leader = line.replace(' defeated', '');
            removeLeader(armies, leader);
        }
    }

    printResult(armies);

    function addLeader(armies, leader) {
        if (!armies.find(army => army.leader === leader)) {
            armies.push({ leader: leader, armies: [] });
        }
    }

    function addArmy(armies, leader, armyInfo) {
        let [armyName, armyCount] = armyInfo.split(', ');
        let foundArmy = armies.find(army => army.leader === leader);
        
        if (foundArmy) {
            foundArmy.armies.push({ name: armyName, count: Number(armyCount) });
        }
    }

    function addArmyCount(armies, armyName, armyCount) {
        for (let army of armies) {
            let foundSubArmy = army.armies.find(subArmy => subArmy.name === armyName);

            if (foundSubArmy) {
                foundSubArmy.count += Number(armyCount);
            }
        }
    }

    function removeLeader(armies, leader) {
        let index = armies.findIndex(army => army.leader === leader);

        if (index !== -1) {
            armies.splice(index, 1);
        }
    }

    function sortArmiesByCount(armies) {
        armies.sort((a, b) => b.armies.reduce((acc, army) => acc + army.count, 0) - a.armies.reduce((acc, army) => acc + army.count, 0));
    }

    function printLeaderAndTotalCount(army) {
        console.log(`${army.leader}: ${army.armies.reduce((acc, army) => acc + army.count, 0)}`);
    }

    function sortAndPrintSubArmies(army) {
        army.armies.sort((a, b) => b.count - a.count);

        for (let subArmy of army.armies) {
            console.log(`>>> ${subArmy.name} - ${subArmy.count}`);
        }
    }

    function printResult(armies) {
        sortArmiesByCount(armies);

        for (let army of armies) {
            printLeaderAndTotalCount(army);
            sortAndPrintSubArmies(army);
        }
    }
}

getArmies([
    'Rick Burr arrives', 'Fergus: Wexamp, 30245', 'Rick Burr: Juard, 50000', 'Findlay arrives', 'Findlay: Britox, 34540', 'Wexamp + 6000', 'Juard + 1350', 'Britox + 4500', 'Porter arrives', 'Porter: Legion, 55000', 'Legion + 302', 'Rick Burr defeated', 'Porter: Retix, 3205'
]);
// Porter: 58507
//     >>> Legion - 55302
//     >>> Retix - 3205
// Findlay: 39040
//     >>> Britox - 39040
getArmies([
    'Rick Burr arrives', 'Findlay arrives', 'Rick Burr: Juard, 1500', 'Wexamp arrives', 'Findlay: Wexamp, 34540', 'Wexamp + 340', 'Wexamp: Britox, 1155', 'Wexamp: Juard, 43423'
]);
// Wexamp: 44578
//     >>> Juard - 43423
//     >>> Britox - 1155
// Findlay: 34880
//     >>> Wexamp - 34880
// Rick Burr: 1500
//     >>> Juard - 1500