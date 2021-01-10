document.addEventListener('DOMContentLoaded', main);

function main() {
    const input = document.getElementById('newText');
    const list = document.getElementById('items');
    const addButton = document.getElementById('addBtn');

    if (input === null || list === null || addButton === null) {
        throw new Error('Missing DOM element');
    }

    const boundAddClickHandler = addClickHandler.bind(undefined,
        addToHTML.bind(undefined, list),
        elementCreator,
        input
    );

    addButton.addEventListener('click', boundAddClickHandler);
    list.addEventListener('click', listClickHandler);
}

function listClickHandler(e) {
    if (e.target.nodeName === 'A') {
        removeItem(
            removeFromHTMLByIndex.bind(undefined, e.currentTarget),
            findChildIndexByRef.bind(undefined, e.currentTarget),
            e.target.parentNode,
        )
    }
}

function addClickHandler(appendOutput, elementCreator, input) {
    addItem(appendOutput, elementCreator, input.value);

    input.value = '';
}

function addItem(appendOutput, elementCreator, value) {
    if (value != '') {
        appendOutput(elementCreator(value));
    }
}

function removeItem(output, elementLocator, element) {
    output(elementLocator(element))
}

function addToHTML(parent, child) {
    parent.appendChild(child);
}

function removeFromHTMLByIndex(parent, index) {
    parent.removeChild(parent.children[index])
}

function findChildIndexByRef(parent, child) {
    return Array.prototype.findIndex.call(
        parent.children,
        x => x === child,
    )
}

function createElement(type, content) {
    let e = document.createElement(type);
    if (typeof content === "string") {
        e.innerHTML = content;
    }
    if (typeof content === "object") {
        e.appendChild(content);
    }
    return e;
}

function elementCreator(value) {
    let li = createElement('li');
    let a = createElement('a');

    li.appendChild(document.createTextNode(`${value} `));
    a.appendChild(document.createTextNode('[Delete]'));
    a.setAttribute('href', 'javascript:;');

    li.appendChild(a);
    return li;
}