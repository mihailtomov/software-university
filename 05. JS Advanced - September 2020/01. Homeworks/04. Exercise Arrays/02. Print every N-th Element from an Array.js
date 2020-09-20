function solve(arr) {

    let n = Number(arr.pop());
    for (let i = 0; i < arr.length; i += n) {

        let element = arr[i];
        console.log(element);
    }
}

solve(['dsa',
'asd', 
'test', 
'tset', 
'2']
);