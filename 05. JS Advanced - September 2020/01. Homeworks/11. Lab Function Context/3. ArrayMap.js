function arrayMap(arr, func) {
    return arr.reduce((acc, x) => {
        acc.push(func(x));

        return acc;
    }, []);
}

let arr = [1,2,3,4,5];
let func = item => item * 2;
console.log(arrayMap(arr, func));