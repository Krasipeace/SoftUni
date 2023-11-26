function deleteByEmail() {
    let emailData = document.querySelector('input[name="email"]');
    let rows = Array.from(document.querySelectorAll('tbody tr'));
    let result = document.getElementById('result');

    let email = emailData.value;
    let row = rows.find(r => r.children[1].textContent == email);

    if (row) {
        row.remove();
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }

    emailData.value = '';
}