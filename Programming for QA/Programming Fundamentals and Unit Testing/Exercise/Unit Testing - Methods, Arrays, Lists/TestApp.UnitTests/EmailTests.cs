using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailTests
{
    [Test]
    public void Test_IsValidEmail_ValidEmail()
    {
        // Arrange
        string email = "test@example.com";
        bool expected = true;

        // Act
        bool actual = Email.IsValidEmail(email);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase("testexample.com")]
    [TestCase("@example.com")]
    [TestCase("test@.com")]
    public void Test_IsValidEmail_InvalidEmail(string email)
    {
        // Arrange
        bool expected = false;

        // Act
        bool actual = Email.IsValidEmail(email);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestCase("")]
    [TestCase(null)]
    [TestCase("   ")]
    public void Test_IsValidEmail_NullInput(string email)
    {
        // Arrange
        bool expected = false;

        // Act
        bool actual = Email.IsValidEmail(email);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
