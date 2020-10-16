function addItem() {
    let ulElement = document.getElementById('items');
    let newItemText = document.getElementById('newText');

    let newLiElement = document.createElement('li');
    newLiElement.textContent = `${newItemText.value} `;
    let newAElement = document.createElement('a');
    newAElement.textContent = '[Delete]';
    newAElement.setAttribute('href', '#');

    newAElement.addEventListener('click', (e) => {
        e.target.parentElement.remove();
    });

    newLiElement.appendChild(newAElement);
    ulElement.appendChild(newLiElement);
    newItemText.value = '';
}