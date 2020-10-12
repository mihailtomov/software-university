function subtract() {
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');

    let result = Number(firstNumberElement.value) - Number(secondNumberElement.value);
    let resultElement = document.getElementById('result');
    resultElement.innerText = result;
}