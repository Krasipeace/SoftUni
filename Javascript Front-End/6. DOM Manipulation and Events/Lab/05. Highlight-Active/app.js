function focused() {
    let boxes = document.querySelectorAll('input[type="text"]');

    Array.from(boxes).forEach(box => {
        box.addEventListener('focus', onFocus);
        box.addEventListener('blur', onBlur);
    });

    function onFocus(event) {
        event.target.parentNode.className = 'focused';
    }

    function onBlur(event) {
        event.target.parentNode.className = '';
    }
}