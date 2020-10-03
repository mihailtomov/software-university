function solve(data) {
    let towns = [];

    data.forEach(row => {
        let [nameValue, productValue, priceValue] = row.split(' | ');

        let townObj = {
            name: nameValue,
            product: productValue,
            price: Number(priceValue),
        };

        if (!towns.some(t => t.product == productValue)){
            towns.push(townObj);
        };

        towns.forEach(town => {
            if (town.product == productValue && town.price > priceValue) {
                town.name = nameValue;
                town.price = priceValue;
            };
        });

        if (towns.some(t => t.name == nameValue && t.product == productValue)) {
            let town = towns.find(t => t.name == nameValue && t.product == productValue);
            town.price = priceValue;
        };

    });

    towns.forEach(town => {
        console.log(`${town.product} -> ${town.price} (${town.name})`);
    });
}

solve(['Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'New York City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Mexico City | Audi | 100000',
    'Washington City | Mercedes | 1000',
]);