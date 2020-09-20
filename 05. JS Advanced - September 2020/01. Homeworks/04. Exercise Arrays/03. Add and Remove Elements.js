function solve(arr) {
    
    let number = 1;
    let resultArr = [];

    for (let i = 0; i < arr.length; i++) {

        let command = arr[i];

        if (command == 'add') {
            resultArr.push(number);
        } else {
            resultArr.pop();
        }   
        
        number++;
    }

    if (resultArr.length == 0) {
        console.log('Empty');
    } else {
        resultArr.forEach(x => console.log(x));
    }
}

solve(['remove', 
'remove', 
'remove']
);