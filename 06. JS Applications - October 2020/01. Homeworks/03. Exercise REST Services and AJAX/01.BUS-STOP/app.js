function getInfo() {
    let stopIdInput = document.getElementById('stopId');
    let stopNameDiv = document.getElementById('stopName');
    let busesList = document.getElementById('buses');

    let url = `https://judgetests.firebaseio.com/businfo/${stopIdInput.value}.json`;

    stopIdInput.value = '';
    busesList.innerHTML = '';

    fetch(url)
    .then(response => response.json())
    .then(busData => {
        stopNameDiv.textContent = busData.name;

        Object.entries(busData.buses).forEach(([busId, time]) => {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${busId} arrives in ${time} minutes`;

            busesList.appendChild(liElement);
        });
    })
    .catch(() => {
        stopNameDiv.textContent = 'Error';
    });
}