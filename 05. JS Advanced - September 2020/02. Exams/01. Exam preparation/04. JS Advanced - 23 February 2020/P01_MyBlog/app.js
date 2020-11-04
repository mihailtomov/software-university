function solve() {
   let articles_Section = document.querySelector('main section');

   let author = document.getElementById('creator');
   let title = document.getElementById('title');
   let category = document.getElementById('category');
   let content = document.getElementById('content');

   let createBtn = document.getElementsByClassName('btn create')[0];

   createBtn.addEventListener('click', (e) => {
      e.preventDefault();

      let article = document.createElement('article');

      article.innerHTML =`<h1>${title.value}</h1>
      <p>Category:<strong>${category.value}</strong></p>
      <p>Creator:<strong>${author.value}</strong></p>
      <p>${content.value}</p>`;

      let divElement = document.createElement('div');
      divElement.classList.add('buttons');

      let deleteBtn = document.createElement('button');
      deleteBtn.classList.add('btn', 'delete');
      deleteBtn.textContent = 'Delete';

      let archiveBtn = document.createElement('button');
      archiveBtn.classList.add('btn', 'archive');
      archiveBtn.textContent = 'Archive';

      divElement.appendChild(deleteBtn);
      divElement.appendChild(archiveBtn);

      article.appendChild(divElement);
      articles_Section.appendChild(article);

      author.value = '';
      title.value = '';
      category.value = '';
      content.value = '';

      archiveBtn.addEventListener('click', () => {
         let archiveSection = document.getElementsByClassName('archive-section')[0].lastElementChild;
         let articleTitle = article.firstElementChild.textContent;

         let liElement = document.createElement('li');
         liElement.textContent = articleTitle;

         article.remove();
         archiveSection.appendChild(liElement);

         Array.from(archiveSection.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(title => archiveSection.appendChild(title));
      });

      deleteBtn.addEventListener('click', () => article.remove());
   });
}