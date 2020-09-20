function solve(matrix) {
    let mainSum = 0;
    let secondarySum = 0;

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            if (row == col) {
                mainSum += matrix[row][col];
            }
        }
    }
    let col = 0;

    for (let row = matrix.length - 1; row >= 0; row--) {

        secondarySum += matrix[row][col];
        col++;
    }

    console.log(mainSum + ' ' + secondarySum);
}

solve([[3, 5, 17],
 [-1, 7, 14],
 [1, -8, 89]]
);