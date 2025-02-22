using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new List<string>();
        string expected = "";

        // Act
        string actual = CountCharacters.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new List<string>() { "" };
        string expected = "";

        // Act
        string actual = CountCharacters.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "d" };
        string expected = $"d -> 1";

        // Act
        string actual = CountCharacters.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "deer", "dog", "duck" };
        string expected = $"d -> 3{Environment.NewLine}" +
            $"e -> 2{Environment.NewLine}" +
            $"r -> 1{Environment.NewLine}" +
            $"o -> 1{Environment.NewLine}" +
            $"g -> 1{Environment.NewLine}" +
            $"u -> 1{Environment.NewLine}" +
            $"c -> 1{Environment.NewLine}" +
            $"k -> 1";

        // Act
        string actual = CountCharacters.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "@#", "%!", "!#", "%@", "&^" };
        string expected = $"@ -> 2{Environment.NewLine}" +
            $"# -> 2{Environment.NewLine}" +
            $"% -> 2{Environment.NewLine}" +
            $"! -> 2{Environment.NewLine}" +
            $"& -> 1{Environment.NewLine}" +
            $"^ -> 1";

        // Act
        string actual = CountCharacters.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
