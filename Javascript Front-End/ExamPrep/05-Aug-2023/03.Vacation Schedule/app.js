const basedUrl = 'http://localhost:3030/jsonstore/tasks';

const nameVacation = document.getElementById('name');
const startDateVacation = document.getElementById('from-date');
const daysLengthVacation = document.getElementById('num-days');

const loadVacationsBtn = document.getElementById('load-vacations');
const addVacationBtn = document.getElementById('add-vacation');
const editVacationBtn = document.getElementById('edit-vacation');

const listVacations = document.getElementById('list');
const formElement = document.querySelector('#form form');

loadVacationsBtn.addEventListener('click', loadVacations);

addVacationBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const newVacation = {
        name: nameVacation.value,
        days: daysLengthVacation.value,
        date: startDateVacation.value,
    }

    fetch(basedUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newVacation)
    })
        .then(loadVacations);

    clearFormFields();
});

editVacationBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const vacationId = formElement.dataset.vacation;

    const editedVacation = {
        name: nameVacation.value,
        days: daysLengthVacation.value,
        date: startDateVacation.value,
        _id: vacationId,
    };

    fetch(`${basedUrl}/${vacationId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(editedVacation)
    })
        .then(loadVacations)
        .then(() => {
            addVacationBtn.removeAttribute('disabled');
            editVacationBtn.setAttribute('disabled', 'disabled');

            delete formElement.dataset.vacation;
            clearFormFields();
        });
});

function loadVacations() {
    return fetch(basedUrl)
        .then(res => res.json())
        .then(data => {
            createListVacations(Object.values(data));
        });
}

function createListVacations(vacations) {
    listVacations.innerHTML = '';
    vacations.map(createVacationArea).forEach(v => listVacations.appendChild(v));
};

function createVacationArea(vacation) {
    const container = document.createElement('div');
    container.className = 'container';

    const h2Element = document.createElement('h2');
    h2Element.textContent = vacation.name;

    const h3DateElement = document.createElement('h3');
    h3DateElement.textContent = vacation.date;

    const h3CountDaysElement = document.createElement('h3');
    h3CountDaysElement.textContent = vacation.days;

    const changeBtn = document.createElement('button');
    changeBtn.className = 'change-btn';
    changeBtn.textContent = 'Change';

    changeBtn.addEventListener('click', () => {
        nameVacation.value = vacation.name;
        startDateVacation.value = vacation.date;
        daysLengthVacation.value = vacation.days;

        container.remove();

        editVacationBtn.removeAttribute('disabled');
        addVacationBtn.setAttribute('disabled', 'disabled');

        formElement.dataset.vacation = vacation._id;
    });

    const doneBtn = document.createElement('button');
    doneBtn.className = 'done-btn';
    doneBtn.textContent = 'Done';
    doneBtn.addEventListener('click', () => {
        fetch(`${basedUrl}/${vacation._id}`, {
            method: 'DELETE',
        })
            .then(loadVacations);
    });

    container.appendChild(h2Element);
    container.appendChild(h3DateElement);
    container.appendChild(h3CountDaysElement);
    container.appendChild(changeBtn);
    container.appendChild(doneBtn);

    return container;
}

function clearFormFields() {
    nameVacation.value = '';
    startDateVacation.value = '';
    daysLengthVacation.value = '';
}
