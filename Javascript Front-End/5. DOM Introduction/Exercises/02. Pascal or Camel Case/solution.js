function solve() {
	let input = document.getElementById("text").value;
	let convention = document.getElementById("naming-convention").value;
	let result = document.getElementById("result");
	let words = input.split(" ").filter(x => x !== "");
	let output = "";

	if (convention === "Camel Case") {
		output += words[0].toLowerCase();
		for (let i = 1; i < words.length; i++) {
			output += words[i][0].toUpperCase() + words[i].slice(1).toLowerCase();
		}
	} else if (convention === "Pascal Case") {
		for (let i = 0; i < words.length; i++) {
			output += words[i][0].toUpperCase() + words[i].slice(1).toLowerCase();
		}
	} else {
		output = "Error!";
	}

	result.textContent = output;
}