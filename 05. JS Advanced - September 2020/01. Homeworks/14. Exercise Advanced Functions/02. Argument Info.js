function solve(...args) {
    let tally = {};

    args.forEach(arg => {
        let type = typeof(arg);
        console.log(`${type}: ${arg}`);
        if (!tally[type]) {
            tally[type] = 0;
        }
        tally[type]++;
    });
    
    Object.entries(tally)
    .sort((a, b) => b[1] - a[1])
    .forEach(([type, count]) => {
        console.log(`${type} = ${count}`);
    });
}

solve('cat', 42, function () { console.log('Hello world!'); });