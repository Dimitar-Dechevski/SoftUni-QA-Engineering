using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DivisibilityTransformatorTest
{
    [Test]
    public void Test_Transform_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Transform_InvalidValues_ReturnsEmptyString()
    {
        // Arrange
        string input = "abc def";
        string expected = "";

        // Act
        string actual = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Transform_ValidValues_ReturnsTransformedValues()
    {
        // Arrange
        string input = "12 27 16 42 33 14";
        string expected = "2 13.5 256 32 16.5 196";

        // Act
        string actual = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Transform_ZeroOrNotDivisibleValues_ReturnsSameValues()
    {
        // Arrange
        string input = "5 7 0 11 13 17";
        string expected = "5 7 0 11 13 17";

        // Act
        string actual = DivisibilityTransformator.Transform(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

