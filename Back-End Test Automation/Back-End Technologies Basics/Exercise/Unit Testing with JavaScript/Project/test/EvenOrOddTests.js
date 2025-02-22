import { expect } from 'chai';
import { isOddOrEven } from '../EvenOrOdd.js'

describe('IsOddOrEven Function Tests', function () {

    it('Test: Should return undefined if parameter passed to isOddOrEven function is a number', function () {
        // Arrange
        let expected = undefined;
        let input = 3;

        // Act
        let actual = isOddOrEven(input);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if parameter passed to isOddOrEven function is an array', function () {
        // Arrange
        let expected = undefined;
        let input = [];

        // Act
        let actual = isOddOrEven(input);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if parameter passed to isOddOrEven function is an object', function () {
        // Arrange
        let expected = undefined;
        let input = {};

        // Act
        let actual = isOddOrEven(input);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return "even" if parameter passed to isOddOrEven function is a string with even length', function () {
        // Arrange
        let expected = 'even';
        let input = 'test';

        // Act
        let actual = isOddOrEven(input);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return "odd" if parameter passed to isOddOrEven function is a string with odd length', function () {
        // Arrange
        let expected = 'odd';
        let input = 'bug';

        // Act
        let actual = isOddOrEven(input);

        //Assert
        expect(actual).to.equal(expected);
    });

});
