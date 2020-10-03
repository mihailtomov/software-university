function solve(input) {
    let towns = {};

    input.forEach(str => {
        let args = str.split(' <-> ');
        let[town, population] = args;

        if (!towns[town]) {
            towns[town] = Number(population);
        } else {
            towns[town] += Number(population);
        }
    });

    for (const key in towns) {
        console.log(`${key} : ${towns[key]}`);
    }
}

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000'
]);