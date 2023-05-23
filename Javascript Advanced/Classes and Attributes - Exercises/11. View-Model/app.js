class Textbox {
    constructor (selector,regex){
        this._elements = document.querySelectorAll(selector);
        this._invalidSymbols = regex;
        Array
            .from(this._elements)
            .forEach(e => e.addEventListener('change',() => 
                this.value = e.value));
    }

    get value(){
        return this._value;
    }
    set value(value){
        this._value = value;
        Array
            .from(this._elements)
            .forEach(e => e.value = value);
    }

    get elements(){
        return this._elements;
    }

    isValid(){
        return !this._invalidSymbols.test(this.value);
    }
}
