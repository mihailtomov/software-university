const htmlSelector = {
    loadBtn: () => document.getElementById('load'),
    studentsContainer: () => document.querySelector('body table tbody'),
    idInput: () => document.getElementById('student-id'),
    firstNameInput: () => document.getElementById('student-first'),
    lastNameInput: () => document.getElementById('student-last'),
    facultyNumberInput: () => document.getElementById('student-faculty'),
    gradeInput: () => document.getElementById('student-grade'),
    createBtn: () => document.getElementById('create'),
    error: () => document.querySelector('p.error'),
}

const studentTemplate = (data) => `
    <tr>
        <td>${data.ID}</td>
        <td>${data.FirstName}</td>
        <td>${data.LastName}</td>
        <td>${data.FacultyNumber}</td>
        <td>${data.Grade}</td>
        <td>
            <button>Delete</button>
        </td>
     </tr>
`;

const baseUrl = 'https://books-exercise-def80.firebaseio.com/students.json';

htmlSelector.loadBtn().addEventListener('click', getStudents);
htmlSelector.createBtn().addEventListener('click', createStudent);
htmlSelector.studentsContainer().addEventListener('click', deleteStudent);

function getStudents() {
    fetch(baseUrl)
        .then(res => res.json())
        .then(displayStudents);
}

function createStudent(e) {
    e.preventDefault();

    let idInput = htmlSelector.idInput();
    let firstNameInput = htmlSelector.firstNameInput();
    let lastNameInput = htmlSelector.lastNameInput();
    let facultyNumberInput = htmlSelector.facultyNumberInput();
    let gradeInput = htmlSelector.gradeInput();

    if (idInput.value && firstNameInput.value && lastNameInput.value && facultyNumberInput.value && gradeInput.value) {
        let studentObj = {
            ID: idInput.value,
            FirstName: firstNameInput.value,
            LastName: lastNameInput.value,
            FacultyNumber: facultyNumberInput.value,
            Grade: gradeInput.value,
        }

        fetch(baseUrl, { method: 'POST', body: JSON.stringify(studentObj) })
            .then(getStudents);

        htmlSelector.error().style.display = 'none';

        idInput.value = '';
        firstNameInput.value = '';
        lastNameInput.value = '';
        facultyNumberInput.value = '';
        gradeInput.value = '';
    } else {
        htmlSelector.error().style.display = 'block';
    }
}

function displayStudents(students) {
    const studentsHtml =
        Object.values(students)
            .sort((a, b) => a.ID - b.ID)
            .map(data => studentTemplate(data))
            .join('');

    htmlSelector.studentsContainer().innerHTML = studentsHtml;

    let delButtons = document.querySelectorAll('tbody tr td button');
    let index = 0;

    Object.keys(students).forEach(key => {
        delButtons[index].setAttribute('data-key', key);
        index++;
    });
}

function deleteStudent(e) {
    if (e.target.tagName == 'BUTTON') {
        const key = e.target.getAttribute('data-key');

        fetch(`https://books-exercise-def80.firebaseio.com/students/${key}.json`, { method: 'DELETE' })
            .then(getStudents);
    }
}