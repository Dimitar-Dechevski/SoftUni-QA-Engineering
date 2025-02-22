using NUnit.Framework;

namespace TestApp.Tests;

public class PasswordValidatorTests
{
    [Test]
    public void Test_CheckPassword_ValidPassword_ReturnsValidMessage()
    {
        // Arrange
        string password = "pass987";
        string expecterd = "Password is valid";

        // Act
        string actual = PasswordValidator.CheckPassword(password);

        // Assert
        Assert.AreEqual(expecterd, actual);
    }

    [Test]
    public void Test_CheckPassword_PasswordTooShort_ReturnsErrorMessage()
    {
        // Arrange
        string password = "pa88";
        string expecterd = "Password must be between 6 and 10 characters";

        // Act
        string actual = PasswordValidator.CheckPassword(password);

        // Assert
        Assert.AreEqual(expecterd, actual);
    }

    [Test]
    public void Test_CheckPassword_ContainsSpecialCharacters_ReturnsErrorMessage()
    {
        // Arrange
        string password = "pass8@#";
        string expecterd = "Password must consist only of letters and digits";

        // Act
        string actual = PasswordValidator.CheckPassword(password);

        // Assert
        Assert.AreEqual(expecterd, actual);
    }

    [Test]
    public void Test_CheckPassword_InsufficientDigits_ReturnsErrorMessage()
    {
        // Arrange
        string password = "password9";
        string expecterd = "Password must have at least 2 digits";

        // Act
        string actual = PasswordValidator.CheckPassword(password);

        // Assert
        Assert.AreEqual(expecterd, actual);
    }

    [Test]
    public void Test_CheckPassword_ValidPasswordWithMaximumLength_ReturnsValidMessage()
    {
        // Arrange
        string password = "password88";
        string expecterd = "Password is valid";

        // Act
        string actual = PasswordValidator.CheckPassword(password);

        // Assert
        Assert.AreEqual(expecterd, actual);
    }
}
