function solve(data) {
    let filteredTowns = [];
    let allTowns = [];

    data.forEach(row => {
        let [nameValue, productValue, priceValue] = row.split(' | ');

        let townObj = {
            name: nameValue,
            product: productValue,
            price: Number(priceValue),
        };

        let cloneObj = Object.assign({}, townObj);

        allTowns.push(cloneObj);

        if (filteredTowns.some(t => t.name == nameValue && t.product == productValue)) {
            let filteredTown = filteredTowns.find(t => t.name == nameValue && t.product == productValue);
            filteredTown.price = priceValue;

            if (allTowns.some(t => t.price == priceValue && t.product == productValue)) {
                let town = allTowns.find(t => t.price == priceValue && t.product == productValue);
                filteredTown.name = town.name;
            }
        };

        if (!filteredTowns.some(t => t.product == productValue)){
            filteredTowns.push(townObj);
        };

        filteredTowns.forEach(town => {
            if (town.product == productValue && town.price > priceValue) {
                town.name = nameValue;
                town.price = priceValue;
            };
        });
    });

    filteredTowns.forEach(town => {
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