const htmlSelector = {
    booksContainer: () => document.querySelector('table tbody'),
    loadBooksBtn: () => document.getElementById('loadBooks'),
    updateBtn: () => document.querySelector('form[id="edit-form"] button'),
    submitBtn: () => document.querySelector('form[id="create-form"] button'),
    createBookForm: () => document.getElementById('create-form'),
    createTitleInput: () => document.getElementById('create-title'),
    createAuthorInput: () => document.getElementById('create-author'),
    createIsbnInput: () => document.getElementById('create-isbn'),
    editBookForm: () => document.getElementById('edit-form'),
    editTitleInput: () => document.getElementById('edit-title'),
    editAuthorInput: () => document.getElementById('edit-author'),
    editIsbnInput: () => document.getElementById('edit-isbn'),
}

htmlSelector.loadBooksBtn().addEventListener('click', loadBooks);
htmlSelector.submitBtn().addEventListener('click', createBook);
htmlSelector.updateBtn().addEventListener('click', updateBook);

function loadBooks() {
    htmlSelector.editBookForm().style.display = 'none';
    htmlSelector.booksContainer().innerHTML = '';

    fetch('https://books-exercise-def80.firebaseio.com/books.json')
        .then(res => res.json())
        .then(displayBooks)
}

function createBook(e) {
    e.preventDefault();

    let titleInput = htmlSelector.createTitleInput();
    let authorInput = htmlSelector.createAuthorInput();
    let isbnInput = htmlSelector.createIsbnInput();

    if (titleInput.value != '' && authorInput.value != '' && isbnInput.value != '') {
        let createBookObj = {
            title: titleInput.value,
            author: authorInput.value,
            isbn: isbnInput.value
        };

        fetch('https://books-exercise-def80.firebaseio.com/books.json', { method: 'POST', body: JSON.stringify(createBookObj) })
            .then(loadBooks);

        titleInput.value = '';
        authorInput.value = '';
        isbnInput.value = '';
    }
}

function updateBook(e) {
    e.preventDefault();

    let bookId = e.currentTarget.getAttribute('data-key');

    let editTitleInput = htmlSelector.editTitleInput();
    let editAuthorInput = htmlSelector.editAuthorInput();
    let editIsbnInput = htmlSelector.editIsbnInput();

    let updateBookObj = {
        title: editTitleInput.value,
        author: editAuthorInput.value,
        isbn: editIsbnInput.value,
    }

    fetch(`https://books-exercise-def80.firebaseio.com/books/${bookId}.json`, { method: 'PATCH', body: JSON.stringify(updateBookObj) })
        .then(loadBooks);

    htmlSelector.editBookForm().style.display = 'none';
}

function displayBooks(booksData) {
    Object.keys(booksData)
        .forEach(key => {
            let { title, author, isbn } = booksData[key];

            let trElement = createDOMElement('tr', '');

            let titleElement = createDOMElement('td', title);
            let authorElement = createDOMElement('td', author);
            let isbnElement = createDOMElement('td', isbn);

            let buttonsContainerElement = createDOMElement('td', '');

            let editBtn = createDOMElement('button', 'Edit');
            editBtn.setAttribute('data-key', key);
            editBtn.addEventListener('click', displayEditForm);

            let deleteBtn = createDOMElement('button', 'Delete');
            deleteBtn.setAttribute('data-key', key);
            deleteBtn.addEventListener('click', deleteBook);

            appendChildren(buttonsContainerElement, [editBtn, deleteBtn]);
            appendChildren(trElement, [titleElement, authorElement, isbnElement, buttonsContainerElement]);

            htmlSelector.booksContainer().appendChild(trElement);
        })
}

function displayEditForm() {
    let editFormElement = htmlSelector.editBookForm();
    let bookId = this.getAttribute('data-key');

    editFormElement.style.display = 'block';
    editFormElement.lastElementChild.setAttribute('data-key', bookId);

    let editTitleInput = htmlSelector.editTitleInput();
    let editAuthorInput = htmlSelector.editAuthorInput();
    let editIsbnInput = htmlSelector.editIsbnInput();

    let trElement = this.parentElement.parentElement;

    let currentTitleValue = trElement.children[0].textContent;
    let currentAuthorValue = trElement.children[1].textContent;
    let currentIsbnValue = trElement.children[2].textContent;

    editTitleInput.value = currentTitleValue;
    editAuthorInput.value = currentAuthorValue;
    editIsbnInput.value = currentIsbnValue;
};

function deleteBook() {
    htmlSelector.editBookForm().style.display = 'none';

    let bookId = this.getAttribute('data-key');

    fetch(`https://books-exercise-def80.firebaseio.com/books/${bookId}.json`, { method: 'DELETE' })
        .then(loadBooks);
}

function createDOMElement(type, text) {
    let newElement = document.createElement(type);
    newElement.textContent = text;

    return newElement;
}

function appendChildren(parentElement, children) {
    children.forEach(el => parentElement.appendChild(el));
}