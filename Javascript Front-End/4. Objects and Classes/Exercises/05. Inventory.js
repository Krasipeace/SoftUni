function inventory(heroInfo) {
    let heroes = [];

    for (let i = 0; i < heroInfo.length; i++) {
        let [name, level, items] = heroInfo[i].split(' / ');

        let hero = {
            name,
            level: Number(level),
            items: items.split(', ').join(', ')
        }
        heroes.push(hero);
    }

    heroes.sort((a, b) => a.level - b.level);

    for (let i = 0; i < heroes.length; i++) {
        console.log(`Hero: ${heroes[i].name}`);
        console.log(`level => ${heroes[i].level}`);
        console.log(`items => ${heroes[i].items}`);
    }
}

inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]);
// Hero: Hes
// level => 1
// items => Desolator, Sentinel, Antara
// Hero: Derek
// level => 12
// items => BarrelVest, DestructionSword
// Hero: Isacc
// level => 25
// items => Apple, GravityGun