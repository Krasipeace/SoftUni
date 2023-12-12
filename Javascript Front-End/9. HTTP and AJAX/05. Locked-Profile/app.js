async function lockedProfile() {
    const basedUrl = 'http://localhost:3030/jsonstore/advanced/profiles';
    const main = document.getElementById('main');
    main.innerHTML = '';

    await fetch(basedUrl)
        .then(res => res.json())
        .then(data => {
            Object.values(data).forEach(profile => {
                main.appendChild(createProfile(profile));
            });
        });

    function createProfile(profile) {
        const profileDiv = document.createElement('div');
        profileDiv.classList.add('profile');

        profileDiv.innerHTML = `
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user1Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user1Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user1Username" value="${profile.username}" disabled readonly />
            <div id="user1HiddenFields">
                <hr>
                <label>Email:</label>
                <input type="email" name="user1Email" value="${profile.email}" disabled readonly />
                <label>Age:</label>
                <input type="email" name="user1Age" value="${profile.age}" disabled readonly />
            </div>
            <button>Show more</button>
        `;
        profileDiv.querySelector('button').addEventListener('click', showMore);

        return profileDiv;
    }

    async function showMore(p) {
        const profile = p.target.parentNode;
        const locked = profile.querySelector('input[value="lock"]');
        const hiddenFields = profile.querySelector('#user1HiddenFields');

        if (locked.checked) {
            return;
        }

        if (hiddenFields.style.display === 'block') {
            hiddenFields.style.display = 'none';
            p.target.textContent = 'Show more';
        } else {
            hiddenFields.style.display = 'block';
            p.target.textContent = 'Hide it';
        }
    }
}