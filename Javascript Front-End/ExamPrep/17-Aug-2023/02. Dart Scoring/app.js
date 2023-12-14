window.addEventListener("load", solve);

function solve() {
    const playerInput = document.getElementById("player");
    const scoreInput = document.getElementById("score");
    const rountInput = document.getElementById("round");

    const addBtn = document.getElementById("add-btn");
    const sureList = document.getElementById("sure-list");
    const clearBtn = document.querySelector(".btn.clear");
    const scoreBoardList = document.getElementById("scoreboard-list");

    addBtn.addEventListener("click", addPlayer);
    clearBtn.addEventListener("click", clearApp);

    function addPlayer(e) {
        e.preventDefault();

        const player = playerInput.value;
        const score = scoreInput.value;
        const round = rountInput.value;

        if (player === "" || score === "" || round === "") {
            return;
        }

        const liElement = document.createElement("li");
        liElement.classList.add("dart-item");

        const articleElement = document.createElement("article");
        const pPlayerNameElement = document.createElement("p");
        const pScoreElement = document.createElement("p");
        const pRoundElement = document.createElement("p");

        const editBtnElement = document.createElement("button");
        editBtnElement.classList.add("btn", "edit");
        editBtnElement.textContent = "edit";
        editBtnElement.addEventListener("click", () => {
            playerInput.value = player;
            scoreInput.value = score;
            rountInput.value = round;

            liElement.remove();

            addBtn.disabled = false;
        });

        const okBtnElement = document.createElement("button");
        okBtnElement.classList.add("btn", "ok");
        okBtnElement.textContent = "ok";
        okBtnElement.addEventListener("click", () => {
            liElement.remove();
            scoreBoardList.appendChild(liElement);
            editBtnElement.remove();
            okBtnElement.remove();

            addBtn.disabled = false;
        });

        sureList.appendChild(liElement);
        liElement.appendChild(articleElement);
        articleElement.appendChild(pPlayerNameElement);
        articleElement.appendChild(pScoreElement);
        articleElement.appendChild(pRoundElement);
        liElement.appendChild(editBtnElement);
        liElement.appendChild(okBtnElement);

        pPlayerNameElement.textContent = player;
        pScoreElement.textContent = `Score: ${score}`;
        pRoundElement.textContent = `Round: ${round}`;

        clearForm();
        addBtn.disabled = true;
    }

    function clearApp() {
        location.reload();
    }

    function clearForm() {
        playerInput.value = "";
        scoreInput.value = "";
        rountInput.value = "";
    }
}
