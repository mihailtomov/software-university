function solve() {
    let dropdownButton = document.getElementById('dropdown');
    let dropdownList = document.getElementById('dropdown-ul');
    let boxElement = document.getElementById('box');
    boxElement.style.backgroundColor = 'black';

    dropdownButton.addEventListener('click', () => {
        if (!dropdownList.style.display || dropdownList.style.display == 'none') {
            dropdownList.style.display = 'block';
        } else {
            dropdownList.style.display = 'none';
            boxElement.style.backgroundColor = 'black';
            boxElement.style.color = 'white';
        }
    });

    dropdownList.addEventListener('click', (e) => {
        let newColor = e.target.textContent;
        
        boxElement.style.backgroundColor = newColor;
        boxElement.style.color = 'black';
    });
}