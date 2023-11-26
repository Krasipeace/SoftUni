function validate() {
    let email = document.getElementById('email');
    let regex = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;

    email.addEventListener('change', () => {
        if (!regex.test(email.value)) {
            email.classList.add('error');
        } else {
            email.classList.remove('error');
        }
    });
}