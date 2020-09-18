function solve(num1, num2, str) {
    let result;
    switch (str) {
        case '+': result = num1 + num2;
            break;
        case '-': result = num1 - num2;
            break;
        case '*': result = num1 * num2;
            break;
        case '/': result = num1 / num2;
            break;
        case '%': result = num1 % num2;
            break;
        case '**': result = num1 ** num2;
            break;
    }
    console.log(result);
}

solve(3, 5.5, '*');