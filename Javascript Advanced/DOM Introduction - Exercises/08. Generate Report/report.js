function generateReport() {
    let checkbox = document.querySelectorAll('tr th input');
    let selectedCol = [];
    let output = [];

    for (let i = 0; i < checkbox.length; i++) {
        let current = checkbox[i];

        if (current.checked === true) {
            selectedCol.push(i);
        }
    }

    let tbodyRows = document.querySelectorAll('tbody tr');

    for (let i = 0; i < tbodyRows.length; i++) {
        let currentRowInfo = {};

        for (let j = 0; j < selectedCol.length; j++) {
            let index = selectedCol[j];
            let name = checkbox[index].getAttribute('name');
            let info = tbodyRows[i].getElementsByTagName('td')[index].textContent;
            currentRowInfo[name] = info;
        }

        output.push(currentRowInfo);
    }

    output = JSON.stringify(output);
    document.getElementById('output').textContent = output;
}