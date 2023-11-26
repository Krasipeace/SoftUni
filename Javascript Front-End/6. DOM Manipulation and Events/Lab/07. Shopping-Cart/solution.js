function solve() {
    let buttons = Array.from(document.getElementsByTagName('button'));
    let textArea = document.getElementsByTagName('textarea')[0];
    let cart = {};

    buttons.slice(0, -1).forEach((btn) => {
        btn.addEventListener('click', (p) => {
            let product = p.target.parentNode.parentNode;
            let { productName, productPrice } = getProductDetails(product);

            addToCart(cart, productName, productPrice);
            displayAddedToCart(textArea, productName, productPrice);
        });
    });

    let checkoutBtn = buttons[buttons.length - 1];
    checkoutBtn.addEventListener('click', () => checkout(cart, textArea, buttons));

    function getProductDetails(product) {
        let productName = product.querySelector('.product-title').textContent;
        let productPrice = Number(product.querySelector('.product-line-price').textContent);

        return { productName, productPrice };
    }

    function addToCart(cart, productName, productPrice) {
        if (!cart[productName]) {
            cart[productName] = 0;
        }

        cart[productName] += productPrice;
    }

    function displayAddedToCart(textArea, productName, productPrice) {
        textArea.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
    }

    function checkout(cart, textArea, buttons) {
        let products = Object.keys(cart).join(', ');
        let totalPrice = Object.values(cart).reduce((a, b) => a + b, 0);

        textArea.textContent += `You bought ${products} for ${totalPrice.toFixed(2)}.`;
        buttons.forEach((btn) => btn.disabled = true);
    }
}