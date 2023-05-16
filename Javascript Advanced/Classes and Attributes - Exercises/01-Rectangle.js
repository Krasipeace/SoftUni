class Rectangle {
    constructor(width, height, color) {
        this.width = Number(width);
        this.height = Number(height);
        this.color = color[0].toUpperCase() + color.slice(1);
    }

    calcArea = () => this.width * this.height;
}

let rect = new Rectangle(4, 5, 'red');
console.log(rect.width); // 4
console.log(rect.height); // 5
console.log(rect.color); // Red
console.log(rect.calcArea()); // 20