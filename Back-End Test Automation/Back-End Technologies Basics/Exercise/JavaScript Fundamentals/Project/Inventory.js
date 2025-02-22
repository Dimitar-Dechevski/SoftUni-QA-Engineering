function solve(input) {
    let heroes = [];

    for (let element of input) {
        let tokens = element.split(' / ');
        let name = tokens[0];
        let level = Number(tokens[1]);
        let items = tokens[2];
        let hero = {
            name: name,
            level: level,
            items: items
        };
        heroes.push(hero);
    }

    heroes.sort((hero1, hero2) => hero1.level - hero2.level);

    for (let hero of heroes) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    }
}

solve(['Isacc / 25 / Apple, GravityGun', 'Derek / 12 / BarrelVest, DestructionSword', 'Hes / 1 / Desolator, Sentinel, Antara']);
solve(['Batman / 2 / Banana, Gun', 'Superman / 18 / Sword', 'Poppy / 28 / Sentinel, Antara']);