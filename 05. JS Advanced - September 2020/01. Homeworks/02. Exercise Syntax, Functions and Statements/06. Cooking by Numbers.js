function solve(data) {
    let startingNum = Number(data[0]);

    for (let i = 1; i < data.length; i++) {
        let operation = data[i];

        switch (operation) {
            case 'chop': startingNum /= 2;
                break;
            case 'dice': startingNum = Math.sqrt(startingNum);
                break;
            case 'spice': startingNum += 1;
                break;
            case 'bake': startingNum *= 3;
                break;
            case 'fillet': startingNum = (0.80 * startingNum).toFixed(1);
                break;
        }

        console.log(startingNum);
    }
}

solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);