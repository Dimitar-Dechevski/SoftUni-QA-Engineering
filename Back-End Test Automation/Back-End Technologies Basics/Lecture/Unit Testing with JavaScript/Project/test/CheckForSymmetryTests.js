import { expect } from 'chai';
import { isSymmetric } from '../CheckForSymmetry.js';

describe('IsSymmetric Function Tests', function () {

    it('Test: Should return false if parameter passed to isSymmetric function is with invalid type', function () {
        // Arrange
        let expected = false;
        let array = 3;

        // Act
        let actual = isSymmetric(array);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return true if parameter passed to isSymmetric function is symmetric array', function () {
        // Arrange
        let expected = true;
        let array = [8, 5, 3, 5, 8];

        // Act
        let actual = isSymmetric(array);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return false if parameter passed to isSymmetric function is non-symmetric array', function () {
        // Arrange
        let expected = false;
        let array = [8, 6, 4, 7, 3];

        // Act
        let actual = isSymmetric(array);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return true if parameter passed to isSymmetric function is empty array', function () {
        // Arrange
        let expected = true;
        let array = [];

        // Act
        let actual = isSymmetric(array);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return true if parameter passed to isSymmetric function is array with one element', function () {
        // Arrange
        let expected = true;
        let array = [9];

        // Act
        let actual = isSymmetric(array);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return false if parameter passed to isSymmetric function is array with two element, one of which is a number and the other is a number as a string', function () {
        // Arrange
        let expected = false;
        let array = ['8', 8];

        // Act
        let actual = isSymmetric(array);

        // Assert
        expect(actual).to.equal(expected);
    });

});
