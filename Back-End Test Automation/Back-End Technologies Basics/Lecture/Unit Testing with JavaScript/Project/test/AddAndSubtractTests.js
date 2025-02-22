import { expect } from 'chai';
import { createCalculator } from '../AddAndSubtract.js';

describe('CreateCalculator Function Tests', function () {

    it('Test: Should return zero if parameter passed to add and subtract functions is the same', function () {

        // Arrange
        let expected = 0;
        let parameterForAddFunction = 3;
        let parameterForSubtractFunction = 3;

        // Act
        let object = createCalculator();
        let actual;
        object['add'](parameterForAddFunction);
        object['subtract'](parameterForSubtractFunction);
        object['add'](parameterForAddFunction);
        object['subtract'](parameterForSubtractFunction);
        actual = object['get']();

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return positive sum if only add function is executed on the calculator', function () {
        // Arrange
        let expected = 40;
        let parameterForAddFunction = 8;

        // Act
        let object = createCalculator();
        let actual;
        object['add'](parameterForAddFunction);
        object['add'](parameterForAddFunction);
        object['add'](parameterForAddFunction);
        object['add'](parameterForAddFunction);
        object['add'](parameterForAddFunction);
        actual = object['get']();

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return negative sum if only subtract function is executed on the calculator', function () {
        // Arrange
        let expected = -25;
        let parameterForSubtractFunction = 5;

        // Act
        let object = createCalculator();
        let actual;
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        actual = object['get']();

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return zero if only get function is executed on the calculator', function () {
        // Arrange
        let expected = 0;

        // Act
        let object = createCalculator();
        let actual;
        actual = object['get']();

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return sum if add and subtract functions on the calculator can convert parameter from number as a string to number', function () {
        // Arrange
        let expected = 30;
        let parameterForAddFunction = '45';
        let parameterForSubtractFunction = '30';

        // Act
        let object = createCalculator();
        let actual;
        object['add'](parameterForAddFunction);
        object['subtract'](parameterForSubtractFunction);
        object['add'](parameterForAddFunction);
        object['subtract'](parameterForSubtractFunction);
        actual = object['get']();

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return sum if add and subtract functions are executed several times on the calculator', function () {
        // Arrange
        let expected = 39;
        let parameterForAddFunction = 97;
        let parameterForSubtractFunction = 63;

        // Act
        let object = createCalculator();
        let actual;
        object['add'](parameterForAddFunction);
        object['add'](parameterForAddFunction);
        object['add'](parameterForAddFunction);
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        object['subtract'](parameterForSubtractFunction);
        actual = object['get']();

        // Assert
        expect(actual).to.equal(expected);
    });

});