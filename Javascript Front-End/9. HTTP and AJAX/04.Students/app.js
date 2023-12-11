async function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/collections/students';
    const tableBody = document.querySelector('tbody');
    const submitBtn = document.getElementById('submit');

    submitBtn.addEventListener('click', onSubmit);

    const getResponse = await fetch(baseUrl);
    const students = await getResponse.json();

    Object.values(students).forEach(student => {
        createStudentRow(student, tableBody);
    });

    async function onSubmit() {
        const [firstName, lastName, facultyNumber, grade] = document.querySelectorAll('#form input');

        const newStudentInfo = {
            firstName: firstName.value,
            lastName: lastName.value,
            facultyNumber: facultyNumber.value,
            grade: grade.value,
        }

        await fetch(baseUrl, {
            method: 'POST',
            body: JSON.stringify(newStudentInfo)
        });

        createStudentRow(newStudentInfo, tableBody);
    }

    function createStudentRow(student, tableBody) {
        const row = document.createElement('tr');
        row.innerHTML = `
        <tr>
            <td>${student.firstName}</td>
            <td>${student.lastName}</td>
            <td>${student.facultyNumber}</td>
            <td>${student.grade.toFixed(2)}</td>
        </tr>
    `;
        tableBody.appendChild(row);
    }
}

attachEvents();