// const { expect } = require('chai');
// const { PaymentPackage } = require('./E12. PaymentPackage');

describe('PaymentPackage class', function () {
    let instance;

    beforeEach(() => {
        instance = new PaymentPackage('package', 200);
    });

    it('initialises instance correctly', () => {
        expect(instance.name).to.equal('package');
        expect(instance.value).to.equal(200);
        expect(instance.VAT).to.equal(20);
        expect(instance.active).to.be.true;
    });

    it('throws error when name is not a string', () => {
        expect(() => new PaymentPackage(200, 200)).to.throw(Error);
    });

    it('throws error when name is an empty string', () => {
        expect(() => new PaymentPackage('', 200)).to.throw(Error);
    });

    it('throws error when value is not a number', () => {
        expect(() => new PaymentPackage('package', '200')).to.throw(Error);
    });

    it('throws error when value is a negative number', () => {
        expect(() => new PaymentPackage('package', -200)).to.throw(Error);
    });

    it('throws error when VAT is not a number', () => {
        expect(() => instance.VAT = '20').to.throw(Error);
    });

    it('throws error when VAT is a negative number', () => {
        expect(() => instance.VAT = -20).to.throw(Error);
    });

    it('throws error when active is not a boolean', () => {
        expect(() => instance.active = 'true').to.throw(Error);
    });

    it('toString() returns correct output', () => {
        expect(instance.toString()).to.equal('Package: package\n- Value (excl. VAT): 200\n- Value (VAT 20%): 240');
    });

    it('toString() returns correct output when active is false', () => {
        instance.active = false;
        expect(instance.toString()).to.equal('Package: package (inactive)\n- Value (excl. VAT): 200\n- Value (VAT 20%): 240');
    });

    it('toString() returns correct output when VAT is 0', () => {
        instance.VAT = 0;
        expect(instance.toString()).to.equal('Package: package\n- Value (excl. VAT): 200\n- Value (VAT 0%): 200');
    });

    it('toString() returns correct output when value is 0', () => {
        instance.value = 0;
        expect(instance.toString()).to.equal('Package: package\n- Value (excl. VAT): 0\n- Value (VAT 20%): 0');
    });
});
