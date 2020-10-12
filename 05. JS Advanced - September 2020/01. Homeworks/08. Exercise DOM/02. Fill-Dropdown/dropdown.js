function addItem() {
    let inputText = document.getElementById('newItemText');
    let inputValue = document.getElementById('newItemValue');
    let newOptionElement = document.createElement('option');

    newOptionElement.textContent = inputText.value;
    newOptionElement.value = inputValue.value;

    let selectElement = document.getElementById('menu');
    selectElement.appendChild(newOptionElement);  

    inputText.value = '';
    inputValue.value = '';
}