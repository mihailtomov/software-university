(() => {
    renderCatTemplate();

    const elements = {
        sectionElement: () => document.querySelector('section#allCats'),
    }

    function renderCatTemplate() {
        getTemplate().then(generateOutput)
    }

    function generateOutput(templateSource) {
        const template = Handlebars.compile(templateSource);
        const outputHtml = template({ cats });

        elements.sectionElement().innerHTML = outputHtml;
    }

    function getTemplate() {
        return fetch('./cats-template.hbs').then(res => res.text());
    }

    elements.sectionElement().addEventListener('click', toggleShowButton);

    function toggleShowButton(e) {
        if (e.target.className == 'showBtn') {
            if (e.target.nextElementSibling.style.display == 'block') {
                e.target.nextElementSibling.style.display = 'none';
                e.target.textContent = 'Show status code';
            } else {
                e.target.nextElementSibling.style.display = 'block';
                e.target.textContent = 'Hide status code';
            }
        }
    }
})();