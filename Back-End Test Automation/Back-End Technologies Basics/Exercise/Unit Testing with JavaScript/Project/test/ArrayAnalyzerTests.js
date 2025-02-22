import { expect } from 'chai';
import { analyzeArray } from '../ArrayAnalyzer.js';

describe('AnalyzeArray Function Tests', function () {

    it('Test: Should return undefined if parameter passed to analyzeArray function is a number', function () {
        // Arrange
        let expected = undefined;
        let parameter = 3;

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if parameter passed to analyzeArray function is an object', function () {
        // Arrange
        let expected = undefined;
        let parameter = {};

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if parameter passed to analyzeArray function is empty array', function () {
        // Arrange
        let expected = undefined;
        let parameter = [];

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return undefined if parameter passed to analyzeArray function is an array whose elements are strings', function () {
        // Arrange
        let expected = undefined;
        let parameter = ['word1', 'word2', 'word3', 'word4', 'word5'];

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.equal(expected);
    });

    it('Test: Should return object if parameter passed to analyzeArray function is an array with one element', function () {
        // Arrange
        let expected = {
            min: 3.33,
            max: 3.33,
            length: 1
        };
        let parameter = [3.33];

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.deep.equal(expected);
    });

    it('Test: Should return object if parameter passed to analyzeArray function is an array with equal elements', function () {
        // Arrange
        let expected = {
            min: 7.55,
            max: 7.55,
            length: 5
        };
        let parameter = [7.55, 7.55, 7.55, 7.55, 7.55];

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.deep.equal(expected);
    });

    it('Test: Should return object if parameter passed to analyzeArray function is an array with mixed elements', function () {
        // Arrange
        let expected = {
            min: -99.99,
            max: 484.84,
            length: 5
        };
        let parameter = [-99.99, -33.66, 484.84, 199.11, 85.15];

        // Act
        let actual = analyzeArray(parameter);

        // Assert
        expect(actual).to.deep.equal(expected);
    });

});
