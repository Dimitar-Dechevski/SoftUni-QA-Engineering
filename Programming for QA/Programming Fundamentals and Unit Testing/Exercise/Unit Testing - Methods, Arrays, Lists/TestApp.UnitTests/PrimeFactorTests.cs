using NUnit.Framework;

namespace TestApp.UnitTests;

public class PrimeFactorTests
{
    [Test]
    public void Test_FindLargestPrimeFactor_PrimeNumber()
    {
        // Arrange
        long number = 7;
        long expected = 7;

        // Act
        long actual = PrimeFactor.FindLargestPrimeFactor(number);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindLargestPrimeFactor_LargeNumber()
    {
        // Arrange
        long number = 121;
        long expected = 11;

        // Act
        long actual = PrimeFactor.FindLargestPrimeFactor(number);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
