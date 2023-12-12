window.addEventListener("load", solve);

function solve() {
    const student = document.getElementById("student");
    const university = document.getElementById("university");
    const score = document.getElementById("score");
    const nextBtn = document.getElementById("next-btn");
    const form = document.querySelector("form");

    nextBtn.addEventListener("click", onClickNextBtn);

    function onClickNextBtn() {
        if (student.value === "" || university.value === "" || score.value === "") {
            return;
        }

        const previewList = document.getElementById("preview-list");
        const candidatesList = document.getElementById("candidates-list");

        const newLi = createListItem(student.value, university.value, score.value);

        const editBtn = createButton("edit", "edit", () => {
            student.value = newLi.querySelector("h4").textContent;
            university.value = newLi.querySelector("p").textContent.split(": ")[1];
            score.value = newLi.querySelectorAll("p")[1].textContent.split(": ")[1];

            previewList.removeChild(newLi);

            nextBtn.disabled = false;
        });

        const applyBtn = createButton("apply", "apply", () => {
            previewList.removeChild(newLi);
            newLi.removeChild(applyBtn);
            newLi.removeChild(editBtn);
            candidatesList.appendChild(newLi);

            nextBtn.disabled = false;
        });

        newLi.appendChild(editBtn);
        newLi.appendChild(applyBtn);
        previewList.appendChild(newLi);

        form.reset();

        nextBtn.disabled = true;
    }

    function createListItem(studentInfo, universityInfo, scoreInfo) {
        const newLi = document.createElement("li");
        newLi.classList.add("application");

        const article = document.createElement("article");

        const studentLine = document.createElement("h4");
        studentLine.textContent = studentInfo;

        const universityLine = document.createElement("p");
        universityLine.textContent = `University: ${universityInfo}`;

        const scoreLine = document.createElement("p");
        scoreLine.textContent = `Score: ${scoreInfo}`;

        article.appendChild(studentLine);
        article.appendChild(universityLine);
        article.appendChild(scoreLine);

        newLi.appendChild(article);

        return newLi;
    }

    function createButton(className, textContent, clickHandler) {
        const btn = document.createElement("button");
        btn.classList.add("action-btn", className);
        btn.textContent = textContent;
        btn.addEventListener("click", clickHandler);

        return btn;
    }
}
