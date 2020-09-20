function solve(n, k) {
    let arr = [];
    arr.length = n;

    if (n > 0) {
        arr[0] = 1;

        for (let i = 1; i < arr.length; i++) {
            
            if (k > i) {
                arr[i] = arr.reduce((a, b) => a + b, 0);

            } else {
                let sum = 0;

                for (let j = i - k; j < i; j++) {
                    sum += arr[j];                  
                }

                arr[i] = sum;
            }           
        }
    } 
    
    console.log(arr.join(' '));
}

solve(3, 2);