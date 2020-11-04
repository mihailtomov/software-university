function solve() {
    let taskElement = document.getElementById('task');
    let descriptionElement = document.getElementById('description');
    let dueDateElement = document.getElementById('date');

    let wrapperElement = document.getElementsByClassName('wrapper')[0];
    
    let addBtn = document.getElementById('add');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (taskElement.value && descriptionElement.value && dueDateElement.value) {
            let openSectionElement = wrapperElement.children[1].lastElementChild;
            let articleElement = document.createElement('article');

            articleElement.innerHTML = `<h3>${taskElement.value}</h3>`;
            articleElement.innerHTML += `<p>Description: ${descriptionElement.value}</p>`;
            articleElement.innerHTML += `<p>Due Date: ${dueDateElement.value}</p>`;

            let divElement = document.createElement('div');
            divElement.className = 'flex';

            let startBtn = document.createElement('button');
            startBtn.className = 'green';
            startBtn.textContent = 'Start';
            let deleteBtn = document.createElement('button');
            deleteBtn.className = 'red';
            deleteBtn.textContent = 'Delete';

            divElement.appendChild(startBtn);
            divElement.appendChild(deleteBtn);
            articleElement.appendChild(divElement);
            openSectionElement.appendChild(articleElement);

            taskElement.value = '';
            descriptionElement.value = '';
            dueDateElement.value = '';

            startBtn.addEventListener('click', () => {
                let inProgressSectionElement = wrapperElement.children[2].lastElementChild;

                divElement.children[0].remove();
                divElement.children[0].remove();

                let deleteBtn = document.createElement('button');
                deleteBtn.className = 'red';
                deleteBtn.textContent = 'Delete';

                let finishBtn = document.createElement('button');
                finishBtn.className = 'orange';
                finishBtn.textContent = 'Finish';

                divElement.appendChild(deleteBtn);
                divElement.appendChild(finishBtn);

                inProgressSectionElement.appendChild(articleElement);

                deleteBtn.addEventListener('click', () => articleElement.remove());

                finishBtn.addEventListener('click', () => {
                    let completeSectionElement = wrapperElement.children[3].lastElementChild;
                    articleElement.lastElementChild.remove();
                    completeSectionElement.appendChild(articleElement);
                });
            });

            deleteBtn.addEventListener('click', () => articleElement.remove());
        } 
    });
}