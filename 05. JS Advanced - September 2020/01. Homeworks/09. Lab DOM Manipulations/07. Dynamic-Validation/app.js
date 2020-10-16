function validate() {
    let inputElement = document.getElementById('email');

    inputElement.addEventListener('change', () => {
        let pattern = /^[a-z]+@[a-z]+[.][a-z]+$/;
        let match = inputElement.value.match(pattern);
        if (match) {
            inputElement.classList.remove('error');
        } else {
            inputElement.classList = 'error';
        }
    });
}