function solution() {
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    let apple = Object.create(ingredients);
    apple.carbohydrate = 1;
    apple.flavour = 2;

    let lemonade = Object.create(ingredients);
    lemonade.carbohydrate = 10;
    lemonade.flavour = 20;

    let burger = Object.create(ingredients);
    burger.carbohydrate = 5;
    burger.fat = 7;
    burger.flavour = 3;

    let eggs = Object.create(ingredients);
    eggs.protein = 5;
    eggs.fat = 1;
    eggs.flavour = 1;

    let turkey = Object.create(ingredients);
    turkey.protein = 10;
    turkey.carbohydrate = 10;
    turkey.fat = 10;
    turkey.flavour = 10;

    let recipes = {apple, lemonade, burger, eggs, turkey};

    return function(args) {       
        if (args.split(' ').length == 1) {
            return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
        }

        let [command, target, quantity] = args.split(' ');
        quantity = Number(quantity);

        if (command == 'restock') {
            ingredients[target] += quantity;
            return 'Success';
        }

        if (command == 'prepare') {
            let currentRecipe = recipes[target];

            let insufficientIngredient = 
            Object.keys(currentRecipe)
            .find(ingredient => currentRecipe[ingredient] * quantity > ingredients[ingredient]);

            if (insufficientIngredient) {
                return `Error: not enough ${insufficientIngredient} in stock`;
            }

            Object.keys(currentRecipe).forEach(ingredient => {
                ingredients[ingredient] -= currentRecipe[ingredient] * quantity;
            });

            return `Success`;
        }
    }
}

let manager = solution();

console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));
