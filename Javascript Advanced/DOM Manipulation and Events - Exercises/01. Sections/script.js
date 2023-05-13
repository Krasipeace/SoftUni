function create(words) {
   let content = document.getElementById('content');

   for (let word of words) {
      let div = document.createElement('div');
      let item = document.createElement('p');
      item.textContent = word;
      item.style.display = 'none';
      div.appendChild(item);
      div.addEventListener('click', onClick);
      content.appendChild(div);
   }

   function onClick(item) {
      let section = item.target.firstChild;
      section.style.display = 'block';
   }
}