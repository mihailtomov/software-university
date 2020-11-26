function solve() {
    let infoBox = document.getElementById('info').firstElementChild;
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');
    let currentId = 'depot';
    let stopName = '';

    function depart() {
        const url = `https://judgetests.firebaseio.com/schedule/${currentId}.json`;

        fetch(url)
            .then(response => response.json())
            .then(busInfo => {
                infoBox.textContent = `Next stop ${busInfo.name}`;
                currentId = busInfo.next;
                stopName = busInfo.name;
                arriveBtn.disabled = false;
                departBtn.disabled = true;
            })
            .catch(() => {
                infoBox.textContent = `Error`;
                arriveBtn.disabled = true;
                departBtn.disabled = true;
            });
    }

    function arrive() {
        infoBox.textContent = `Arriving at ${stopName}`;
        arriveBtn.disabled = true;
        departBtn.disabled = false;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();