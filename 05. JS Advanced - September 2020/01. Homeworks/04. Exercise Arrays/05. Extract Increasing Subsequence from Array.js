function solve(numbers) {
    
    let biggestNum = Number.MIN_SAFE_INTEGER;

    numbers.forEach(function filterNums(num) {
        
        if (num >= biggestNum) {

            biggestNum = num;
            console.log(num);
        }
    })
}

solve([1, 
    1, 
    3,
    4]        
    );