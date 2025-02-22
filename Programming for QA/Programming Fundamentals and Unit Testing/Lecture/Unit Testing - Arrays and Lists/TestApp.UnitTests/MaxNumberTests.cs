using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MaxNumberTests
{
    [Test]
    public void Test_FindMax_InputHasOneElement_ShouldReturnTheElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 77 };
        int expected = 77;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasPositiveIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int>() { 77, 35, 84, 99 };
        int expected = 99;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasNegativeIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int>() { -45, -13, -8, -87 };
        int expected = -8;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasMixedIntegers_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int>() { 55, -46, 93, -78, 12, -8 };
        int expected = 93;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindMax_InputHasDuplicateMaxValue_ShouldReturnMaximum()
    {
        // Arrange
        List<int> numbers = new List<int>() { -46, 58, 72, -68, 72, -88 };
        int expected = 72;

        // Act
        int actual = MaxNumber.FindMax(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
