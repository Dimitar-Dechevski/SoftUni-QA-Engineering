import { expect } from 'chai';
import { rgbToHexColor } from '../RGBToHex.js';

describe('RGBToHexColor Function Tests', function () {

    it('Test: Should return color in hexadecimal format as string if all three parameters passed to rgbToHexColor function are valid', function () {
        // Arrange
        let expected = '#562DC7';
        let red = 86;
        let green = 45;
        let blue = 199;

        // Act
        let actual = rgbToHexColor(red, green, blue);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if one of three parameters passed to rgbToHexColor function is with invalid type', function () {
        // Arrange
        let expected = undefined;
        let red = 145;
        let green = 222;
        let blue = 'blue';

        // Act
        let actual = rgbToHexColor(red, green, blue);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if one of three parameters passed to rgbToHexColor function is with a value outside lower boundary of the range', function () {
        // Arrange
        let expected = undefined;
        let red = -3;
        let green = 133;
        let blue = 99;

        // Act
        let actual = rgbToHexColor(red, green, blue);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if one of three parameters passed to rgbToHexColor function is with a value outside upper boundary of the range', function () {
        // Arrange
        let expected = undefined;
        let red = 55;
        let green = 260;
        let blue = 173;

        // Act
        let actual = rgbToHexColor(red, green, blue);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return color in hexadecimal format as string if all three parameters passed to rgbToHexColor function are with lower boundary value of the range', function () {
        // Arrange
        let expected = '#000000';
        let red = 0;
        let green = 0;
        let blue = 0;

        // Act
        let actual = rgbToHexColor(red, green, blue);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return color in hexadecimal format as string if all three parameters passed to rgbToHexColor function are with upper boundary value of the range', function () {
        // Arrange
        let expected = '#FFFFFF';
        let red = 255;
        let green = 255;
        let blue = 255;

        // Act
        let actual = rgbToHexColor(red, green, blue);

        // Assert
        expect(actual).to.equal(expected);
    });

});
