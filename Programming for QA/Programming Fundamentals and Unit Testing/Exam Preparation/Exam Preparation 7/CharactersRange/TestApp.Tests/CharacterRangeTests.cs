using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class CharacterRangeTests
{
    [Test]
    public void Test_GetRange_WithAAndBInOrder_ReturnsEmptyString()
    {
        // Arrange
        char firstSymbol = 'a';
        char secondSymbol = 'b';
        string expected = "";

        // Act
        string actual = CharacterRange.GetRange(firstSymbol, secondSymbol);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetRange_WithBAndAInOrder_ReturnsEmptyString()
    {
        // Arrange
        char firstSymbol = 'b';
        char secondSymbol = 'a';
        string expected = "";

        // Act
        string actual = CharacterRange.GetRange(firstSymbol, secondSymbol);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetRange_WithAAndCInOrder_ReturnsB()
    {
        // Arrange
        char firstSymbol = 'a';
        char secondSymbol = 'c';
        string expected = "b";

        // Act
        string actual = CharacterRange.GetRange(firstSymbol, secondSymbol);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetRange_WithDAndGInOrder_Returns_E_F()
    {
        // Arrange
        char firstSymbol = 'd';
        char secondSymbol = 'g';
        string expected = "e f";

        // Act
        string actual = CharacterRange.GetRange(firstSymbol, secondSymbol);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetRange_WithXAndZInOrder_Returns_Y()
    {
        // Arrange
        char firstSymbol = 'x';
        char secondSymbol = 'z';
        string expected = "y";

        // Act
        string actual = CharacterRange.GetRange(firstSymbol, secondSymbol);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
