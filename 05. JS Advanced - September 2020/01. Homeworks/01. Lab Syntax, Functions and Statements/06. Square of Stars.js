function solve(size = 5){
    var output = '';
    for(let i = 0; i < size; i++){
        for(let j = 0; j < size; j++){
            output += '*' + ' ';
        }
        output += '\n';
    }
    console.log(output);
}

solve();