function create(words) {
   let contentElement = document.getElementById('content');

   words.forEach(word => {
      let paragraphElement = document.createElement('p');
      paragraphElement.textContent = word;
      paragraphElement.style.display = 'none';
      let divElement = document.createElement('div');
      divElement.appendChild(paragraphElement);
      contentElement.appendChild(divElement);
   });

   contentElement.addEventListener('click', (e) => {
      if (e.target.tagName == 'DIV' && !e.target.hasAttribute('id')) {
         e.target.children[0].style.display = '';
      }
   });
}