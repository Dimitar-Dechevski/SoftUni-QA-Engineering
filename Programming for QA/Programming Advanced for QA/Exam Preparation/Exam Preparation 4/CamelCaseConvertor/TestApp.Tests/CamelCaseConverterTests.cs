using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class CamelCaseConverterTests
{
    [Test]
    public void Test_ConvertToCamelCase_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ConvertToCamelCase_SingleWord_ReturnsLowercaseWord()
    {
        // Arrange
        string input = "ABC";
        string expected = "abc";

        // Act
        string actual = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWords_ReturnsCamelCase()
    {
        // Arrange
        string input = "A BC";
        string expected = "aBc";

        // Act
        string actual = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ConvertToCamelCase_MultipleWordsWithMixedCase_ReturnsCamelCase()
    {
        // Arrange
        string input = "AB cd EF";
        string expected = "abCdEf";

        // Act
        string actual = CamelCaseConverter.ConvertToCamelCase(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
