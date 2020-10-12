function solve() {
   let button = document.getElementById('send');
   button.addEventListener('click', () => {
      let input = document.getElementById('chat_input');
      let message = input.value;
      let newDivElement = document.createElement('div');
      newDivElement.className = 'message my-message';
      newDivElement.textContent = message;
      let chatMessagesDiv = document.getElementById('chat_messages');
      chatMessagesDiv.appendChild(newDivElement);
      input.value = '';
   });
}