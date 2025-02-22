using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverserTests
{
    [Test]
    public void Test_ReverseStrings_WithEmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string[] expected = Array.Empty<string>();

        // Act
        string[] actual = Reverser.ReverseStrings(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseStrings_WithSingleString_ReturnsReversedString()
    {
        // Arrange
        string[] input = new string[] { "Donkey" };
        string[] expected = new string[] { "yeknoD" };

        // Act
        string[] actual = Reverser.ReverseStrings(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseStrings_WithMultipleStrings_ReturnsReversedStrings()
    {
        // Arrange
        string[] input = new string[] { "Bear", "Dog", "Mouse" };
        string[] expected = new string[] { "raeB", "goD", "esuoM" };

        // Act
        string[] actual = Reverser.ReverseStrings(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseStrings_WithSpecialCharacters_ReturnsReversedSpecialCharacters()
    {
        // Arrange
        string[] input = new string[] { "Monkey!", "Cat@", "Shark#" };
        string[] expected = new string[] { "!yeknoM", "@taC", "#krahS" };

        // Act
        string[] actual = Reverser.ReverseStrings(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
