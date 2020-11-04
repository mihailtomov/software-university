function solve() {
    let inputElements = document.getElementsByTagName('input');

    let lectureName = inputElements[0];
    let date = inputElements[1];
    let optionElements = document.getElementsByTagName('select')[0];
    let defaultModule = optionElements.firstElementChild;

    let addBtn = document.getElementsByTagName('button')[0];

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        let selectedOption = Array.from(optionElements).find(el => el.selected);

        if (lectureName.value && date.value && selectedOption != defaultModule) {
            let trainingsSection = document.getElementsByClassName('modules')[0];

            let divElement = document.createElement('div');
            divElement.className = 'module';

            let h3Element = document.createElement('h3');
            h3Element.textContent = `${selectedOption.textContent.toUpperCase()}-MODULE`;

            let ulElement = document.createElement('ul');

            let liElement = document.createElement('li');
            liElement.className = 'flex';

            let h4Element = document.createElement('h4');

            let dateArgs = date.value.split('T');
            let dateArg = dateArgs[0];
            let timeArg = dateArgs[1];
            let pattern = /-/g;

            h4Element.textContent = `${lectureName.value} - ${dateArg.replace(pattern, '/')} - ${timeArg}`;

            let deleteBtn = document.createElement('button');
            deleteBtn.className = 'red';
            deleteBtn.textContent = 'Del';

            liElement.appendChild(h4Element);
            liElement.appendChild(deleteBtn);

            ulElement.appendChild(liElement);

            divElement.appendChild(h3Element);
            divElement.appendChild(ulElement);

            let moduleElements = trainingsSection.children;

            if (!Array.from(moduleElements).some(m => m.firstElementChild.textContent == h3Element.textContent)) {
                trainingsSection.appendChild(divElement);
            } else {
                let existingModule = Array.from(moduleElements).find(m => m.firstElementChild.textContent == h3Element.textContent);
                existingModule.lastElementChild.appendChild(liElement);
            }

            if (Array.from(moduleElements).some(m => m.lastElementChild.children.length > 1)) {
                let searchedModule = Array.from(moduleElements).find(m => m.lastElementChild.children.length > 1);

                let liElements = searchedModule.lastElementChild.children;

                let h4Elements = [];

                Array.from(liElements).forEach(li => {
                    h4Elements.push(li.firstElementChild);
                });

                h4Elements = h4Elements.sort((a, b) => a.textContent.split(' - ')[1].localeCompare(b.textContent.split(' - ')[1]));

                Array.from(liElements).forEach(li => {
                    li.firstElementChild.remove();
                });

                for (let i = 0; i < Array.from(liElements).length; i++) {
                    Array.from(liElements)[i].prepend(h4Elements[i]);
                }
            } 

            deleteBtn.addEventListener('click', (e) => {
                let ulElement = e.target.parentElement.parentElement;

                if (ulElement.children.length > 1) {
                    e.target.parentElement.remove();
                } else {
                    e.target.parentElement.parentElement.parentElement.remove();
                }
            });
        }
    })
};