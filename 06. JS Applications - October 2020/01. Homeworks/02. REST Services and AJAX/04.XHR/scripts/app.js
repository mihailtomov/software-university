function loadRepos() {
   const httpRequest = new XMLHttpRequest();
   const url = 'https://api.github.com/users/testnakov/repos';
   const resElement = document.getElementById('res');

   httpRequest.addEventListener('readystatechange', function() {
      if (this.readyState == 4 && this.status == 200) {
         resElement.textContent = this.responseText;
      }
   });

   httpRequest.open('GET', url);
   httpRequest.send();
}