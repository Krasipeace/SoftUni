function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   const restaurant = {
      'name': '',
      'workers': [],
      'avgSalary': 0,
      'bestSalary': 0
   };

   function onClick() {
      const input = document.querySelectorAll('#inputs textarea')[0];
      const bestRestaurant = document.querySelectorAll('#bestRestaurant p')[0];
      const bestWorker = document.querySelectorAll('#workers p')[0];
      let parsedInput = JSON.parse(input.value);

      for (let eachRestaurant of parsedInput) {
         const workersRestaurant = [];
         let averageSalary = 0;
         let bestSalary = 0;
         let [restName, workers] = eachRestaurant.split(' - ');
         workers = workers.split(', ');

         for (let worker of workers) {
            let [name, salary] = worker.split(' ');
            salary = Number(salary);

            if (salary > bestSalary) {
               bestSalary = salary;
            }

            averageSalary += salary;
            workersRestaurant.push([name, salary]);
         }

         averageSalary = Number((averageSalary / workers.length).toFixed(2));

         if (averageSalary > Number(restaurant['avgSalary']) && restName != restaurant['name']) {
            restaurant['name'] = restName;
            restaurant['workers'] = workersRestaurant;
            restaurant['avgSalary'] = averageSalary.toFixed(2);
            restaurant['bestSalary'] = bestSalary.toFixed(2);
         } else if (restName === restaurant['name']) {
            restaurant['workers'] = restaurant['workers'].concat(workersRestaurant);
         }
      }

      restaurant['workers'].sort((a, b) => b[1] - a[1]);
      let outputWorkText = '';

      for (let [name, salary] of restaurant['workers']) {
         outputWorkText += `Name: ${name} With Salary: ${salary} `;
      }

      let salaries = restaurant['workers'].map((r) => r[1]);
      restaurant['avgSalary'] = (salaries.reduce((acc, salary) => acc + salary) / salaries.length).toFixed(2);
      restaurant['bestSalary'] = (salaries.sort((a, b) => b - a)[0]).toFixed(2);

      bestRestaurant.textContent = `Name: ${restaurant['name']} Average Salary: ${restaurant['avgSalary']} Best Salary: ${restaurant['bestSalary']}`;
      bestWorker.textContent = outputWorkText.trim();
      input.value = '';
   }
}
