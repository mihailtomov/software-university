function attachEventsListeners() {
    let inputElements = document.querySelectorAll('input[type="button"]');
    Array.from(inputElements).forEach(el => {
        el.addEventListener('click', (e) => {
            let days = document.getElementById('days');
            let hours = document.getElementById('hours');
            let minutes = document.getElementById('minutes');
            let seconds = document.getElementById('seconds');
            let target = e.target.previousElementSibling;
            switch (target.id) {
                case 'days':
                    hours.value = target.value * 24;
                    minutes.value = hours.value * 60;
                    seconds.value = minutes.value * 60;
                    break;
                case 'hours':
                    days.value = target.value / 24;
                    minutes.value = target.value * 60;
                    seconds.value = minutes.value * 60;
                    break;
                case 'minutes':
                    hours.value = target.value / 60;
                    days.value = hours.value / 24;
                    seconds.value = target.value * 60;
                    break;
                case 'seconds':
                    minutes.value = target.value / 60;
                    hours.value = minutes.value / 60;
                    days.value = hours.value / 24;
                    break;
            }
        });
    });
}