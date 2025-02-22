using System;
using NUnit.Framework;

namespace TestApp.Tests;
public class PrimeNumbersTests
{
    [Test]
    public void Test_GetPrimeNumbersInRange_StartNumberBiggerThanEndNumber_ReturnsErrorMessage()
    {
        // Arrange
        int startNumber = 33;
        int endNumber = 15;
        string expected = "Start number should be bigger than end number.";

        // Act
        string actual = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_StartAndEndNumberAreEqual_ReturnsEmptyString()
    {
        // Arrange
        int startNumber = 25;
        int endNumber = 25;
        string expected = "";

        // Act
        string actual = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_NoPrimeNumbers_ReturnsEmptyString()
    {
        // Arrange
        int startNumber = 32;
        int endNumber = 36;
        string expected = "";

        // Act
        string actual = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_WithPrimeAndNonPrimeNumbers_ReturnsOnlyPrimeNumbers()
    {
        // Arrange
        int startNumber = 1;
        int endNumber = 18;
        string expected = "2 3 5 7 11 13 17";

        // Act
        string actual = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPrimeNumbersInRange_OnlyPrimeNumbers_ReturnsAllNumbers()
    {
        // Arrange
        int startNumber = 2;
        int endNumber = 3;
        string expected = "2 3";

        // Act
        string actual = PrimeNumbers.GetPrimeNumbersInRange(startNumber, endNumber);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

