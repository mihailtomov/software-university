function solve(n, k) {
    let arr = [1, 1, 2];
    arr.length = n;

    for (let i = 3; i < arr.length; i++) {
        let sum = 0;
        
        if (k > i) {
            arr[i] = arr.reduce((a, b) => a + b, 0);
        } else {
            for (let j = i - k; j < i; j++) {
                sum += arr[j];              
            }

            arr[i] = sum;
        }       
    }

    console.log(arr.join(' '));
}

solve(9, 5);