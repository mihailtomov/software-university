function encodeAndDecodeMessages() {
    let buttonElements = document.querySelectorAll('#main div button');
    let encodeButton = buttonElements[0];
    let decodeButton = buttonElements[1];
    let textAreaElements = document.querySelectorAll('#main div textarea');
    let encodeElement = textAreaElements[0];
    let decodeElement = textAreaElements[1];

    encodeButton.addEventListener('click', (e) => {
        let message = encodeElement.value;
        let encodedMessage = '';
        for (let i = 0; i < message.length; i++) {
            encodedMessage += String.fromCharCode(message.charCodeAt(i) + 1);
        }
        encodeElement.value = '';
        decodeElement.value = encodedMessage;
    });

    decodeButton.addEventListener('click', (e) => {
        let encodedMessage = decodeElement.value;
        let decodedMessage = '';
        for (let i = 0; i < encodedMessage.length; i++) {
            decodedMessage += String.fromCharCode(encodedMessage.charCodeAt(i) - 1);
        }
        decodeElement.value = decodedMessage;
    });
}