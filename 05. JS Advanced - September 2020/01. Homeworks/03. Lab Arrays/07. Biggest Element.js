function solve(matrix) {
    let biggestNum = Number.MIN_SAFE_INTEGER;
    
    matrix.forEach(arr => {
        let currentMax = Math.max(...arr);

        if (currentMax > biggestNum) {
            biggestNum = currentMax;
        }
    })

    console.log(biggestNum);
}

solve([[20, 50, 10],
    [8, 33, 145]]
   );