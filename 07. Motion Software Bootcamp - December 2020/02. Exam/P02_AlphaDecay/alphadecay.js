function solve(input) {
    let n = input[0].split(' ').map(x => Number(x)).length;
    let k = Number(input[1]);

    function calcFactorial(num) {
        let val = 1;
        for (let i = 2; i <= num; i++) {
            val = val * i;
        }
        return val;
    }

    let result = calcFactorial(n) / calcFactorial(n - k);

    return result;
}



solve([
    '234 232 230',
    '2'
])

solve([
    '109 113 234 232',
    '3'
])