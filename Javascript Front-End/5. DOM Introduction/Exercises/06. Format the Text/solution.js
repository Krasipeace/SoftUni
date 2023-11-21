function solve() {
	document.getElementById('formatItBtn').addEventListener('click', onClick);

	function onClick() {
		let input = document.getElementById('input').value;
		let output = document.getElementById('output');
		let sentences = input.split('.').filter(x => x);

		while (sentences.length) {
			let paragraphText = sentences.splice(0, 3).join('.') + '.';
			let paragraph = `<p>${paragraphText}</p>`;
			output.innerHTML += paragraph;
		}
	}
}