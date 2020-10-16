function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (e) => {
        let width = e.offsetX;
        let maxWidth = 299;
        let percent = Math.floor((width / maxWidth) * 100);
        resultElement.textContent = `${percent}%`
    });
}