function solve() {
    let keys = document.querySelector('.keys').children;
    let output = document.getElementById('expressionOutput');
    let result = document.getElementById('resultOutput');

    Array.from(keys).forEach(key => {
        if (key.value != '/' && key.value != '*' && key.value != '-' && key.value != '+' && key.value != '=') {
            key.addEventListener('click', () => {
                output.textContent += key.value;
            });
        } else if (key.value == '=') {
            key.addEventListener('click', () => {
                output.textContent += ` ${key.value} `;
                let outputArgs = output.textContent.split(' ').filter(a => a != '');

                if (outputArgs.length == 4 && outputArgs[3] == '=') {
                    let leftOperand = Number(outputArgs[0]);
                    let operator = outputArgs[1];
                    let rightOperand = Number(outputArgs[2]);

                    switch (operator) {
                        case '+':
                            result.textContent = leftOperand + rightOperand;
                            output.textContent = output.textContent.substring(0, output.textContent.length - 3);
                            break;
                        case '-':
                            result.textContent = leftOperand - rightOperand;
                            output.textContent = output.textContent.substring(0, output.textContent.length - 3);
                            break;
                        case '/':
                            result.textContent = leftOperand / rightOperand;
                            output.textContent = output.textContent.substring(0, output.textContent.length - 3);
                            break;
                        case '*':
                            result.textContent = leftOperand * rightOperand;
                            output.textContent = output.textContent.substring(0, output.textContent.length - 3);
                            break;
                    }
                } else {
                    result.textContent = NaN;
                    output.textContent = output.textContent.substring(0, output.textContent.length - 3);
                }
            });
        } else {
            key.addEventListener('click', () => {
                output.textContent += ` ${key.value} `;
            });
        }
    });

    let clear = document.querySelector('.clear');
    clear.addEventListener('click', () => {
        output.textContent = '';
        result.textContent = '';
    });
}