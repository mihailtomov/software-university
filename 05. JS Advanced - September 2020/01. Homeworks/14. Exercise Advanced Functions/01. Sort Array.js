function solve(numsArray, sortType) {
    sortType == 'asc' ? 
    numsArray.sort((a, b) => a - b) : 
    numsArray.sort((a, b) => b - a);

    return numsArray;
}

let result = solve([14, 7, 17, 6, 8], 'desc');
console.log(result);