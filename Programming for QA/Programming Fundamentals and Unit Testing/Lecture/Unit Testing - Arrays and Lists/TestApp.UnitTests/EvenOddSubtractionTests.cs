using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class EvenOddSubtractionTests
{
    [Test]
    public void Test_FindDifference_InputIsEmpty_ShouldReturnZero()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        int expected = 0;

        // Act
        int actual = EvenOddSubtraction.FindDifference(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindDifference_InputHasOnlyEvenNumbers_ShouldReturnEvenSum()
    {
        // Arrange
        int[] numbers = new int[] { 2, 4, 8, 12, 6 };
        int expected = 32;

        // Act
        int actual = EvenOddSubtraction.FindDifference(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindDifference_InputHasOnlyOddNumbers_ShouldReturnNegativeOddSum()
    {
        // Arrange
        int[] numbers = new int[] { 3, 5, 7, 11, 9 };
        int expected = -35;

        // Act
        int actual = EvenOddSubtraction.FindDifference(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindDifference_InputHasMixedNumbers_ShouldReturnDifference()
    {
        // Arrange
        int[] numbers = new int[] { 3, 5, 8, 4, 9, 12 };
        int expected = 7;

        // Act
        int actual = EvenOddSubtraction.FindDifference(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
