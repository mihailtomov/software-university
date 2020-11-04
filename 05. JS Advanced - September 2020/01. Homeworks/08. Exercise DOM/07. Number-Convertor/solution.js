function solve() {
    let number = document.getElementById('input');
    let selectMenuTo = document.getElementById('selectMenuTo');

    selectMenuTo.firstElementChild.textContent = 'Binary';
    selectMenuTo.firstElementChild.value = 'binary';

    let hexadecimalOptionElement = document.createElement('option');
    hexadecimalOptionElement.textContent = 'Hexadecimal';
    hexadecimalOptionElement.value = 'hexadecimal';

    selectMenuTo.appendChild(hexadecimalOptionElement);

    let convertBtn = document.getElementById('container').lastElementChild;

    convertBtn.addEventListener('click', () => {
        let optionElements = Array.from(selectMenuTo.children);
        let result = document.getElementById('result');
        let selectedOption = optionElements.find(e => e.selected);
        let convertedNumber;

        selectedOption.value == 'binary' ? 
        convertedNumber = Number(number.value).toString(2) : 
        convertedNumber = Number(number.value).toString(16).toUpperCase();

        result.value = convertedNumber;
    });
}