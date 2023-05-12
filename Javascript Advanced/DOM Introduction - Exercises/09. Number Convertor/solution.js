function solve() {
    let input = document.querySelector('#input');
    let selectedConversion = document.querySelector('#selectMenuTo');
    let button = document.querySelector('button');
    let output = document.querySelector('#result');
    
    // drop-down menu 'To'
    let binary = document.createElement('option')
    binary.value = 'binary';
    binary.innerText = 'Binary';

    let hexadecimal = document.createElement('option')
    hexadecimal.value = 'hexadecimal';
    hexadecimal.innerText = 'Hexadecimal';

    selectedConversion.appendChild(binary);
    selectedConversion.appendChild(hexadecimal);

    button.addEventListener('click', function () {
        let number = Number(input.value);
        let chosenConversion = selectedConversion.options[selectedConversion.selectedIndex].text;

        if (number && chosenConversion) {
            let result = ''

            switch (chosenConversion) {
                case 'Binary':
                    result = (number >>> 0).toString(2);
                    break;

                case 'Hexadecimal':
                    console.log('hex')
                    result = number.toString(16).toUpperCase();
                    break;
            }

            output.value = result;
        }
    });
}
