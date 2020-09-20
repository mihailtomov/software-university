function solve(matrix) {
    
    let isMagical = true;

    let magicNumber = matrix[0].reduce((a, b) => a + b, 0);

    matrix.forEach(arr => {
        
        let currRowSum = arr.reduce((a, b) => a + b, 0);

        for (let col = 0; col < arr.length; col++) {
            
            let currColSum = 0;

            for (let row = 0; row < matrix.length; row++) {
                
                currColSum += matrix[row][col];
            }

            if (currColSum != magicNumber || currRowSum != magicNumber) {
                
                isMagical = false;
            }
        }
    });

    console.log(isMagical);
}

solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]          
   );