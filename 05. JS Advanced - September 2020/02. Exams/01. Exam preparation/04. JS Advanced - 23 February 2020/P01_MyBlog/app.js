function solve() {
   const elements = {
      createBtn: () => document.querySelector('form button.create'),
      creator: () => document.getElementById('creator'),
      title: () => document.getElementById('title'),
      category: () => document.getElementById('category'),
      content: () => document.getElementById('content'),
      articlesSection: () => document.querySelector('div.site-content main section'),
      archiveSection: () => document.querySelector('.archive-section ul'),
   }

   elements.createBtn().addEventListener('click', onCreateClick);

   function onCreateClick(e) {
      e.preventDefault();

      const creator = elements.creator();
      const title = elements.title();
      const category = elements.category();
      const content = elements.content();

      const articleElement = document.createElement('article');

      // articleElement.innerHTML = `<h1>${title.value}</h1>
      // <p>Category: <strong>${category.value}</strong></p>
      // <p>Creator: <strong>${creator.value}</strong></p>
      // <p>${content.value}</p>`;

      const titleElement = createDOMElement('h1', title.value);

      const categoryElement = createDOMElement('p', 'Category: ');
      const categoryStrongElement = createDOMElement('strong', category.value);
      categoryElement.appendChild(categoryStrongElement);

      const creatorElement = createDOMElement('p', 'Creator: ');
      const creatorStrongElement = createDOMElement('strong', creator.value);
      creatorElement.appendChild(creatorStrongElement);

      const contentElement = createDOMElement('p', content.value);

      articleElement.appendChild(titleElement);
      articleElement.appendChild(categoryElement);
      articleElement.appendChild(creatorElement);
      articleElement.appendChild(contentElement);

      const buttonsDivElement = createDOMElement('div', '', 'buttons');
      const deleteBtn = createDOMElement('button', 'Delete', 'btn', 'delete');
      const archiveBtn = createDOMElement('button', 'Archive', 'btn', 'archive');

      buttonsDivElement.appendChild(deleteBtn);
      buttonsDivElement.appendChild(archiveBtn);

      articleElement.appendChild(buttonsDivElement);

      elements.articlesSection().appendChild(articleElement);

      archiveBtn.addEventListener('click', onArchiveClick);
      deleteBtn.addEventListener('click', onDeleteClick);

      creator.value = '';
      title.value = '';
      category.value = '';
      content.value = '';
   }

   function onArchiveClick(e) {
      const archiveSection = elements.archiveSection();

      const currentArticle = e.target.parentElement.parentElement;
      const currentHeading = currentArticle.firstElementChild.textContent;

      const liElement = createDOMElement('li', currentHeading);
      archiveSection.appendChild(liElement);

      // Array.from(archiveSection.children)
      //    .sort((a, b) => a.textContent.localeCompare(b.textContent))
      //    .forEach(el => archiveSection.appendChild(el));

      let sortedLi = Array.from(archiveSection.getElementsByTagName('li'))
         .sort((a, b) => (a.innerHTML).localeCompare(b.innerHTML));

      while (archiveSection.firstChild) {
         archiveSection.removeChild(archiveSection.firstChild);
      }

      for (const element of sortedLi) {
         archiveSection.appendChild(element);
      }

      currentArticle.remove();
   }

   function onDeleteClick(e) {
      e.target.parentElement.parentElement.remove();
   }

   function createDOMElement(type, textContent, ...classList) {
      const element = document.createElement(type);
      element.textContent = textContent;
      if (classList.length > 0) {
         element.classList.add(...classList);
      }
      return element;
   }
}