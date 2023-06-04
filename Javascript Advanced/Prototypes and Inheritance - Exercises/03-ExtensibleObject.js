function extensibleObject() {
    let obj = {};
    let clone = Object.create(obj);

    clone.extend = function (templates) {
        Object.entries(templates).forEach(([key, value]) => {
            if (typeof value === 'function') {
                obj[key] = value;
            } else {
                clone[key] = value;
            }
        });
    }

    return clone;
}

let obj = extensibleObject();
let template = {
    extensionMethod: function () {},
    extensionProperty: 'someString'
}
obj.extend(template);
console.log(obj);