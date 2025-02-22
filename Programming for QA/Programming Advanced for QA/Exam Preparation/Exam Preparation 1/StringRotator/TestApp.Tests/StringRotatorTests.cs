using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringRotatorTests
{
    [Test]
    public void Test_RotateRight_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        int position = 3;
        string expected = "";

        // Act
        string actual = StringRotator.RotateRight(input, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByZeroPositions_ReturnsOriginalString()
    {
        // Arrange
        string input = "test";
        int position = 0;
        string expected = "test";

        // Act
        string actual = StringRotator.RotateRight(input, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByPositivePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "test";
        int position = 2;
        string expected = "stte";

        // Act
        string actual = StringRotator.RotateRight(input, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByNegativePositions_ReturnsRotatedString()
    {
        // Arrange
        string input = "test";
        int position = -3;
        string expected = "estt";

        // Act
        string actual = StringRotator.RotateRight(input, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RotateRight_RotateByMorePositionsThanStringLength_ReturnsRotatedString()
    {
        // Arrange
        string input = "test";
        int position = 9;
        string expected = "ttes";

        // Act
        string actual = StringRotator.RotateRight(input, position);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
