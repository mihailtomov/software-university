const elements = {
    townsInput: () => document.querySelector('input#towns'),
    loadBtn: () => document.querySelector('button#btnLoadTowns'),
    townsContainer: () => document.querySelector('div#root'),
}

elements.loadBtn().addEventListener('click', showTowns);

function showTowns(e) {
    e.preventDefault();

    const { value } = elements.townsInput();
    const townsArray = value.split(/[ ,]+/g);
    const towns = { towns: townsArray };

    getTemplate()
        .then(templateSource => {
            const template = Handlebars.compile(templateSource);
            const outputHtml = template(towns);
            elements.townsContainer().innerHTML = outputHtml;
        });

    elements.townsInput().value = '';
}

function getTemplate() {
    return fetch('./towns-template.hbs').then(res => res.text());
}