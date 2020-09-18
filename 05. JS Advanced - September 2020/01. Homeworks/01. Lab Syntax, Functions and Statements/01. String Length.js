function solve(str1, str2, str3){
    let strLength = str1.length + str2.length + str3.length;
    console.log(strLength);
    let strAverageLength = Math.floor(strLength / 3);
    console.log(strAverageLength);
}

solve('pasta', '5', '22.3');