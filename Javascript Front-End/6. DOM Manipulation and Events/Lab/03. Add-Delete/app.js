function addItem() {
    let input = document.getElementById('newItemText');
    let newListItem = document.createElement('li');

    newListItem.textContent = input.value;
    document.getElementById('items').appendChild(newListItem);
    input.value = '';

    let deleteBtn = document.createElement('a');

    deleteBtn.textContent = '[Delete]';
    deleteBtn.href = '#';
    newListItem.appendChild(deleteBtn);
    deleteBtn.addEventListener('click', function (e) {
        e.target.parentNode.remove();
    });
}