import { expect } from 'chai';
import { lookupChar } from '../CharLookup.js';

describe('LookupChar Function Tests', function () {

    it('Test: Should return undefined if first parameter(string) passed to lookupChar function is a number', function () {
        // Arrange
        let expected = undefined;
        let firstParameter = 3;
        let secondParameter = 3;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if first parameter(string) passed to lookupChar function is an array', function () {
        // Arrange
        let expected = undefined;
        let firstParameter = [];
        let secondParameter = 3;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if second parameter(index) passed to lookupChar function is a string', function () {
        // Arrange
        let expected = undefined;
        let firstParameter = 'test';
        let secondParameter = 'bug';

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if second parameter(index) passed to lookupChar function is a floating point number', function () {
        // Arrange
        let expected = undefined;
        let firstParameter = 'test';
        let secondParameter = 3.33;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return "Incorrect index" if value of second parameter(index) passed to lookupChar function is bigger than first parameter(string) length', function () {
        // Arrange
        let expected = 'Incorrect index';
        let firstParameter = 'test';
        let secondParameter = 8;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return "Incorrect index" if value of second parameter(index) passed to lookupChar function is equal to first parameter(string) length', function () {
        // Arrange
        let expected = 'Incorrect index';
        let firstParameter = 'test';
        let secondParameter = 4;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return "Incorrect index" if value of second parameter(index) passed to lookupChar function is negative number', function () {
        // Arrange
        let expected = 'Incorrect index';
        let firstParameter = 'test';
        let secondParameter = -7;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return "Incorrect index" if first parameter(string) passed to lookupChar function is empty string', function () {
        // Arrange
        let expected = 'Incorrect index';
        let firstParameter = '';
        let secondParameter = 0;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return character if both parameters passed to lookupChar function are valid', function () {
        // Arrange
        let expected = 's';
        let firstParameter = 'test';
        let secondParameter = 2;

        // Act
        let actual = lookupChar(firstParameter, secondParameter);

        //Assert
        expect(actual).to.equal(expected);
    });

});
