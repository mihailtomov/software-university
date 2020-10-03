function solve(arr) {
    let headings = [];
    let towns = [];

    arr.forEach((row, i) => {
        let args = row.split('|')
        .filter(x => x != '')
        .map(x => x.trim());

        if (i == 0) {
            headings = args;
        } else {
            let currTown = {};

            headings.forEach((heading, i) => {
                if (i == 0) {
                    currTown[heading] = args[i];
                } else {
                    currTown[heading] = Number(Number(args[i]).toFixed(2));
                }
            });

            towns.push(currTown);
        }
    });

    console.log(JSON.stringify(towns));
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |'
]);