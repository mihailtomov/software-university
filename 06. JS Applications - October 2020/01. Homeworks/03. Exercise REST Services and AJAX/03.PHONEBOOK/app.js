function attachEvents() {
    let loadBtn = document.getElementById('btnLoad');
    let createBtn = document.getElementById('btnCreate');

    const requestUrl = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    let phonebook = document.getElementById('phonebook');

    loadBtn.addEventListener('click', onLoadClick);

    function onLoadClick() {
        fetch(requestUrl)
            .then(response => response.json())
            .then(data => {
                Object.entries(data).forEach(([key, value]) => {
                    let liElement = document.createElement('li');
                    liElement.textContent = `${value.person}: ${value.phone}`;

                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';

                    liElement.appendChild(deleteBtn);
                    phonebook.appendChild(liElement);

                    deleteBtn.addEventListener('click', () => {
                        const deleteUrl = `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`;
                        // there is a problem with the firebase server for POST and DELETE
                        fetch(deleteUrl, { method: 'DELETE' });

                        liElement.remove();
                    });
                });
            });
    }

    createBtn.addEventListener('click', onCreateClick);

    function onCreateClick() {
        let personInput = document.getElementById('person');
        let phoneInput = document.getElementById('phone');
        // there is a problem with the firebase server for POST and DELETE
        let person = personInput.value;
        let phone = phoneInput.value;

        let personInfo = { person, phone };

        fetch(requestUrl, { method: 'POST', body: JSON.stringify(personInfo) });

        personInput.value = '';
        phoneInput.value = '';

        onLoadClick();
    }
}

attachEvents();