function solve(input) {
    let heroes = [];

    input.forEach(row => {
        let [heroName, heroLevel, itemsArr] = row.split(' / ');
        let hero = {};
        hero.name = heroName;
        hero.level = Number(heroLevel);
        itemsArr != undefined ? hero.items = itemsArr.split(', ') : hero.items = [];
        heroes.push(hero);
    });

    console.log(JSON.stringify(heroes));
}

solve(['Jake / 1000']);