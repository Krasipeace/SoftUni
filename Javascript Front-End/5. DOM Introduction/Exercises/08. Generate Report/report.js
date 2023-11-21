function generateReport() {
	let result = [];
	let table = document.getElementsByTagName('table')[0];
	let rows = table.rows;
	let checked = Array.from(document.querySelectorAll('input[type=checkbox]')).filter(c => c.checked).map(c => c.name);

	for (let i = 1; i < rows.length; i++) {
		let obj = {};
		let row = rows[i];

		for (let j = 0; j < row.cells.length; j++) {
			let cell = row.cells[j];
			let header = table.rows[0].cells[j].textContent.toLowerCase().trim();

			if (checked.includes(header)) {
				obj[header] = cell.textContent;
			}
		}

		result.push(obj);
	}

	document.getElementById('output').value = JSON.stringify(result, null, 2);
}