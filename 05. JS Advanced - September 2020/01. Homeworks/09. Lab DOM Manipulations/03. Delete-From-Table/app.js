function deleteByEmail() {
    let inputElement = document.querySelector('label input');
    let tableRows = document.querySelector('tbody').children;
    let resultElement = document.getElementById('result');

    let inputEmail = inputElement.value;
    let searchedElement = Array.from(tableRows).find(r => r.children[1].textContent == inputEmail);
    
    if (searchedElement) {
        searchedElement.remove();
        resultElement.textContent = 'Deleted.';
    } else {
        resultElement.textContent = 'Not found.';
    }

    inputElement.value = '';
}