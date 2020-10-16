function stopwatch() {
    let timeElement = document.getElementById('time');
    let startButtonElement = document.getElementById('startBtn');
    let stopButtonElement = document.getElementById('stopBtn');
    let interval;

    startButtonElement.addEventListener('click', () => {
        timeElement.textContent = '00:00'
        startButtonElement.setAttribute('disabled', true);
        stopButtonElement.removeAttribute('disabled');

        interval = setInterval(() => {
            let args = timeElement.textContent.split(':');
            let minutes = Number(args[0]);
            let seconds = Number(args[1]);
            seconds++;
            if (seconds > 59) {
                minutes++;
                seconds = 0;
            }
            timeElement.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
        }, 1000);
    });

    stopButtonElement.addEventListener('click', () => {
        clearInterval(interval);
        startButtonElement.removeAttribute('disabled');
        stopButtonElement.setAttribute('disabled', true);
    });
}