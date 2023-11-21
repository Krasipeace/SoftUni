function solve() {
	document.getElementById('searchBtn').addEventListener('click', onClick);

	function onClick() {
		let searchText = document.getElementById('searchField').value;
		let tableRows = Array.from(document.querySelectorAll('tbody tr'));

		tableRows.forEach(row => {
			if (row.textContent.includes(searchText)) {
				row.classList.add('select');
			} else {
				row.classList.remove('select');
			}
		});
	}
}