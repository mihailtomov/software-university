function solve(arg){
    if(typeof(arg) != 'number'){
        console.log(`We can not calculate the circle area, because we receive a ${typeof(arg)}.`);
    } else {
        let circleArea = Math.PI * arg ** 2;
        console.log(circleArea.toFixed(2));
    }
}

solve('name');