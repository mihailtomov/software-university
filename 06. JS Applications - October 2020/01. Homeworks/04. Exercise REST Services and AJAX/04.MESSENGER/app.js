function attachEvents() {
    let sendBtn = document.getElementById('submit');
    let refreshBtn = document.getElementById('refresh');

    const url = 'https://rest-messanger.firebaseio.com/messanger.json';

    sendBtn.addEventListener('click', onSendClick);

    function onSendClick() {
        let authorInput = document.getElementById('author');
        let contentInput = document.getElementById('content');

        let author = authorInput.value;
        let content = contentInput.value;

        let message = { author, content };

        fetch(url, {method: 'POST', body: JSON.stringify(message)});

        authorInput.value = '';
        contentInput.value = '';
    }

    refreshBtn.addEventListener('click', onRefreshClick);

    function onRefreshClick() {
        let textArea = document.getElementById('messages');
        
        fetch(url)
        .then(response => response.json())
        .then(data => {
            Object.values(data).forEach((obj) => {
                textArea.textContent += `${obj.author}: ${obj.content}\n`;
            });
        });
    }
}

attachEvents();