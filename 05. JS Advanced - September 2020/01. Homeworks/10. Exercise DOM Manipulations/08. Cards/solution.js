function solve() {
   let cards = document.getElementsByClassName('cards')[0];
   let topCards = document.getElementById('player1Div').children;
   let bottomCards = document.getElementById('player2Div').children;
   let result = document.getElementById('result');

   cards.addEventListener('click', (e) => {
      let currentCard = e.target;
      currentCard.src = 'images/whiteCard.jpg';

      let leftSpan = result.firstElementChild;
      let rightSpan = result.lastElementChild;

      let topCardsArray = Array.from(topCards);
      let bottomCardsArray = Array.from(bottomCards);

      if (topCardsArray.includes(currentCard)) {
         leftSpan.textContent = currentCard.name;
      } else {
         rightSpan.textContent = currentCard.name;
      }

      if (leftSpan.textContent && rightSpan.textContent) {
         let topCard = topCardsArray.find(c => c.name == leftSpan.textContent);
         let bottomCard = bottomCardsArray.find(c => c.name == rightSpan.textContent);

         if (Number(topCard.name) > Number(bottomCard.name)) {
            topCard.style.borderWidth = '2px';
            topCard.style.borderStyle = 'solid';
            topCard.style.borderColor = 'green';

            bottomCard.style.borderWidth = '2px';
            bottomCard.style.borderStyle = 'solid';
            bottomCard.style.borderColor = 'red';
         } else {
            topCard.style.borderWidth = '2px';
            topCard.style.borderStyle = 'solid';
            topCard.style.borderColor = 'red';

            bottomCard.style.borderWidth = '2px';
            bottomCard.style.borderStyle = 'solid';
            bottomCard.style.borderColor = 'green';
         }
         
         leftSpan.textContent = '';
         rightSpan.textContent = '';
         
         let history = document.getElementById('history');
         history.textContent += `[${topCard.name} vs ${bottomCard.name}] `;
      }
   });
}