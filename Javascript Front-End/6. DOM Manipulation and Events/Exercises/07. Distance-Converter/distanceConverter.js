function attachEventsListeners() {
    const units = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };

    let inputDistance = document.getElementById('inputDistance');
    let outputDistance = document.getElementById('outputDistance');
    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');
    let convertBtn = document.getElementById('convert');

    convertBtn.addEventListener('click', () => {
        let inputUnit = inputUnits.value;
        let outputUnit = outputUnits.value;
        let inputDistanceValue = Number(inputDistance.value);
        let outputDistanceValue = inputDistanceValue * units[inputUnit] / units[outputUnit];
        outputDistance.value = outputDistanceValue;
    });
}