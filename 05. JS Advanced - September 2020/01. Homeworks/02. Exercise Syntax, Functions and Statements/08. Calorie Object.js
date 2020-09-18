function solve(data) {
    let caloriesObject = new Object();

    for (let i = 0; i < data.length; i+=2) {
        let food = data[i];
        let calories = Number(data[i + 1]);
        caloriesObject[food] = calories;
    }

    console.log(caloriesObject);
}

solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);