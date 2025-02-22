using NUnit.Framework;

using System;
using System.Xml.Linq;

namespace TestApp.UnitTests;

public class PlanetTests
{
    [Test]
    public void Test_CalculateGravity_ReturnsCorrectCalculation()
    {
        // Arrange
        Planet planet = new("Jupiter", 142984, 778000000, 95);
        double mass = 1000;
        double expected = mass * 6.67430e-11 / Math.Pow(planet.Diameter / 2, 2);

        // Act
        double actual = planet.CalculateGravity(mass);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPlanetInfo_ReturnsCorrectInfo()
    {
        // Arrange
        Planet planet = new("Saturn", 120536, 1430000000, 146);

        string expected = $"Planet: {planet.Name}{Environment.NewLine}" +
                          $"Diameter: {planet.Diameter} km{Environment.NewLine}" +
                          $"Distance from the Sun: {planet.DistanceFromSun} km{Environment.NewLine}" +
                          $"Number of Moons: {planet.NumberOfMoons}";

        // Act
        string actual = planet.GetPlanetInfo();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
