var lib = require('./P01SumOfNumbers.js');
let expect = require('chai').expect;

describe('Sum tests', function() {
    var data;
    beforeEach(function() {
        data = {};
    });

    it('should return NaN when the argument is a string', function() {
        const arg = 'test';
        const result = lib.sum(arg);
        expect(result).to.be.NaN;
    });

    it('should return 6', function() {
        const arg = ['1', '2', '3'];
        const result = lib.sum(arg);
        expect(result).to.eq(6);
    });

    it('should return NaN', function() {
        const arg = ['1', 'sdf', '3'];
        const result = lib.sum(arg);
        expect(result).to.be.NaN;
    });

    it('should return 7', function() {
        const arg = [1, 2, 4];
        const result = lib.sum(arg);
        expect(result).to.eq(7);
    });
});

describe('isSymmetric tests', function() {
    it('false when input is not an array', function() {
        const input = 'gv';
        const result = lib.isSymmetric(input);
        expect(result).to.be.false;
    });

    it('should not be symmetric', function() {
        const input = [1, 2, 3];
        const result = lib.isSymmetric(input);
        expect(result).to.be.false;
    });

    it('should be symmetric', function() {
        const input = [1, 2, 1];
        const result = lib.isSymmetric(input);
        expect(result).to.be.true;
    });
});

describe('RGBToHex tests', function() {
    it('should return undefined when first arg is not an int', function() {
        const input = ['red', 255, 255];
        const result = lib.RGBToHex(...input);
        expect(result).to.eq(undefined);
    });

    it('should return undefined when second arg is not an int', function() {
        const input = [255, 'green', 255];
        const result = lib.RGBToHex(...input);
        expect(result).to.eq(undefined);
    });

    it('should return undefined when third arg is not an int', function() {
        const input = [255, 255, 'blue'];
        const result = lib.RGBToHex(...input);
        expect(result).to.eq(undefined);
    });

    it('should convert rgb to hex', function() {
        const input = [252, 186, 3];
        const result = lib.RGBToHex(...input);
        expect(result).to.eq('#FCBA03');
    });
});

describe('Calculator tests', function() {
    it('should create calculator successfully', function() {
        const result = lib.calculator();
        expect(result).to.exist;
        expect(result.get()).to.eq(0);
    });

    it('should test calculator add', function() {
        const result = lib.calculator();
        result.add(5);
        expect(result.get()).to.eq(5);
    });

    it('should test calculator add and subtract', function() {
        const result = lib.calculator();
        result.add(10);
        result.subtract(3);
        expect(result.get()).to.eq(7);
    });
});