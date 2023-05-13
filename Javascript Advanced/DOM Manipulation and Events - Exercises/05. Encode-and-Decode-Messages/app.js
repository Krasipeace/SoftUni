function encodeAndDecodeMessages() {
    let encodeButton = document.querySelectorAll('button')[0];
    let decodeButton = document.querySelectorAll('button')[1];

    encodeButton.addEventListener('click', encode);
    decodeButton.addEventListener('click', decode);

    function encode() {
        let message = document.querySelectorAll('textarea')[0].value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            encodedMessage += String.fromCharCode(message[i].charCodeAt(0) + 1);
        }

        document.querySelectorAll('textarea')[0].value = '';
        document.querySelectorAll('textarea')[1].value = encodedMessage;
    }

    function decode() {
        let message = document.querySelectorAll('textarea')[1].value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            decodedMessage += String.fromCharCode(message[i].charCodeAt(0) - 1);
        }

        document.querySelectorAll('textarea')[1].value = decodedMessage;
    }
}