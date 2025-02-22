using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class EmployeeManagementSystemTests
{
    [Test]
    public void Test_Constructor_CheckInitialEmptyEmployeeCollectionAndCount()
    {
        // Arrange
        List<string> expected = new List<string>();

        // Act
        EmployeeManagementSystem employeeManagementSystem = new EmployeeManagementSystem();
        int actual = employeeManagementSystem.EmployeeCount;

        // Assert
        Assert.AreEqual(expected.Count, actual);
    }

    [Test]
    public void Test_AddEmployee_ValidEmployeeName_AddNewEmployee()
    {
        // Arrange
        string firstEmployee = "Simeon";
        string secondmployee = "Preslav";
        string thirdEmployee = "Petar";
        List<string> expected = new List<string>() 
        {
            firstEmployee,
            secondmployee,
            thirdEmployee
        };

        // Act
        EmployeeManagementSystem employeeManagementSystem = new EmployeeManagementSystem();
        employeeManagementSystem.AddEmployee(firstEmployee);
        employeeManagementSystem.AddEmployee(secondmployee);
        employeeManagementSystem.AddEmployee(thirdEmployee);
        List<string> actualList = employeeManagementSystem.GetAllEmployees();
        int actual = employeeManagementSystem.EmployeeCount;

        // Assert
        Assert.AreEqual(expected.Count, actual);
        Assert.AreEqual(expected[0], actualList[0]);
        Assert.AreEqual(expected[1], actualList[1]);
        Assert.AreEqual(expected[2], actualList[2]);
    }

    [Test]
    public void Test_AddEmployee_NullOrEmptyEmployeeName_ThrowsArgumentException()
    {
        // Arrange
        string input = "";
        
        // Act
        EmployeeManagementSystem employeeManagementSystem = new EmployeeManagementSystem();

        // Assert
        Assert.Throws<ArgumentException>(() => employeeManagementSystem.AddEmployee(input));
    }

    [Test]
    public void Test_RemoveEmployee_ValidEmployeeName_RemoveFirstEmployeeName()
    {
        // Arrange
        string firstEmployee = "Simeon";
        string secondmployee = "Preslav";
        string thirdEmployee = "Petar";
        List<string> expected = new List<string>()
        {
            firstEmployee,
            thirdEmployee
        };

        // Act
        EmployeeManagementSystem employeeManagementSystem = new EmployeeManagementSystem();
        employeeManagementSystem.AddEmployee(firstEmployee);
        employeeManagementSystem.AddEmployee(secondmployee);
        employeeManagementSystem.AddEmployee(thirdEmployee);
        employeeManagementSystem.RemoveEmployee(secondmployee);
        List<string> actualList = employeeManagementSystem.GetAllEmployees();
        int actual = employeeManagementSystem.EmployeeCount;

        // Assert
        Assert.AreEqual(expected.Count, actual);
        Assert.AreEqual(expected[0], actualList[0]);
        Assert.AreEqual(expected[1], actualList[1]);
    }

    [Test]
    public void Test_RemoveEmployee_NullOrEmptyEmployeeName_ThrowsArgumentException()
    {
        // Arrange
        string input = "";

        // Act
        EmployeeManagementSystem employeeManagementSystem = new EmployeeManagementSystem();

        // Assert
        Assert.Throws<ArgumentException>(() => employeeManagementSystem.RemoveEmployee(input));
    }

    [Test]
    public void Test_GetAllEmployees_AddedAndRemovedEmployees_ReturnsExpectedEmployeeCollection()
    {
        // Arrange
        string firstEmployee = "Simeon";
        string secondmployee = "Preslav";
        string thirdEmployee = "Petar";
        List<string> expected = new List<string>()
        {
            secondmployee
        };

        // Act
        EmployeeManagementSystem employeeManagementSystem = new EmployeeManagementSystem();
        employeeManagementSystem.AddEmployee(firstEmployee);
        employeeManagementSystem.AddEmployee(secondmployee);
        employeeManagementSystem.AddEmployee(thirdEmployee);
        employeeManagementSystem.RemoveEmployee(secondmployee);
        employeeManagementSystem.RemoveEmployee(firstEmployee);
        employeeManagementSystem.RemoveEmployee(thirdEmployee);
        employeeManagementSystem.AddEmployee(secondmployee);
        List<string> actualList = employeeManagementSystem.GetAllEmployees();
        int actual = employeeManagementSystem.EmployeeCount;

        // Assert
        Assert.AreEqual(expected.Count, actual);
        Assert.AreEqual(expected[0], actualList[0]);
    }
}

