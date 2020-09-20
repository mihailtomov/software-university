function solve(arr) {
    
    let comparer = function (a, b) {
        
        if (a > b) {
            return 1;
        }
        if (a < b) {
            return -1;
        }

        return 0;
    }

    arr.sort(function (a, b) {
        return comparer(a.length, b.length) || comparer(a, b);
    });

    arr.forEach(x => console.log(x));
}

solve(['test', 
'Deny', 
'omen', 
'Default']
);