using NUnit.Framework;

namespace TestApp.UnitTests;

public class MatchPhoneNumbersTests
{
    [Test]
    public void Test_Match_ValidPhoneNumbers_ReturnsMatchedNumbers()
    {
        // Arrange
        string input = "+359-2-846-7539, +359 2 364 1732, +359-2-463-9157";
        string expected = "+359-2-846-7539, +359 2 364 1732, +359-2-463-9157";

        // Act
        string actual = MatchPhoneNumbers.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_NoValidPhoneNumbers_ReturnsEmptyString()
    {
        // Arrange
        string input = "+359-2 741-6792, +359-2-156 2587, +359 2 639-7921";
        string expected = "";

        // Act
        string actual = MatchPhoneNumbers.Match(input);

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
        string actual = MatchPhoneNumbers.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_MixedValidAndInvalidNumbers_ReturnsOnlyValidNumbers()
    {
        // Arrange
        string input = "+359-2-586-348, +359-2-249-3596, +359 2 4314 2789, +359-2 537-4862, +359 2 198 2088, +359-2-073-0892";
        string expected = "+359-2-249-3596, +359 2 198 2088, +359-2-073-0892";

        // Act
        string actual = MatchPhoneNumbers.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
