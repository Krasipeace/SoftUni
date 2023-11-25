function solve() {
	document.querySelector('#btnSend').addEventListener('click', onClick);

	function onClick() {
		let inputData = getInput();
		let restaurants = [];

		for (const currentRestaurant of inputData) {
			let restaurantInfo = currentRestaurant.split(' - ');
			let employeesInfo = restaurantInfo[1].split(', ');
			createRestaurant(restaurants, restaurantInfo, employeesInfo);
		}

		let bestRestaurant = getBestRestaurant(restaurants);
		getOutput(bestRestaurant);

		function getInput() {
			return JSON.parse(document.getElementById('inputs').querySelector('textArea').value);
		}

		function createRestaurant(restaurants, restaurantInfo, employeesInfo) {
			let restaurantName = restaurantInfo[0];
			let restaurant = {};

			if (!restaurants.some(r => r.name == restaurantName)) {
				restaurant.name = restaurantName;
				restaurant.employees = [];
				restaurants.push(restaurant);
			} else {
				restaurant = restaurants.find(x => x.name == restaurantName);
			}

			for (const currentEmployee of employeesInfo) {
				let employee = {};
				let employeeInfo = currentEmployee.split(' ');
				let employeeName = employeeInfo[0];
				let employeeSalary = Number(employeeInfo[1]);

				employee.name = employeeName;
				employee.salary = employeeSalary;
				restaurant.employees.push(employee);
			}

			let sumSalary = restaurant.employees.reduce((a, b) => a + b.salary, 0);
			restaurant.averageSalary = (sumSalary / restaurant.employees.length) || 0;
		}

		function getBestRestaurant(restaurants) {
			restaurants = restaurants.sort((a, b) => b.averageSalary - a.averageSalary);
			let bestRestaurant = restaurants[0];
			bestRestaurant.employees = bestRestaurant.employees.sort((a, b) => b.salary - a.salary);
			return bestRestaurant;
		}

		function getOutput(bestRestaurant) {
			let bestRestSalary = bestRestaurant.employees[0].salary;
			let strRepresentBestRest = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestSalary.toFixed(2)}`;
			let bestRestaurantWorkers = '';

			for (let worker of bestRestaurant.employees) {
				bestRestaurantWorkers += `Name: ${worker.name} With Salary: ${worker.salary} `;
			}

			document.getElementById('bestRestaurant').querySelector('p').textContent = strRepresentBestRest;
			document.getElementById('workers').querySelector('p').textContent = bestRestaurantWorkers;
		}
	}
}