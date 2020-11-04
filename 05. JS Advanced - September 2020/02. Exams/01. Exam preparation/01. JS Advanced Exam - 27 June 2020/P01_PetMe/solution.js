function solve() {
    let containerElements = document.getElementById('container').children;
    let name = containerElements[0];
    let age = containerElements[1];
    let kind = containerElements[2];
    let currentOwner = containerElements[3];
    let addBtn = containerElements[4];

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        
        if (name.value && Number(age.value) && kind.value && currentOwner.value) {
            let adoptionElement = document.getElementById('adoption').lastElementChild;

            let liElement = document.createElement('li');
            liElement.innerHTML = `<p><strong>${name.value}</strong> is a <strong>${age.value}</strong> year old <strong>${kind.value}</strong></p>`;
            let spanElement = document.createElement('span');
            spanElement.textContent = `Owner: ${currentOwner.value}`;
            let contactOwnerBtn = document.createElement('button');
            contactOwnerBtn.textContent = 'Contact with owner';

            liElement.appendChild(spanElement);
            liElement.appendChild(contactOwnerBtn);

            adoptionElement.appendChild(liElement);

            contactOwnerBtn.addEventListener('click', () => {
                liElement.lastElementChild.remove();

                let divElement = document.createElement('div');
                divElement.innerHTML = `<input placeholder="Enter your names"><button>Yes! I take it!</button>`;

                liElement.appendChild(divElement);

                let takeItBtn = liElement.lastElementChild.lastElementChild;

                takeItBtn.addEventListener('click', () => {
                    let takeItInput = takeItBtn.previousElementSibling;

                    if (takeItInput.value) {
                        let adoptedElement = document.getElementById('adopted').lastElementChild;

                        spanElement.textContent = `New Owner: ${takeItInput.value}`;
                        liElement.lastElementChild.remove();

                        let checkedButton = document.createElement('button');
                        checkedButton.textContent = 'Checked';

                        liElement.appendChild(checkedButton);
                        adoptedElement.appendChild(liElement);

                        checkedButton.addEventListener('click', () => liElement.remove());
                    }                    
                });
            });
        }
    });
}