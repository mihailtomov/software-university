function solve(arr) {
    
    let rotationNum = Number(arr.pop()) % arr.length;

    for (let i = 0; i < rotationNum; i++) {
        
        let lastEl = arr.pop();
        arr.unshift(lastEl); 
    }

    console.log(arr.join(' '));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
);