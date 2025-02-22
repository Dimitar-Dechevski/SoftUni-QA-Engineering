using NUnit.Framework;

namespace TestApp.UnitTests;

public class StringReverseTests
{

    [Test]
    public void Test_Reverse_WhenGivenEmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Reverse_WhenGivenSingleCharacterString_ReturnsSameCharacter()
    {
        //Arrange
        string input = "d";
        string expected = "d";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Reverse_WhenGivenNormalString_ReturnsReversedString()
    {
        //Arrange
        string input = "dog";
        string expected = "god";

        // Act
        string actual = StringReverse.Reverse(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
