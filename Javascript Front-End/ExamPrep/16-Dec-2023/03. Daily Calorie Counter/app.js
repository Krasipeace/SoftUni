const basedUrl = 'http://localhost:3030/jsonstore/tasks' // /:id

const foodInput = document.getElementById('food');
const timeInput = document.getElementById('time');
const caloriesInput = document.getElementById('calories');

const addMealBtn = document.getElementById('add-meal');
const editMealBtn = document.getElementById('edit-meal');
const loadMealsBtn = document.getElementById('load-meals');

const listMeals = document.getElementById('list');

const mealId = '';
const formElement = document.querySelector('#form form');

loadMealsBtn.addEventListener('click', loadMeals);

// Add Meal request
addMealBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const newMealRecord = {
        food: foodInput.value,
        time: timeInput.value,
        calories: caloriesInput.value,
    }

    fetch(basedUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newMealRecord)
    })
        .then(loadMeals);
    clearFormInputs();
});

// Edit Meal request
editMealBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const editedMealRecord = {
        food: foodInput.value,
        time: timeInput.value,
        calories: caloriesInput.value,
    }

    fetch(`${basedUrl}/${mealId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(editedMealRecord)
    })
        .then(loadMeals);
    clearFormInputs();

    addMealBtn.disabled = false;
    editMealBtn.disabled = true;
});


async function loadMeals() {
    return fetch(basedUrl)
        .then(response => response.json())
        .then(data => {
            createMealsRecords(Object.values(data));
        });
}

function createMealsRecords(records) {
    listMeals.innerHTML = '';
    records.map(createMealRecord).forEach(mealRecord =>
        listMeals.appendChild(mealRecord)
    );
}

function createMealRecord(mealRecord) {
    // Render Meal data container
    const divContainer = document.createElement('div');
    divContainer.className = 'meal';

    const h2FoodElement = document.createElement('h2');
    h2FoodElement.textContent = mealRecord.food;

    const h3TimeElement = document.createElement('h3');
    h3TimeElement.textContent = mealRecord.time;

    const h3CaloriesElement = document.createElement('h3');
    h3CaloriesElement.textContent = mealRecord.calories;

    const divMealButtons = document.createElement('div');
    divMealButtons.id = 'meal-buttons';

    const buttonChangeMeal = document.createElement('button');
    buttonChangeMeal.className = 'change-meal';
    buttonChangeMeal.textContent = 'Change';
    buttonChangeMeal.addEventListener('click', () => {
        foodInput.value = mealRecord.food;
        timeInput.value = mealRecord.time;
        caloriesInput.value = mealRecord.calories;

        addMealBtn.disabled = true;
        editMealBtn.disabled = false;

        formElement.dataset.mealRecord = mealRecord._id;

        divContainer.remove();
    });

    const buttonDeleteMeal = document.createElement('button');
    buttonDeleteMeal.className = 'delete-meal';
    buttonDeleteMeal.textContent = 'Delete';
    buttonDeleteMeal.addEventListener('click', () => {
        fetch(`${basedUrl}/${mealRecord._id}`, {
            method: 'DELETE'
        })
            .then(loadMeals);
    });

    // tree structure
    listMeals.appendChild(divContainer);
    divContainer.appendChild(h2FoodElement);
    divContainer.appendChild(h3TimeElement);
    divContainer.appendChild(h3CaloriesElement);
    divContainer.appendChild(divMealButtons);
    divMealButtons.appendChild(buttonChangeMeal);
    divMealButtons.appendChild(buttonDeleteMeal);

    return divContainer;
}

function clearFormInputs() {
    foodInput.value = '';
    timeInput.value = '';
    caloriesInput.value = '';
}