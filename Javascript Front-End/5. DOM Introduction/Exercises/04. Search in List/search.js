function search() {
	let searchText = document.getElementById('searchText').value;
	let towns = document.getElementById('towns').children;
	let result = document.getElementById('result');
	let count = 0;

	for (let i = 0; i < towns.length; i++) {
		if (towns[i].textContent.includes(searchText)) {
			towns[i].style.fontWeight = 'bold';
			towns[i].style.textDecoration = 'underline';
			count++;
		} else {
			towns[i].style.fontWeight = '';
			towns[i].style.textDecoration = '';
		}
	}

	result.textContent = `${count} matches found`;
}