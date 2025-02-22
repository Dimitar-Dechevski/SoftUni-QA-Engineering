using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    [TestCase("car", 3, "cArcArcAr")]
    [TestCase("358976", 4, "358976358976358976358976")]
    [TestCase(" ", 5, "     ")]
    public void Test_GeneratePatternedString_ValidInput_ReturnsExpectedResult(string input,
        int repeater, string expected)
    {
        // Arrange

        // Act
        string actual = Pattern.GeneratePatternedString(input, repeater);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GeneratePatternedString_EmptyInput_ThrowsArgumentException()
    {
        // Arrange
        string input = string.Empty;
        int repeater = 3;

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repeater));
    }

    [Test]
    public void Test_GeneratePatternedString_NegativeRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "bus";
        int repeater = -8;

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repeater));
    }

    [Test]
    public void Test_GeneratePatternedString_ZeroRepetitionFactor_ThrowsArgumentException()
    {
        // Arrange
        string input = "ship";
        int repeater = 0;

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => Pattern.GeneratePatternedString(input, repeater));
    }
}
