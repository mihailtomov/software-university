function solve(matrix) {
    let equalPairsCount = 0;

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {
            
            let currEl = matrix[row][col];
            let currCount = equalPairsCount;

            if (row > 0) {
                if (matrix[row - 1][col] === currEl) {
                    equalPairsCount++;
                }
            }
            if (col > 0) {
                if (matrix[row][col - 1] === currEl) {
                    equalPairsCount++;
                }
            }
            if (row < matrix.length - 1) {
                if (matrix[row + 1][col] === currEl) {
                    equalPairsCount++;
                }
            }
            if (col < matrix[row].length - 1) {
                if (matrix[row][col + 1] === currEl) {
                    equalPairsCount++;
                }             
            }

            if (currCount != equalPairsCount) {
                matrix[row][col] = 'counted';
            }
        }
    }

    console.log(equalPairsCount);
}

solve([
['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
);