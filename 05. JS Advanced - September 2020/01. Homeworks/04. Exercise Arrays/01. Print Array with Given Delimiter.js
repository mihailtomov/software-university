function solve(arr) {
    
    let delimiter = arr.pop();
    let result = arr.join(delimiter);
    console.log(result);
}

solve(['How about no?', 
'I',
'will', 
'not', 
'do', 
'it!', 
'_']
);