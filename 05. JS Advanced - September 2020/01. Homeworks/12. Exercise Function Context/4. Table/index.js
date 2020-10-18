function solve(){
   let tableElements = document.querySelector('tbody').children;

   Array.from(tableElements).forEach(tableRow => {
      tableRow.addEventListener('click', (e) => {
         let elementsArray = Array.from(tableElements);

         if (elementsArray.some(tr => tr.style.backgroundColor)) {
            let clickedElement = elementsArray.find(tr => tr.style.backgroundColor);

            if (clickedElement != e.currentTarget) {
               clickedElement.style.backgroundColor = '';
               e.currentTarget.style.backgroundColor = '#413f5e';
            } else {
               e.currentTarget.style.backgroundColor = '';
            }
         } else {
            e.currentTarget.style.backgroundColor = '#413f5e';
         }
      })
   })
}