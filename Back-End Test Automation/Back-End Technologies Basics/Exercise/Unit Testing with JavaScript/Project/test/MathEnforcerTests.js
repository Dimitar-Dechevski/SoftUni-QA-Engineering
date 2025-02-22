import { expect } from 'chai';
import { mathEnforcer } from '../MathEnforcer.js';

describe('MathEnforcer Object Tests', function () {

    describe('AddFive Function Tests', function () {

        it('Test: Should return undefined if parameter passed to addFive function is a string', function () {
            // Arrange
            let expected = undefined;
            let parameter = 'test';

            // Act
            let actual = mathEnforcer.addFive(parameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return undefined if parameter passed to addFive function is an array', function () {
            // Arrange
            let expected = undefined;
            let parameter = [];

            // Act
            let actual = mathEnforcer.addFive(parameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return result if parameter passed to addFive function is a negative number', function () {
            // Arrange
            let expected = 1.22;
            let parameter = -3.78;

            // Act
            let actual = mathEnforcer.addFive(parameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

        it('Test: Should return result if parameter passed to addFive function is a positive number', function () {
            // Arrange
            let expected = 18.62;
            let parameter = 13.62;

            // Act
            let actual = mathEnforcer.addFive(parameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

    });

    describe('SubtractTen Function Tests', function () {

        it('Test: Should return undefined if parameter passed to subtractTen function is a string', function () {
            // Arrange
            let expected = undefined;
            let parameter = 'bug';

            // Act
            let actual = mathEnforcer.subtractTen(parameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return undefined if parameter passed to subtractTen function is an array', function () {
            // Arrange
            let expected = undefined;
            let parameter = [];

            // Act
            let actual = mathEnforcer.subtractTen(parameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return result if parameter passed to subtractTen function is a negative number', function () {
            // Arrange
            let expected = -109.99;
            let parameter = -99.99;

            // Act
            let actual = mathEnforcer.subtractTen(parameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

        it('Test: Should return result if parameter passed to subtractTen function is a positive number', function () {
            // Arrange
            let expected = 186.35;
            let parameter = 196.35;

            // Act
            let actual = mathEnforcer.subtractTen(parameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

    });

    describe('Sum Function Tests', function () {

        it('Test: Should return undefined if first parameter passed to sum function is a string', function () {
            // Arrange
            let expected = undefined;
            let firstParameter = 'test';
            let secondParameter = 33;

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return undefined if first parameter passed to sum function is an array', function () {
            // Arrange
            let expected = undefined;
            let firstParameter = [];
            let secondParameter = 33;

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return undefined if second parameter passed to sum function is a string', function () {
            // Arrange
            let expected = undefined;
            let firstParameter = 84;
            let secondParameter = 'bug';

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return undefined if second parameter passed to sum function is an array', function () {
            // Arrange
            let expected = undefined;
            let firstParameter = 84;
            let secondParameter = [];

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return sum if both parameters passed to sum function are positive numbers', function () {
            // Arrange
            let expected = 108.95;
            let firstParameter = 45.32;
            let secondParameter = 63.63;

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

        it('Test: Should return sum if both parameters passed to sum function are negative numbers', function () {
            // Arrange
            let expected = -114.30;
            let firstParameter = -99.19;
            let secondParameter = -15.11;

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

        it('Test: Should return sum if both parameters passed to sum function are mixed numbers', function () {
            // Arrange
            let expected = 112.39;
            let firstParameter = 256.75;
            let secondParameter = -144.36;

            // Act
            let actual = mathEnforcer.sum(firstParameter, secondParameter);

            // Assert
            expect(actual).to.closeTo(expected, 0.01);
        });

    });

});
