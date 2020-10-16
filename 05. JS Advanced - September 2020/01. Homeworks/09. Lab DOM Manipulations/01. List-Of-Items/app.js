function addItem() {
    let ulElement = document.getElementById('items');
    let newItemText = document.getElementById('newItemText');

    let newLiElement = document.createElement('li');
    newLiElement.textContent = newItemText.value;

    ulElement.appendChild(newLiElement);
    newItemText.value = '';
}