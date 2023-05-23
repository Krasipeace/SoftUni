class Contact {
    #online;
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.#online = false;
    }

    get online() {
        return this.#online;
    }
    set online(value) {
        this.#online = value;

        let div = Array
            .from(document.getElementsByClassName('title'))
            .find(x => x.textContent === `${this.firstName} ${this.lastName}`);

        if (!div) {
            return;
        }

        if (value === true) {
            div.classList.add('online');
        } else {
            div.classList.remove('online');
        }
    }

    render(id) {
        let article = document.createElement('article');
        let divTitle = document.createElement('div');
        divTitle.classList.add('title');

        if (this.#online) {
            divTitle.classList.add('online');
        }

        divTitle.textContent = `${this.firstName} ${this.lastName}`;
        let button = document.createElement('button');
        button.innerHTML = '&#8505;';
        button.addEventListener('click', () => {
            divInfo = article.getElementsByTagName('div')[0];
            if (divInfo.style.display === 'none') {
                divInfo.style.display = 'block';
            } else {
                divInfo.style.display = 'none';
            }
        });

        let divInfo = document.createElement('div');
        divInfo.classList.add('info');
        divInfo.style.display = 'none';
        let phoneSpan = document.createElement('span');
        phoneSpan.innerHTML = `&phone; ${this.phone}`;
        let emailSpan = document.createElement('span');
        emailSpan.innerHTML = `&#9993; ${this.email}`;

        divInfo.appendChild(phoneSpan);
        divInfo.appendChild(emailSpan);
        divTitle.appendChild(button);
        article.appendChild(divTitle);
        article.appendChild(divInfo);
        document.getElementById(id).appendChild(article);
    }
}
