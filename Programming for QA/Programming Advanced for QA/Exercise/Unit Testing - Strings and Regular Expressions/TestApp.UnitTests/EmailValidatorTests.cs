using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    [TestCase("user88@user.com")]
    [TestCase("GUEST_@GUEST.COM")]
    [TestCase("Ghost_33@Ghost.Com")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange
        bool expected = true;

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase("user@user.")]
    [TestCase("@guest.com")]
    [TestCase("ghostghost.com")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange
        bool expected = false;

        // Act
        bool actual = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
