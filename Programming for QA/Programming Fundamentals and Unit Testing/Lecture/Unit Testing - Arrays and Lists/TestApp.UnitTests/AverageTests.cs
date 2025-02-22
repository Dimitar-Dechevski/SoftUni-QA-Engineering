using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class AverageTests
{
    [Test]
    public void Test_CalculateAverage_InputHasOneElement_ShouldReturnSameElement()
    {
        // Arrange
        int[] numbers = new int[] { 67 };
        double expected = 67;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateAverage_InputHasPositiveIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] numbers = new int[] { 44, 16, 8 };
        double expected = 22.666666666666668;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateAverage_InputHasNegativeIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] numbers = new int[] { -25, -37, -8, -3, -6, -5, -13 };
        double expected = -13.857142857142858;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateAverage_InputHasMixedIntegers_ShouldReturnCorrectAverage()
    {
        // Arrange
        int[] numbers = new int[] { -25, -37, 97, 15, 68, -11 };
        double expected = 17.833333333333332;

        // Act
        double actual = Average.CalculateAverage(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
