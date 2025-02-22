using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = string.Empty;

        // Act
        string actual = RepeatStrings.Repeat(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        // Arrange
        string[] input = new string[] { "bear" };
        string expected = "bearbearbearbear";

        // Act
        string actual = RepeatStrings.Repeat(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] input = new string[] { "bear", "dog", "deer" };
        string expected = "bearbearbearbeardogdogdogdeerdeerdeerdeer";

        // Act
        string actual = RepeatStrings.Repeat(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
