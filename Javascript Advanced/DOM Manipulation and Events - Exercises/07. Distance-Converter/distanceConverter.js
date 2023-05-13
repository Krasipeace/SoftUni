function attachEventsListeners() {
    let inputDistance = document.getElementById('inputDistance');
    let outputDistance = document.getElementById('outputDistance');

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');

    let convertButton = document.getElementById('convert');

    convertButton.addEventListener('click', convert);

    function convert() {
        let inputDistanceValue = inputDistance.value;
        let inputUnitsValue = inputUnits.value;
        let outputUnitsValue = outputUnits.value;
        let result = 0;

        switch (inputUnitsValue) {
            case 'km':
                result = inputDistanceValue * 1000;
                break;
            case 'm':
                result = inputDistanceValue;
                break;
            case 'cm':
                result = inputDistanceValue * 0.01;
                break;
            case 'mm':
                result = inputDistanceValue * 0.001;
                break;
            case 'mi':
                result = inputDistanceValue * 1609.34;
                break;
            case 'yrd':
                result = inputDistanceValue * 0.9144;
                break;
            case 'ft':
                result = inputDistanceValue * 0.3048;
                break;
            case 'in':
                result = inputDistanceValue * 0.0254;
                break;
        }

        switch (outputUnitsValue) {
            case 'km':
                result = result / 1000;
                break;
            case 'm':
                result = result;
                break;
            case 'cm':
                result = result / 0.01;
                break;
            case 'mm':
                result = result / 0.001;
                break;
            case 'mi':
                result = result / 1609.34;
                break;
            case 'yrd':
                result = result / 0.9144;
                break;
            case 'ft':
                result = result / 0.3048;
                break;
            case 'in':
                result = result / 0.0254;
                break;
        }

        outputDistance.value = result;
    }
}