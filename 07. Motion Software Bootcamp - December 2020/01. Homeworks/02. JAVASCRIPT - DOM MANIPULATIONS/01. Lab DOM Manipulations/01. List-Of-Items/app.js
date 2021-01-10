document.addEventListener('DOMContentLoaded', main);

function main() {
    const input = document.getElementById('newItemText');
    const list = document.getElementById('items');
    const addButton = document.getElementById('addBtn');

    if (input === null || list === null || addButton === null) {
        throw new Error('Missing DOM element');
    }

    const boundAddClickHandler = addClickHandler.bind(undefined,
        addToHTML.bind(undefined, list), // appendOutput
        createElement.bind(undefined, 'li'), // elementCreator
        input
    );

    addButton.addEventListener('click', boundAddClickHandler)
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

function addToHTML(parent, child) {
    parent.appendChild(child);
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