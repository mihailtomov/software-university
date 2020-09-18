function solve(first, second){
    let lower = Math.min(first, second);
    let bigger = Math.max(first, second);  
    let divisor = lower;
    while((bigger % divisor != 0) || (lower % divisor != 0)){
        divisor--;
    }
    console.log(divisor);
}

solve(15, 5);