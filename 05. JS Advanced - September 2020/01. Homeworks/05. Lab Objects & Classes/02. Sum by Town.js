function solve(input) {
    let towns = {};

    for (let i = 0; i < input.length; i+=2) {
        let town = input[i];
        let value = Number(input[i + 1]);

        if (!towns[town]) {
            towns[town] = value;
        } else {
            towns[town] += value;
        }
    }

    console.log(JSON.stringify(towns));
}

solve(['Sofia','20','Varna','3','sofia','5','varna','4']);