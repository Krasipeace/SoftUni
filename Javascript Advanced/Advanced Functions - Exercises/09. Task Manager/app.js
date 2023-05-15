function solve() {
    let obj = {
        task: document.getElementById("task"),
        description: document.getElementById("description"),
        date: document.getElementById("date")
    }

    let [_, openSection, inProgressSection, completeSection] = [...document.querySelectorAll("section")].map(d => d.children[1]);

    document.getElementById("add").addEventListener("click", event => {
        event.preventDefault();

        let article = document.createElement("article");
        article.appendChild(elements('h3', obj.task.value));

        let div = elements('div', '', 'flex');
        let startButton = elements('button', 'Start', 'green');
        let deleteButton = elements('button', 'Delete', 'red');
        let finishButton = elements('button', 'Finish', 'orange');

        article.appendChild(elements('p', `Description: ${obj.description.value}`));
        article.appendChild(elements('p', `Due Date: ${obj.date.value}`));
        div.appendChild(startButton);
        div.appendChild(deleteButton);
        article.appendChild(div);
        openSection.appendChild(article);

        for (const key in obj) {
            obj[key].value = '';
        }

        startButton.addEventListener("click", () => {
            inProgressSection.appendChild(article);
            startButton.remove();
            div.appendChild(finishButton);
        });

        deleteButton.addEventListener("click", () => {
            article.remove();
        });

        finishButton.addEventListener("click", () => {
            completeSection.appendChild(article);
            div.remove();
        });

        function elements(type, content, className) {
            let result = document.createElement(type);
            result.textContent = content;

            if (className) {
                result.className = className;
            }

            return result;
        }
    });
}