import { expect } from 'chai';
import { foodDelivery } from '../FoodDelivery.js';

describe('FoodDelivery Object Tests', function () {

    describe('GetCategory Function Tests', function () {

        it('Test: Should return message if value of category parameter passed to getCategory function is Vegan', function () {
            // Arrange
            let expected = 'Dishes that contain no animal products.';
            let categoryParameter = 'Vegan';

            // Act
            let actual = foodDelivery.getCategory(categoryParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if value of category parameter passed to getCategory function is Vegetarian', function () {
            // Arrange
            let expected = 'Dishes that contain no meat or fish.';
            let categoryParameter = 'Vegetarian';

            // Act
            let actual = foodDelivery.getCategory(categoryParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if value of category parameter passed to getCategory function is Gluten-Free', function () {
            // Arrange
            let expected = 'Dishes that contain no gluten.';
            let categoryParameter = 'Gluten-Free';

            // Act
            let actual = foodDelivery.getCategory(categoryParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if value of category parameter passed to getCategory function is All', function () {
            // Arrange
            let expected = 'All available dishes.';
            let categoryParameter = 'All';

            // Act
            let actual = foodDelivery.getCategory(categoryParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return error if value of category parameter passed to getCategory function is different from the given ones', function () {
            // Arrange
            let errorMessage = 'Invalid Category!';
            let categoryParameter = 'test';

            // Act

            // Assert
            expect(() => foodDelivery.getCategory(categoryParameter)).to.throw(errorMessage);
        });

    });

    describe('AddMenuItem Function Tests', function () {

        it('Test: Should return error if menuItem parameter passed to addMenuItem function is a string', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let menuItemParameter = 'test';
            let maxPriceParameter = 50;

            // Act

            // Assert
            expect(() => foodDelivery.addMenuItem(menuItemParameter, maxPriceParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if menuItem parameter passed to addMenuItem function is empty array', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let menuItemParameter = [];
            let maxPriceParameter = 50;

            // Act

            // Assert
            expect(() => foodDelivery.addMenuItem(menuItemParameter, maxPriceParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if maxPrice parameter passed to addMenuItem function is a string', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let menuItemParameter = [{ name: 'Sushi', price: 20 }];
            let maxPriceParameter = 'test';

            // Act

            // Assert
            expect(() => foodDelivery.addMenuItem(menuItemParameter, maxPriceParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if value of maxPrice parameter passed to addMenuItem function is less than 5', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let menuItemParameter = [{ name: 'Sushi', price: 20 }];
            let maxPriceParameter = 3;

            // Act

            // Assert
            expect(() => foodDelivery.addMenuItem(menuItemParameter, maxPriceParameter)).to.throw(errorMessage);
        });

        it('Test: Should return message if both parameters passed to addMenuItem function are valid', function () {
            // Arrange
            let expected = `There are 3 available menu items matching your criteria!`;
            let menuItemParameter = [{ name: 'Sushi', price: 39.99 }, { name: 'Paella', price: 34.99 },
            { name: 'White Truffles', price: 99.99 }, { name: 'Pizza', price: 24.99 }, { name: 'Kobe Beef', price: 80.99 }];
            let maxPriceParameter = 80;

            // Act
            let actual = foodDelivery.addMenuItem(menuItemParameter, maxPriceParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

    });

    describe('CalculateOrderCost Function Tests', function () {

        it('Test: Should return error if shipping parameter passed to calculateOrderCost function is a number', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let shippingParameter = 3
            let addonsParameter = [];
            let discountParameter = true;

            // Act

            // Assert
            expect(() => foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if addons parameter passed to calculateOrderCost function is a string', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let shippingParameter = []
            let addonsParameter = 'test';
            let discountParameter = false;

            // Act

            // Assert
            expect(() => foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if discount parameter passed to calculateOrderCost function is a number', function () {
            // Arrange
            let errorMessage = 'Invalid Information!';
            let shippingParameter = []
            let addonsParameter = [];
            let discountParameter = 9;

            // Act

            // Assert
            expect(() => foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter)).to.throw(errorMessage);
        });

        it('Test: Should return message if all three parameters are valid and value of shipping parameter passed to calculateOrderCost function is an array with one element whose value is standard', function () {
            // Arrange
            let expected = `You spend $3.00 for shipping and addons!`;
            let shippingParameter = ['standard']
            let addonsParameter = [];
            let discountParameter = false;

            // Act
            let actual = foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if all three parameters are valid and value of shipping parameter passed to calculateOrderCost function is an array with one element whose value is express', function () {
            // Arrange
            let expected = `You spend $5.00 for shipping and addons!`;
            let shippingParameter = ['express']
            let addonsParameter = [];
            let discountParameter = false;

            // Act
            let actual = foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if all three parameters are valid and value of addons parameter passed to calculateOrderCost function is an array with one element whose value is sauce', function () {
            // Arrange
            let expected = `You spend $1.00 for shipping and addons!`;
            let shippingParameter = []
            let addonsParameter = ['sauce'];
            let discountParameter = false;

            // Act
            let actual = foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if all three parameters are valid and value of addons parameter passed to calculateOrderCost function is an array with one element whose value is beverage', function () {
            // Arrange
            let expected = `You spend $3.50 for shipping and addons!`;
            let shippingParameter = []
            let addonsParameter = ['beverage'];
            let discountParameter = false;

            // Act
            let actual = foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if all three parameters are valid and value of discount parameter passed to calculateOrderCost function is true', function () {
            // Arrange
            let expected = `You spend $26.77 for shipping and addons with a 15% discount!`;
            let shippingParameter = ['standard', 'express', 'express', 'standard', 'standard']
            let addonsParameter = ['beverage', 'sauce', 'sauce', 'beverage', 'beverage'];
            let discountParameter = true;

            // Act
            let actual = foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if all three parameters are valid and value of discount parameter passed to calculateOrderCost function is false', function () {
            // Arrange
            let expected = `You spend $31.00 for shipping and addons!`;
            let shippingParameter = ['standard', 'express', 'express', 'standard', 'express']
            let addonsParameter = ['beverage', 'sauce', 'sauce', 'sauce', 'beverage'];
            let discountParameter = false;

            // Act
            let actual = foodDelivery.calculateOrderCost(shippingParameter, addonsParameter, discountParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

    });

});
