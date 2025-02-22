using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class OddOccurrencesTests
{
    [Test]
    public void Test_FindOdd_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = "";

        // Act
        string actual = OddOccurrences.FindOdd(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindOdd_WithNoOddOccurrences_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = new string[] { "bulgaria", "italy", "italy", "bulgaria" };
        string expected = "";

        // Act
        string actual = OddOccurrences.FindOdd(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindOdd_WithSingleOddOccurrence_ShouldReturnTheOddWord()
    {
        // Arrange
        string[] input = new string[] { "brazil", "japan", "brazil", "canada", "canada" };
        string expected = "japan";

        // Act
        string actual = OddOccurrences.FindOdd(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindOdd_WithMultipleOddOccurrences_ShouldReturnAllOddWords()
    {
        // Arrange
        string[] input = new string[] { "spain", "hungary", "croatia", "france", "germany" };
        string expected = "spain hungary croatia france germany";

        // Act
        string actual = OddOccurrences.FindOdd(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindOdd_WithMixedCaseWords_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "SERBIA", "Portugal", "australia", "serbia", "Serbia", "Australia", "AUSTRALIA" };
        string expected = "serbia portugal australia";

        // Act
        string actual = OddOccurrences.FindOdd(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
