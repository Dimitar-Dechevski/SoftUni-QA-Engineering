using NUnit.Framework;

using System;
using System.Security.Cryptography.X509Certificates;
using TestApp.Vehicle;

namespace TestApp.UnitTests;

public class VehicleTests
{
    private Vehicles vehicles;

    [SetUp]
    public void SetUp()
    {
        vehicles = new Vehicles();
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsSortedCatalogue()
    {
        // Arrange
        string[] input = new string[] { "Car/Skoda/Fabia/150", "Truck/Scania/S730/9910", "Car/Audi/Q8/376" };
        string expected = $"Cars:{Environment.NewLine}Audi: Q8 - 376hp{Environment.NewLine}" +
                          $"Skoda: Fabia - 150hp{Environment.NewLine}" +
                          $"Trucks:{Environment.NewLine}Scania: S730 - 9910kg";

        // Act
        string actual = vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetCatalogue_ReturnsEmptyCatalogue_WhenNoDataGiven()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = $"Cars:{Environment.NewLine}Trucks:";

        // Act
        string actual = vehicles.AddAndGetCatalogue(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
