function lockedProfile() {
    let hiddenElements = document.querySelectorAll('.profile div');
    Array.from(hiddenElements).forEach(el => {
        el.nextElementSibling.addEventListener('click', (e) => {
            let lockButton = e.target.parentElement.children[2];
            
            if (lockButton.checked == false) {
                if (e.target.textContent == 'Show more') {
                    e.target.previousElementSibling.style.display = 'block';
                    e.target.textContent = 'Hide it';
                } else {
                    e.target.previousElementSibling.style.display = 'none';
                    e.target.textContent = 'Show more';
                }            
            } 
        });
    });
}