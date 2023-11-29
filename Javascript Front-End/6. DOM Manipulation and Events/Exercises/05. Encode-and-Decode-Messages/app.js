function encodeAndDecodeMessages() {
    const encodeBtn = document.getElementsByTagName('button')[0];
    const decodeBtn = document.getElementsByTagName('button')[1];
    let encodeTextArea = document.getElementsByTagName('textarea')[0];
    let decodeTextArea = document.getElementsByTagName('textarea')[1];

    encodeBtn.addEventListener('click', encode);
    decodeBtn.addEventListener('click', decode);

    function encode() {
        let message = encodeTextArea.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            encodedMessage += String.fromCharCode(message.charCodeAt(i) + 1);
        }

        encodeTextArea.value = '';
        decodeTextArea.value = encodedMessage;
    }

    function decode() {
        let message = decodeTextArea.value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            decodedMessage += String.fromCharCode(message.charCodeAt(i) - 1);
        }

        decodeTextArea.value = decodedMessage;
    }
}