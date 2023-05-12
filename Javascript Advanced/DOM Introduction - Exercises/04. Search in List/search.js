function search() {
   let towns = document.querySelectorAll('#towns li');
   let searchField = document.querySelector('#searchText').value;
   let result = document.querySelector('#result');
   let counter = 0;

   for (let town of towns) {
      if (town.textContent.includes(searchField)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         counter++;
      } else {
         town.style.fontWeight = '';
         town.style.textDecoration = '';
      }
   }

   result.textContent = `${counter} matches found`;
}