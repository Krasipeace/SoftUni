function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';
    document.getElementById('btnLoad').addEventListener('click', loadContacts);
    document.getElementById('btnCreate').addEventListener('click', createContact);

    async function loadContacts() {
        const contactsInfo = await (await fetch(baseUrl)).json();
        const phonebook = document.getElementById('phonebook');

        Object.values(contactsInfo).forEach(c => {
            const li = document.createElement('li');
            const deleteBtn = document.createElement('button');

            li.textContent = `${c.person}: ${c.phone}`;
            deleteBtn.textContent = 'Delete';

            deleteBtn.addEventListener('click', deleteContact);
            li.appendChild(deleteBtn);
            phonebook.appendChild(li);

            function deleteContact() {
                fetch(`http://localhost:3030/jsonstore/phonebook/${c._id}`, {
                    method: 'DELETE'
                });

                li.remove();
            }
        });
    }

    function createContact() {
        const person = document.getElementById('person').value;
        const phone = document.getElementById('phone').value;

        fetch(baseUrl, {
            method: 'POST',
            body: JSON.stringify({ person, phone })
        })
            .then(res => res.json())
            .then(() => {
                loadContacts();
                person.value = '';
                phone.value = '';
            });
    }
}

attachEvents();