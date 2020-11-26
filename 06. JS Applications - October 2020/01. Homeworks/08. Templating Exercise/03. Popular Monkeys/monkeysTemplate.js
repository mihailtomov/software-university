import monkeys from './monkeys.js';

const elements = {
    sectionElement: () => document.querySelector('body section'),
}

getTemplate().then(generateOutput);

function generateOutput(templateSource) {
    const template = Handlebars.compile(templateSource);
    const outputHtml = template({ monkeys });

    elements.sectionElement().innerHTML = outputHtml;
}

function getTemplate() {
    return fetch('./monkeys-template.hbs').then(res => res.text());
}

elements.sectionElement().addEventListener('click', toggleInfo);

function toggleInfo(e) {
    if (e.target.tagName == 'BUTTON') {
        e.target.nextElementSibling.style.display == 'block' ?
        e.target.nextElementSibling.style.display = 'none' :
        e.target.nextElementSibling.style.display = 'block'
    }
}