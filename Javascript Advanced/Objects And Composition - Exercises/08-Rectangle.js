function rectangle(width, height, color) {
    class FormRectangle {
        constructor(width, height, color) {
            this.width = Number(width);
            this.height = Number(height);
            this.color = color[0].toUpperCase() + color.slice(1);
        }

        calcArea = () => this.width * this.height;
    }

    return new FormRectangle(width, height, color);
}

let rect = rectangle(4, 5, 'red');
console.log(rect.width); // 4
console.log(rect.height); // 5
console.log(rect.color); // Red
console.log(rect.calcArea()); // 20
