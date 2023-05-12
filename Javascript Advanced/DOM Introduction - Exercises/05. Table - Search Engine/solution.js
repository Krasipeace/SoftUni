function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let students = document.querySelectorAll("tbody tr");
      let pattern = document.getElementById("searchField").value;

      for (let student of students) {
         if (student.textContent.includes(pattern)) {
            student.classList.add("select");
         } else {
            student.classList.remove("select");
         }
      }
   }
}