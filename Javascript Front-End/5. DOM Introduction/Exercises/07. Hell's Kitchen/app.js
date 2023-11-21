function solve() {
	document.querySelector('#btnSend').addEventListener('click', onClick);

	function onClick() {
		let input = JSON.parse(document.querySelector('#inputs textarea').value);
		let bestRestaurant = getBestRestaurant(input);
		let workers = getWorkers(input, bestRestaurant);
		let bestRestaurantOutput = PrintBestRestaurant(bestRestaurant, workers);

		document.querySelector('#bestRestaurant p').textContent = bestRestaurantOutput;
		document.querySelector('#workers p').textContent = PrintWorkers(workers);
		document.querySelector('#inputs textarea').value = '';

		function getBestRestaurant(input) {
			let restaurants = {};

			for (let line of input) {
				let [restaurant, workersString] = line.split(' - ');
				let workers = workersString.split(', ');
				let averageSalary = 0;

				for (let worker of workers) {
					let [name, salary] = worker.split(' ');
					averageSalary += Number(salary);
				}

				averageSalary /= workers.length;
				restaurants[restaurant] = { workers, averageSalary };
			}

			let bestRestaurant;
			let bestAverageSalary = 0;

			for (const restaurant in restaurants) {
				if (restaurants[restaurant].averageSalary > bestAverageSalary) {
					bestAverageSalary = restaurants[restaurant].averageSalary;
					bestRestaurant = restaurant;
				}
			}

			return { name: bestRestaurant, ...restaurants[bestRestaurant] };
		}

		function getWorkers(input, bestRestaurant) {
			let workers = {};

			for (let line of input) {
				let [restaurant, workersString] = line.split(' - ');
				let workersArr = workersString.split(', ');

				if (restaurant === bestRestaurant.name) {
					for (let worker of workersArr) {
						let [name, salary] = worker.split(' ');
						workers[name] = Number(salary);
					}
				}
			}

			return workers;
		}

		function PrintBestRestaurant(bestRestaurant, workers) {
			return `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${workers[Object.keys(workers).sort((a, b) => workers[b] - workers[a])[0]].toFixed(2)}`;
		}

		function PrintWorkers(workers) {
			return Object.entries(workers).sort((a, b) => b[1] - a[1]).map(worker => `Name: ${worker[0]} With Salary: ${worker[1]}`).join(' ');
		}
	}
}