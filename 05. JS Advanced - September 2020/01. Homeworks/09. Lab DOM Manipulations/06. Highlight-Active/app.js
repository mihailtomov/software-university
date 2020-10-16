function focus() {
    let inputElements = document.querySelectorAll('input[type="text"]');
    
    Array.from(inputElements).forEach(el => {
        el.addEventListener('focus', () => {
            el.parentElement.classList = 'focused';
        });
        el.addEventListener('blur', () => {
            el.parentElement.classList.remove('focused');
        });
    });
}