import { expect } from 'chai';
import { sum } from '../SumOfNumbers.js';

describe('Sum Function Tests', function () {

    it('Test: Should return sum if parameter passed to sum function is array with one number', function () {
        // Arrange
        let numberArray = [1];
        let expected = 1;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return positive sum if parameter passed to sum function is array with positive numbers', function () {
        // Arrange
        let numberArray = [5, 9, 3];
        let expected = 17;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return negative sum if parameter passed to sum function is array with negative numbers', function () {
        // Arrange
        let numberArray = [-4, -8, -6];
        let expected = -18;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return zero if parameter passed to sum function is empty array', function () {
        // Arrange
        let numberArray = [];
        let expected = 0;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return sum if parameter passed to sum function is array with mixed numbers', function () {
        // Arrange
        let numberArray = [33, 27, -30, 15, -5, -10];
        let expected = 30;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return sum if parameter passed to sum function is array with more numbers', function () {
        // Arrange
        let numberArray = [33, 27, 5, 8, 16, 88, 97, 84, 42];
        let expected = 400;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return sum if parameter passed to sum function is array on which elements are numbers as a string', function () {
        // Arrange
        let numberArray = ['10', '2', '84'];
        let expected = 96;

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return NaN if parameter passed to sum function is array on which elements are chars', function () {
        // Arrange
        let numberArray = ['c', 'p', 'w'];

        // Act
        let actual = sum(numberArray);

        // Assert
        expect(actual).to.be.NaN;
    });

});
