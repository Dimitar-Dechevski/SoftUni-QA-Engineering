using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchNamesTests
{
    [Test]
    public void Test_Match_ValidNames_ReturnsMatchedNames()
    {
        // Arrange
        string input = "Franz Beckenbauer and Johan Cruyff and Patrick Vieira";
        string expected = "Franz Beckenbauer Johan Cruyff Patrick Vieira";

        // Act
        string actual = MatchNames.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_NoValidNames_ReturnsEmptyString()
    {
        // Arrange
        string input = "THIErry HEnry and marco MARCO REUS and paolo maldini";
        string expected = "";

        // Act
        string actual = MatchNames.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = MatchNames.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
