function solve() {
    let containerElements = document.getElementById('container').children;
    let name = containerElements[0];
    let hall = containerElements[1];
    let ticketPrice = containerElements[2];
    let onScreenBtn = containerElements[3];

    onScreenBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (name.value && hall.value && Number(ticketPrice.value)) {
            let onScreenSection = document.getElementById('movies').lastElementChild;
            let liElement = document.createElement('li');

            let spanElement = document.createElement('span');
            spanElement.textContent = name.value;
            let strongElement = document.createElement('strong');
            strongElement.textContent = `Hall: ${hall.value}`;
            let divElement = document.createElement('div');
            divElement.innerHTML = `<strong>${Number(ticketPrice.value).toFixed(2)}</strong><input placeholder="Tickets Sold"><button>Archive</button>`;

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(divElement);

            onScreenSection.appendChild(liElement);

            name.value = '';
            hall.value = '';
            ticketPrice.value = '';

            let archiveBtn = divElement.lastElementChild;

            archiveBtn.addEventListener('click', () => {
                let ticketPrice = divElement.firstElementChild;
                let ticketsSold = archiveBtn.previousElementSibling;

                if (Number(ticketsSold.value)) {
                    let archiveSection = document.querySelector('#archive ul');

                    divElement.remove();
                    strongElement.textContent = `Total amount: ${(ticketPrice.textContent * Number(ticketsSold.value)).toFixed(2)}`;

                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';

                    liElement.appendChild(deleteBtn);
                    archiveSection.appendChild(liElement);

                    deleteBtn.addEventListener('click', () => liElement.remove());

                    let clearBtn = archiveSection.nextElementSibling;

                    clearBtn.addEventListener('click', () => {
                        Array.from(archiveSection.children).forEach(el => {
                            el.remove();
                        });
                    });
                }
            });
        }
    });
}