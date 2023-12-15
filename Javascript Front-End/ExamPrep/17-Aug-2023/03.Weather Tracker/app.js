const basedUrl = 'http://localhost:3030/jsonstore/tasks'; // /:id

const locationInput = document.getElementById('location');
const temperatureInput = document.getElementById('temperature');
const dateInput = document.getElementById('date');

const addWeatherBtn = document.getElementById('add-weather');
const editWeatherBtn = document.getElementById('edit-weather');
const loadHistoryBtn = document.getElementById('load-history');

const listRecords = document.getElementById('list');

const taskId = '';
const formElement = document.querySelector('#form form');

// Load history request/response
loadHistoryBtn.addEventListener('click', loadHistory);

// Add weather request/response
addWeatherBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const newWeatherData = {
        location: locationInput.value,
        temperature: temperatureInput.value,
        date: dateInput.value,
    }

    fetch(basedUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newWeatherData)
    })
        .then(loadHistory);
    clearFormFields();
});

// Edit weather request/response
editWeatherBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const editedWeatherData = {
        location: locationInput.value,
        temperature: temperatureInput.value,
        date: dateInput.value,
    }

    fetch(`${basedUrl}/${formElement.dataset.record}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(editedWeatherData)
    })
        .then(loadHistory);
    clearFormFields();

    addWeatherBtn.disabled = false;
    editWeatherBtn.disabled = true;
});

async function loadHistory() {
    return fetch(basedUrl)
        .then(response => response.json())
        .then(data => {
            createListRecords(Object.values(data));
        });
}

function createListRecords(records) {
    listRecords.innerHTML = '';
    records.map(createWeatherData).forEach(record =>
        listRecords.appendChild(record)
    );
}

function createWeatherData(record) {
    // Render Weather data container
    const divContainer = document.createElement('div');
    divContainer.className = 'container';

    const h2LocationElement = document.createElement('h2');
    h2LocationElement.textContent = record.location;

    const h3TemperatureElement = document.createElement('h3');
    h3TemperatureElement.className = 'celsius';
    h3TemperatureElement.textContent = record.temperature;

    const h3DateElement = document.createElement('h3');
    h3DateElement.textContent = record.date;

    const divButtonsContainer = document.createElement('div');
    divButtonsContainer.className = 'buttons-container';

    // Change Button
    const changeButtonElement = document.createElement('button');
    changeButtonElement.className = 'change-btn';
    changeButtonElement.textContent = 'Change';
    changeButtonElement.addEventListener('click', () => {
        locationInput.value = record.location;
        temperatureInput.value = record.temperature;
        dateInput.value = record.date;

        addWeatherBtn.disabled = true;
        editWeatherBtn.disabled = false;

        formElement.dataset.record = record._id;

        divContainer.remove();
    });

    // Delete Button
    const deleteButtonElement = document.createElement('button');
    deleteButtonElement.className = 'delete-btn';
    deleteButtonElement.textContent = 'Delete';
    deleteButtonElement.addEventListener('click', () => {
        fetch(`${basedUrl}/${record._id}`, {
            method: 'DELETE'
        })
            .then(loadHistory);
    });

    // divContainer Tree structure
    listRecords.appendChild(divContainer);
    divContainer.appendChild(h2LocationElement);
    divContainer.appendChild(h3TemperatureElement);
    divContainer.appendChild(h3DateElement);
    divContainer.appendChild(divButtonsContainer);
    divButtonsContainer.appendChild(changeButtonElement);
    divButtonsContainer.appendChild(deleteButtonElement);

    return divContainer;
}

function clearFormFields() {
    locationInput.value = '';
    temperatureInput.value = '';
    dateInput.value = '';
}
