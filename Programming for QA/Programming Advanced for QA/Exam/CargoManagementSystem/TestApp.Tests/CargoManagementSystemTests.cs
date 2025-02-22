using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class CargoManagementSystemTests
{
    private CargoManagementSystem cargoManagementSystem;

    [SetUp]
    public void SetIUp()
    {
        cargoManagementSystem = new CargoManagementSystem();
    }

    [Test]
    public void Test_Constructor_CheckInitialEmptyCargoCollectionAndCount()
    {
        // Arrange
        List<string> expectedList = new List<string>();
        int expectedCount = 0;

        // Act
        List<string> actualList = cargoManagementSystem.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCount, cargoManagementSystem.CargoCount);
        Assert.AreEqual(expectedList.Count, actualList.Count);
    }

    [Test]
    public void Test_AddCargo_ValidCargoName_AddNewCargo()
    {
        // Arrange
        string input = "furnitures and fixtures";
        int expectedCount = 1;
        List<string> expectedList = new List<string>
        {
            "furnitures and fixtures"
        };

        // Act
        cargoManagementSystem.AddCargo(input);
        List<string> actualList = cargoManagementSystem.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCount, cargoManagementSystem.CargoCount);
        Assert.AreEqual(expectedList.Count, actualList.Count);
        Assert.AreEqual(expectedList[0], actualList[0]);
    }

    [Test]
    public void Test_AddCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        string input = "";
        string expected = "Cargo cannot be empty or whitespace.";

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => cargoManagementSystem.AddCargo(input));
        ArgumentException exception = Assert.Throws<ArgumentException>(() => cargoManagementSystem.AddCargo(input));
        Assert.AreEqual(expected, exception.Message);
    }

    [Test]
    public void Test_RemoveCargo_ValidCargoName_RemoveFirstCargoName()
    {
        // Arrange
        string input = "food products";
        int expectedCount = 0;
        List<string> expectedList = new List<string>();

        // Act
        cargoManagementSystem.AddCargo(input);
        cargoManagementSystem.RemoveCargo(input);
        List<string> actualList = cargoManagementSystem.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCount, cargoManagementSystem.CargoCount);
        Assert.AreEqual(expectedList.Count, actualList.Count);
    }

    [Test]
    public void Test_RemoveCargo_NullOrEmptyCargoName_ThrowsArgumentException()
    {
        // Arrange
        string input = "";
        string expected = "Cargo not found in the system.";

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => cargoManagementSystem.RemoveCargo(input));
        ArgumentException exception = Assert.Throws<ArgumentException>(() => cargoManagementSystem.RemoveCargo(input));
        Assert.AreEqual(expected, exception.Message);
    }

    [Test]
    public void Test_GetAllCargos_AddedAndRemovedCargos_ReturnsExpectedCargoCollection()
    {
        // Arrange
        string firstCargo = "furnitures and fixtures";
        string secondCargo = "food products";
        string thirdCargo = "clothes";
        string fourthCargo = "auto parts";
        int expectedCount = 3;
        List<string> expectedList = new List<string>
        {
            "furnitures and fixtures",
            "clothes",
            "auto parts"
        };

        // Act
        cargoManagementSystem.AddCargo(firstCargo);
        cargoManagementSystem.AddCargo(secondCargo);
        cargoManagementSystem.AddCargo(thirdCargo);
        cargoManagementSystem.AddCargo(fourthCargo);
        cargoManagementSystem.RemoveCargo(secondCargo);
        List<string> actualList = cargoManagementSystem.GetAllCargos();

        // Assert
        Assert.AreEqual(expectedCount, cargoManagementSystem.CargoCount);
        Assert.AreEqual(expectedList.Count, actualList.Count);
        Assert.AreEqual(expectedList[0], actualList[0]);
        Assert.AreEqual(expectedList[1], actualList[1]);
        Assert.AreEqual(expectedList[2], actualList[2]);
    }
}

