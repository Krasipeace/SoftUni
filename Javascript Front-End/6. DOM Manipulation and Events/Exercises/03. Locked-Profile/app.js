function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    for (let button of buttons) {
        button.addEventListener('click', showMore);
    }

    function showMore(e) {
        let profile = e.target.parentNode;
        let isLocked = profile.querySelector('input[type="radio"][value="lock"]').checked;

        if (!isLocked) {
            let hiddenFields = profile.querySelector('div');

            if (e.target.textContent === 'Show more') {
                hiddenFields.style.display = 'block';
                e.target.textContent = 'Hide it';
            } else {
                hiddenFields.style.display = 'none';
                e.target.textContent = 'Show more';
            }
        }
    }
}