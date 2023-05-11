function heroes() {
    let castSpell = (state) => ({
        cast: (spell) => {
            console.log(`${state.name} cast ${spell}`);
            state.mana--;
        }
    });

    let mage = (name) => {
        let state = {
            name,
            health: 100,
            mana: 100
        };

        return Object.assign(state, castSpell(state));
    }

    let meleeAttack = (state) => ({
        fight: () => {
            console.log(`${state.name} slashes at the foe!`);
            state.stamina--;
        }
    });

    let fighter = (name) => {
        let state = {
            name,
            health: 100,
            stamina: 100
        };

        return Object.assign(state, meleeAttack(state));
    }

    return { mage: mage, fighter: fighter };
}

let create = heroes();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const warrior = create.fighter("Warrior");
warrior.fight();

console.log(warrior.stamina);
console.log(scorcher.mana);
