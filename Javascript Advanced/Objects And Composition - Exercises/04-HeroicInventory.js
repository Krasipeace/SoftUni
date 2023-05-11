function heroicInventory(input) {
    let heroes = [];

    for (let i = 0; i < input.length; i++) {
        let [name, level, items] = input[i].split(" / ");
        level = Number(level);
        items = items ? items.split(", ") : [];

        heroes.push({ name, level, items });
    }

    return JSON.stringify(heroes);
}

// console.log(heroicInventory(["Isacc / 25 / Apple, GravityGun", "Derek / 12 / BarrelVest, DestructionSword", "Hes / 1 / Desolator, Sentinel, Antara"]));
// [{"name":"Isacc","level":25,"items":["Apple","GravityGun"]},{"name":"Derek","level":12,"items":["BarrelVest","DestructionSword"]},{"name":"Hes","level":1,"items":["Desolator","Sentinel","Antara"]}]