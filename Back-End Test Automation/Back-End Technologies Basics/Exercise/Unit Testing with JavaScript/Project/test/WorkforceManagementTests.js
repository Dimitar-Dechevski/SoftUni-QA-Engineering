import { expect } from 'chai';
import { workforceManagement } from '../WorkforceManagement.js';

describe('WorkforceManagement Object Tests', function () {

    describe('RecruitStaff Function Tests', function () {

        it('Test: Should return message if value of role parameter is Developer and value of experience parameter passed to recruitStaff function is a number bigger than or equal to 4', function () {
            // Arrange
            let expected = 'Ivan has been successfully recruited for the role of Developer.';
            let nameParameter = 'Ivan';
            let roleParameeter = 'Developer';
            let experienceParameter = 6;

            // Act
            let actual = workforceManagement.recruitStaff(nameParameter, roleParameeter, experienceParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return message if value of role parameter is Developer and value of experience parameter passed to recruitStaff function is a number less than 4', function () {
            // Arrange
            let expected = 'Maria is not suitable for this role.';
            let nameParameter = 'Maria';
            let roleParameeter = 'Developer';
            let experienceParameter = 2;

            // Act
            let actual = workforceManagement.recruitStaff(nameParameter, roleParameeter, experienceParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return error if value of role parameter passed to recruitStaff function is different from Developer', function () {
            // Arrange
            let errorMessage = 'We are not currently hiring for this role.';
            let nameParameter = 'Georgi';
            let roleParameeter = 'Manager';
            let experienceParameter = 3;

            // Act

            // Assert
            expect(() => workforceManagement.recruitStaff(nameParameter, roleParameeter, experienceParameter)).to.throw(errorMessage);
        });

    });

    describe('ComputeWages Function Tests', function () {

        it('Test: Should return error if hoursWorked parameter passed to computeWages function is a string', function () {
            // Arrange
            let errorMessage = 'Invalid hours';
            let hoursWorkedParameter = 'test';

            // Act

            // Assert
            expect(() => workforceManagement.computeWages(hoursWorkedParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if value of hoursWorked parameter passed to computeWages function is a negative number', function () {
            // Arrange
            let errorMessage = 'Invalid hours';
            let hoursWorkedParameter = -120;

            // Act

            // Assert
            expect(() => workforceManagement.computeWages(hoursWorkedParameter)).to.throw(errorMessage);
        });

        it('Test: Should return employee salary without bonus if value of hoursWorked parameter passed to computeWages function is a positive number less than 160', function () {
            // Arrange
            let expected = 2160;
            let hoursWorkedParameter = 120;

            // Act
            let actual = workforceManagement.computeWages(hoursWorkedParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return employee salary without bonus if value of hoursWorked parameter passed to computeWages function is a positive number equal to 160', function () {
            // Arrange
            let expected = 2880;
            let hoursWorkedParameter = 160;

            // Act
            let actual = workforceManagement.computeWages(hoursWorkedParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

        it('Test: Should return employee salary with bonus if value of hoursWorked parameter passed to computeWages function is a positive number bigger than 160', function () {
            // Arrange
            let expected = 4740;
            let hoursWorkedParameter = 180;

            // Act
            let actual = workforceManagement.computeWages(hoursWorkedParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

    });

    describe('DismissEmployee Function Tests', function () {

        it('Test: Should return error if workforce parameter passed to dismissEmployee function is a string', function () {
            // Arrange
            let errorMessage = 'Invalid input';
            let workforceParameter = 'test';
            let employeeIndexParameter = 3;

            // Act

            // Assert
            expect(() => workforceManagement.dismissEmployee(workforceParameter, employeeIndexParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if employeeIndex parameter passed to dismissEmployee function is a string', function () {
            // Arrange
            let errorMessage = 'Invalid input';
            let workforceParameter = ['Ivan', 'Petko', 'Lazar', 'Georgi', 'Stanislav', 'Simeon'];
            let employeeIndexParameter = 'test';

            // Act

            // Assert
            expect(() => workforceManagement.dismissEmployee(workforceParameter, employeeIndexParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if value of employeeIndex parameter passed to dismissEmployee function is negative number', function () {
            // Arrange
            let errorMessage = 'Invalid input';
            let workforceParameter = ['Ivan', 'Petko', 'Lazar', 'Georgi', 'Stanislav', 'Simeon'];
            let employeeIndexParameter = -3;

            // Act

            // Assert
            expect(() => workforceManagement.dismissEmployee(workforceParameter, employeeIndexParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if value of employeeIndex parameter passed to dismissEmployee function is number bigger than array length passed to workforce parameter', function () {
            // Arrange
            let errorMessage = 'Invalid input';
            let workforceParameter = ['Ivan', 'Petko', 'Lazar', 'Georgi', 'Stanislav', 'Simeon'];
            let employeeIndexParameter = 9;

            // Act

            // Assert
            expect(() => workforceManagement.dismissEmployee(workforceParameter, employeeIndexParameter)).to.throw(errorMessage);
        });

        it('Test: Should return error if value of employeeIndex parameter passed to dismissEmployee function is number equal to array length passed to workforce parameter', function () {
            // Arrange
            let errorMessage = 'Invalid input';
            let workforceParameter = ['Ivan', 'Petko', 'Lazar', 'Georgi', 'Stanislav', 'Simeon'];
            let employeeIndexParameter = 6;

            // Act

            // Assert
            expect(() => workforceManagement.dismissEmployee(workforceParameter, employeeIndexParameter)).to.throw(errorMessage);
        });

        it('Test: Should return all available employeess if both parameters passed to dismissEmployee function are valid', function () {
            // Arrange
            let expected = 'Ivan, Petko, Lazar, Georgi, Simeon';
            let workforceParameter = ['Ivan', 'Petko', 'Lazar', 'Georgi', 'Stanislav', 'Simeon'];
            let employeeIndexParameter = 4;

            // Act
            let actual = workforceManagement.dismissEmployee(workforceParameter, employeeIndexParameter);

            // Assert
            expect(actual).to.equal(expected);
        });

    });

});
