// const { expect } = require('chai');
// const { StringBuilder } = require('./E13. StringBuilder');

describe ('StringBuilder class', () => {
    let instance = null;

    beforeEach(() => {
        instance = new StringBuilder();
    });

    it ('initialises all methods', () => {
        expect(Object.getPrototypeOf(instance).hasOwnProperty('append')).to.be.true;
        expect(Object.getPrototypeOf(instance).hasOwnProperty('prepend')).to.be.true;
        expect(Object.getPrototypeOf(instance).hasOwnProperty('insertAt')).to.be.true;
        expect(Object.getPrototypeOf(instance).hasOwnProperty('remove')).to.be.true;
        expect(Object.getPrototypeOf(instance).hasOwnProperty('toString')).to.be.true;
    });

    it ('constructor works correctly', () => {
        expect(instance._stringArray.length).to.equal(0);
    });

    it ('append works correctly', () => {
        instance.append('test');
        expect(instance._stringArray.join('')).to.equal('test');
    });

    it ('prepend works correctly', () => {
        instance.prepend('test');
        expect(instance._stringArray.join('')).to.equal('test');
    });

    it ('insertAt works correctly', () => {
        instance.append('test');
        instance.insertAt('123', 2);
        expect(instance._stringArray.join('')).to.equal('te123st');
    });

    it ('remove works correctly', () => {
        instance.append('test');
        instance.remove(1, 2);
        expect(instance._stringArray.join('')).to.equal('tt');
    });

    it ('toString works correctly', () => {
        instance.append('test');
        expect(instance.toString()).to.equal('test');
    });

    it ('throws error when param is not a string', () => {
        expect(() => instance.append(123)).to.throw(TypeError);
    });
});