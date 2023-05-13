function solve() {
    let [generateButton, buyButton] = document.querySelectorAll('button');
    let [input, output] = document.querySelectorAll('textarea');
    let tbody = document.querySelector('tbody');

    generateButton.addEventListener('click', generate);
    buyButton.addEventListener('click', buy);

    function generate() {
        let data = JSON.parse(input.value);

        for (let item of data) {
            let row = document.createElement('tr');
            
            let img = document.createElement('img');
            img.src = item.img;
            row.appendChild(createCell(img));

            let name = document.createElement('p');
            name.textContent = item.name;
            row.appendChild(createCell(name));

            let price = document.createElement('p');
            price.textContent = item.price;
            row.appendChild(createCell(price));

            let decFactor = document.createElement('p');
            decFactor.textContent = item.decFactor;
            row.appendChild(createCell(decFactor));

            let check = document.createElement('input');
            check.type = 'checkbox';
            row.appendChild(createCell(check));

            tbody.appendChild(row);
        }
    }

    function buy() {
        let names = [];
        let totalPrice = 0;
        let factors = [];
        let furniture = Array
            .from(document.querySelectorAll('input[type="checkbox"]:checked'))
            .map(x => x.parentNode.parentNode);

        for (let item of furniture) {
            let [name, price, factor] = Array.from(item.querySelectorAll('p'));
            names.push(name.textContent);
            totalPrice += Number(price.textContent);
            factors.push(Number(factor.textContent));
        }

        let result = `Bought furniture: ${names.join(', ')}\n`;
        result += `Total price: ${totalPrice.toFixed(2)}\n`;
        result += `Average decoration factor: ${factors.reduce((a, b) => a + b) / factors.length}`;
        output.value = result;
    }

    function createCell(element) {
        let cell = document.createElement('td');
        cell.appendChild(element);
        return cell;
    }
}