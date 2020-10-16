function solve() {
   let searchField = document.getElementById('searchField');
   let searchButton = document.getElementById('searchBtn');
   let tableRows = document.getElementsByTagName('tbody')[0].children;

   searchButton.addEventListener('click', (e) => {
      let input = searchField.value;
      searchField.value = '';
      let alreadySelected = document.querySelectorAll('.select');
      if (alreadySelected) {
         Array.from(alreadySelected).forEach(el => {
            el.classList.remove('select');
         });
      }
      Array.from(tableRows).forEach(row => {
         Array.from(row.children).forEach(data => {
            if (data.textContent.includes(input)) {
               row.classList = 'select';
            }
         });
      });
   });
}