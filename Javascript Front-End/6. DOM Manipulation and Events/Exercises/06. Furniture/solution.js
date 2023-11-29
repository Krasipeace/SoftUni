function solve() {
	const [generateBtn, buyBtn] = document.getElementsByTagName('button');
	let [input, output] = document.getElementsByTagName('textarea');
	let table = document.querySelector('tbody');

	generateBtn.addEventListener('click', generate);
	buyBtn.addEventListener('click', buy);

	function generate() {
		let furniture = JSON.parse(input.value);

		for (let item of furniture) {
			let row = document.createElement('tr');

			let htmlContent = `
                <td><img src="${item.img}"></td>
                <td><p>${item.name}</p></td>
                <td><p>${item.price}</p></td>
                <td><p>${item.decFactor}</p></td>
                <td><input type="checkbox"/></td>
            `;

			row.innerHTML = htmlContent;
			table.appendChild(row);
		}
	}

	function buy() {
		let bought = [];
		let totalPrice = 0;
		let totalDecFactor = 0;

		Array.from(document.querySelectorAll('tbody tr')).forEach(row => {
			let checkbox = row.querySelector('input[type="checkbox"]');

			if (checkbox.checked) {
				let [name, price, decFactor] = Array.from(row.querySelectorAll('p')).map(el => el.textContent);
				bought.push(name);
				totalPrice += Number(price);
				totalDecFactor += Number(decFactor);
			}
		});

		let avgDecFactor = totalDecFactor / bought.length;
		output.value = `Bought furniture: ${bought.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${avgDecFactor}`;
	}
}