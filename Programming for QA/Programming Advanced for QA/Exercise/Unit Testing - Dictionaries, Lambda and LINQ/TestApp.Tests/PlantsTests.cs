using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = "";

        // Act
        string actual = Plants.GetFastestGrowing(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] input = new string[] { "Lavender" };
        string expected = $"Plants with 8 letters:{Environment.NewLine}Lavender";

        // Act
        string actual = Plants.GetFastestGrowing(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] input = new string[] { "lavender", "rose", "jasmine", "tulip", "cactus" };
        string expected = $"Plants with 4 letters:{Environment.NewLine}" +
            $"rose{Environment.NewLine}" +
            $"Plants with 5 letters:{Environment.NewLine}" +
            $"tulip{Environment.NewLine}" +
            $"Plants with 6 letters:{Environment.NewLine}" +
            $"cactus{Environment.NewLine}" +
            $"Plants with 7 letters:{Environment.NewLine}" +
            $"jasmine{Environment.NewLine}" +
            $"Plants with 8 letters:{Environment.NewLine}" +
            $"lavender";

        // Act
        string actual = Plants.GetFastestGrowing(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "ROSE", "rose", "CACtus", "cacTUS", "LAVender" };
        string expected = $"Plants with 4 letters:{Environment.NewLine}" +
            $"ROSE{Environment.NewLine}" +
            $"rose{Environment.NewLine}" +
            $"Plants with 6 letters:{Environment.NewLine}" +
            $"CACtus{Environment.NewLine}" +
            $"cacTUS{Environment.NewLine}" +
            $"Plants with 8 letters:{Environment.NewLine}" +
            $"LAVender";

        // Act
        string actual = Plants.GetFastestGrowing(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
