function solve() {
    let buttonElement = document.getElementsByTagName('button')[0];
    buttonElement.addEventListener('click', addNameToDatabase);

    function addNameToDatabase() {
        let input = document.getElementsByTagName('input')[0];
        let name = input.value;
        let letters = document.getElementsByTagName('ol')[0].children;
        let nameCapitalized = name.charAt(0).toUpperCase() + name.slice(1).toLowerCase();
        let startingLetter = nameCapitalized.charCodeAt(0);
        if (letters[startingLetter - 65].textContent == '') {
            letters[startingLetter - 65].textContent = nameCapitalized;
        } else {
            letters[startingLetter - 65].textContent += `, ${nameCapitalized}`;
        }
        input.value = '';
    }
}