window.addEventListener("load", solve);

function solve() {
    const expenseInput = document.getElementById("expense");
    const amountInput = document.getElementById("amount");
    const dateInput = document.getElementById("date");

    const addBtn = document.getElementById("add-btn");

    const previewList = document.getElementById("preview-list");
    const expensesList = document.getElementById("expenses-list");

    const deleteBtn = document.querySelector(".delete.btn");
    deleteBtn.addEventListener("click", deleteButtonOnClick);

    addBtn.addEventListener("click", addExpense);

    function addExpense(e) {
        e.preventDefault();

        const expense = expenseInput.value;
        const amount = amountInput.value;
        const date = dateInput.value;

        if (expense === "" || amount === "" || date === "") {
            return;
        }

        const liElement = document.createElement("li");
        liElement.className = "expense-item";

        const articleElement = document.createElement("article");
        const pExpenseElement = document.createElement("p");
        const pAmountElement = document.createElement("p");
        const pDateElement = document.createElement("p");

        const divButtonsElement = document.createElement("div");
        divButtonsElement.className = "buttons";

        // EDIT BUTTON
        const editBtnElement = document.createElement("button");
        editBtnElement.className = "btn edit";
        editBtnElement.textContent = "edit";
        editBtnElement.addEventListener("click", () => {
            expenseInput.value = expense;
            amountInput.value = amount;
            dateInput.value = date;

            liElement.remove();
            addBtn.disabled = false;
        });

        // OK BUTTON
        const okBtnElement = document.createElement("button");
        okBtnElement.className = "btn ok";
        okBtnElement.textContent = "ok";
        okBtnElement.addEventListener("click", () => {
            liElement.remove();
            expensesList.appendChild(liElement);
            editBtnElement.remove();
            okBtnElement.remove();

            addBtn.disabled = false;
        });

        // tree structure preview-list
        previewList.appendChild(liElement);
        liElement.appendChild(articleElement);
        articleElement.appendChild(pExpenseElement);
        articleElement.appendChild(pAmountElement);
        articleElement.appendChild(pDateElement);
        liElement.appendChild(divButtonsElement);
        divButtonsElement.appendChild(editBtnElement);
        divButtonsElement.appendChild(okBtnElement);

        pExpenseElement.textContent = `Type: ${expense}`;
        pAmountElement.textContent = `Amount: ${amount}$`;

        const formattedDate = date.split(".").reverse().join("-");
        pDateElement.textContent = `Date: ${formattedDate}`;

        clearInputs();
        addBtn.disabled = true;
    }

    function deleteButtonOnClick() {
        location.reload();
    }

    function clearInputs() {
        expenseInput.value = "";
        amountInput.value = "";
        dateInput.value = "";
    }
}
