function attachEvents() {
    let loadBtn = document.querySelector('.load');
    let addBtn = document.querySelector('.add');

    let addFormInputs = document.querySelectorAll('fieldset#addForm input');

    let anglerInput = document.querySelector('fieldset#addForm input.angler');
    let weightInput = document.querySelector('fieldset#addForm input.weight');
    let speciesInput = document.querySelector('fieldset#addForm input.species');
    let locationInput = document.querySelector('fieldset#addForm input.location');
    let baitInput = document.querySelector('fieldset#addForm input.bait');
    let captureTimeInput = document.querySelector('fieldset#addForm input.captureTime');

    let baseUrl = 'https://fisher-game.firebaseio.com/catches';

    loadBtn.addEventListener('click', onLoadBtnClick);

    function onLoadBtnClick() {
        fetch(baseUrl + '.json')
            .then(response => response.json())
            .then(catches => {
                let catchesDivElement = document.getElementById('catches');
                let exampleCatchElement = document.querySelector('.catch');

                Object.entries(catches).forEach(([key, value]) => {
                    let newCatchElement = exampleCatchElement.cloneNode(true);

                    newCatchElement.setAttribute('data-id', key);

                    let newCatchInputs = newCatchElement.querySelectorAll('input');
                    let updateBtn = newCatchElement.querySelector('.update');
                    let deleteBtn = newCatchElement.querySelector('.delete');

                    updateBtn.addEventListener('click', onUpdateBtnClick);
                    deleteBtn.addEventListener('click', onDeleteBtnClick);

                    let anglerInput = newCatchInputs[0];
                    let weightInput = newCatchInputs[1];
                    let speciesInput = newCatchInputs[2];
                    let locationInput = newCatchInputs[3];
                    let baitInput = newCatchInputs[4];
                    let captureTimeInput = newCatchInputs[5];

                    anglerInput.setAttribute('value', value.angler);
                    baitInput.setAttribute('value', value.bait);
                    captureTimeInput.setAttribute('value', value.captureTime);
                    locationInput.setAttribute('value', value.location);
                    speciesInput.setAttribute('value', value.species);
                    weightInput.setAttribute('value', value.weight);

                    catchesDivElement.appendChild(newCatchElement);
                });

                exampleCatchElement.remove();
            });
    }

    addBtn.addEventListener('click', onAddBtnClick);

    function onAddBtnClick() {
        let catchObj = getCatchObject(addFormInputs);

        fetch(baseUrl + '.json', { method: 'POST', body: JSON.stringify(catchObj) });

        anglerInput.value = '';
        weightInput.value = '';
        speciesInput.value = '';
        locationInput.value = '';
        baitInput.value = '';
        captureTimeInput.value = '';
    }

    function onUpdateBtnClick() {
        let currentCatchDiv = this.parentElement;

        let catchId = currentCatchDiv.getAttribute('data-id');
        let updateUrl = baseUrl + `/${catchId}.json`;

        let currentInputs = currentCatchDiv.querySelectorAll('input');

        let catchObj = getCatchObject(currentInputs);

        fetch(updateUrl, { method: 'PUT', body: JSON.stringify(catchObj) });

        onLoadBtnClick();
    }

    function onDeleteBtnClick() {
        let currentCatchDiv = this.parentElement;

        let catchId = currentCatchDiv.getAttribute('data-id');
        let deleteUrl = baseUrl + `/${catchId}.json`;

        fetch(deleteUrl, { method: 'DELETE' });
        currentCatchDiv.remove();
    }

    function getCatchObject(inputs) {
        let anglerInput = inputs[0];
        let weightInput = inputs[1];
        let speciesInput = inputs[2];
        let locationInput = inputs[3];
        let baitInput = inputs[4];
        let captureTimeInput = inputs[5];

        return {
            angler: anglerInput.value,
            weight: weightInput.value,
            species: speciesInput.value,
            location: locationInput.value,
            bait: baitInput.value,
            captureTime: captureTimeInput.value,
        }
    }
}

attachEvents();