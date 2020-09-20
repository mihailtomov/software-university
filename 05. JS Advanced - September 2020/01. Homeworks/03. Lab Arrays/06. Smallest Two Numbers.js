function solve(numbers) {
    
    function compareNums (a, b){
        return a - b;
    }

    numbers.sort(compareNums);
    let result = numbers.slice(0, 2);
    console.log(result.join(' '));
}

solve([3, 0, 10, 4, 7, 3]);