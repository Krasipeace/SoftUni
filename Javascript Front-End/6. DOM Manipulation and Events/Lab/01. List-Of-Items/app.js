function addItem() {
    let input = document.getElementById('newItemText');
    let newListItem = document.createElement('li');
    
    newListItem.textContent = input.value;
    document.getElementById('items').appendChild(newListItem);
    input.value = '';
}