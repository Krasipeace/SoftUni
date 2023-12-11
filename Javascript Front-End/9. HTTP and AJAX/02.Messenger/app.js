function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/messenger';
    const [nameInput, contentInput, sendBtn, refreshBtn] = document.getElementsByTagName('input');
    const messagesTextArea = document.getElementById('messages');

    sendBtn.addEventListener('click', async () => {
        const messageFormat = {
            author: nameInput.value,
            content: contentInput.value
        };

        await fetch(baseUrl, {
            method: 'POST',
            body: JSON.stringify(messageFormat)
        });

        nameInput.value = '';
        contentInput.value = '';
    });

    refreshBtn.addEventListener('click', async () => {
        const response = await fetch(baseUrl);
        const messages = await response.json();
        const messagesDataTextArea = [];

        for (const messageData of Object.values(messages)) {
            messagesDataTextArea.push(`${messageData.author}: ${messageData.content}`);
        }

        messagesTextArea.textContent = messagesDataTextArea.join('\n');
    });
}

attachEvents();