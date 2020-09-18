function solve(text){
    const pattern = /\w+/gm;
    let words = text.match(pattern);
    let upperCaseWords = words.map(name => name.toUpperCase());
    let result = upperCaseWords.join(', ');
    console.log(result);
}

solve('Hi, how are you?');