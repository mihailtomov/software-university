function toggle() {
    let buttonElement = document.querySelector('.head span');
    let displayElement = document.getElementById('extra');

    displayElement.style.display == 'none' ? 
    (displayElement.style.display = 'block', buttonElement.textContent = 'Less'): 
    (displayElement.style.display = 'none', buttonElement.textContent = 'More');
}