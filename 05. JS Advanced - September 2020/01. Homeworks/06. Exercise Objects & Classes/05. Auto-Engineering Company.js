function solve(data) {
    let cars = [];
    let brands = [];

    data.forEach(row => {
        let [carBrand, carModel, producedCars] = row.split(' | ');
        producedCars = Number(producedCars);

        if (!brands.includes(carBrand)) {
            brands.push(carBrand);
        };

        let car = {brand: carBrand, model: carModel, cars: producedCars};
        
        if (!cars.some(c => c.brand == car.brand) || !cars.some(c => c.model == car.model)) {
            if (cars.some(c => c.brand == car.brand)) {
                let lastIndex = cars.map(c => c.brand).lastIndexOf(carBrand);
                cars.splice(lastIndex + 1, 0, car);
            } else {
                cars.push(car);
            };
        } else if (cars.some(c => c.brand == car.brand) && cars.some(c => c.model == car.model)){
            let searchedCar = cars.find(c => c.brand == car.brand && c.model == car.model);
            searchedCar.cars += car.cars;         
        };
    });

    let counter = 1;

    for (let i = 0; i < cars.length; i++) {
        let car = cars[i];

        if (car.brand == brands[0]) {
            if (counter == 1) {
                console.log(brands[0]);
            };
            counter++;
        } else {
            brands.shift();
            counter = 1;
            i--;
            continue;
        };

        console.log(`###${car.model} -> ${car.cars}`);
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10'
]);