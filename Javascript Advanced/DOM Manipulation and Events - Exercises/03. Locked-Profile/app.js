function lockedProfile() {
    let buttons = document.getElementsByTagName('button');
    
    for (let i = 0; i < buttons.length; i++) {
        buttons[i].addEventListener('click', showMore);
    }

    function showMore(item) {
        let button = item.target;
        let profile = button.parentNode;
        let hiddenData = profile.getElementsByTagName('div')[0];
        let lockStatus = profile.getElementsByTagName('input')[0];
        let hiddenDataDisplay = hiddenData.style.display;

        if (lockStatus.checked === false) {
            if (hiddenDataDisplay === 'block') {
                hiddenData.style.display = 'none';
                button.textContent = 'Show more';
            } else {
                hiddenData.style.display = 'block';
                button.textContent = 'Hide it';
            }
        }
    }
}