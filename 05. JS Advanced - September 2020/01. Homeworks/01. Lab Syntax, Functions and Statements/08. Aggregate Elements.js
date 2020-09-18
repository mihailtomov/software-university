function solve(numbers){
    let sumOfElements = numbers.reduce((a, b) => a + b, 0);
    let sumOfInverse = 0;
    let concatString = '';
    for(let i = 0; i < numbers.length; i++){
        sumOfInverse += 1 / numbers[i];
    }
    for(let i = 0; i < numbers.length; i++){
        concatString += numbers[i];
    }
    console.log(sumOfElements);
    console.log(sumOfInverse);
    console.log(concatString);
}

solve([1, 2, 3]);