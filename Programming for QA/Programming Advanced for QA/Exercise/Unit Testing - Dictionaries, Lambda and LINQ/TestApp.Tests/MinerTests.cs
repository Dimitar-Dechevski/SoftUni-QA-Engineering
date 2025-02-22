using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = "";

        // Act
        string actual = Miner.Mine(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "gold 50", "GOLD 35", "Gold 77" };
        string expected = $"gold -> 162";

        // Act
        string actual = Miner.Mine(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = new string[] { "Silver 33", "Bronze 88", "diamond 256", "BRONZE 12", "silver 97", "Diamond 40" };
        string expected = $"silver -> 130{Environment.NewLine}" +
            $"bronze -> 100{Environment.NewLine}" +
            $"diamond -> 296";

        // Act
        string actual = Miner.Mine(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
