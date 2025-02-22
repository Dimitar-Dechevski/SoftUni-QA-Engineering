using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class AdjacentEqualTests
{
    [Test]
    public void Test_Sum_InputIsEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> numbers = new List<int>();
        string expected = "";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_NoAdjacentEqualNumbers_ShouldReturnOriginalList()
    {
        // Arrange
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
        string expected = "1 2 3 4 5";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersExist_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int>() { 3, 38, 46, 84, 7, 7, 9, 6, 4 };
        string expected = "3 38 46 84 14 9 6 4";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AllNumbersAreAdjacentEqual_ShouldReturnSingleSummedNumber()
    {
        // Arrange
        List<int> numbers = new List<int>() { 32, 32 };
        string expected = "64";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtBeginning_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int>() { 3, 3, 17, 38, 98, 73 };
        string expected = "6 17 38 98 73";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersAtEnd_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int>() { 12, 36, 42, 87, 63, 54, 54 };
        string expected = "12 36 42 87 63 108";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Sum_AdjacentEqualNumbersInMiddle_ShouldReturnSummedList()
    {
        // Arrange
        List<int> numbers = new List<int>() { 38, 85, 72, 72, 46, 99 };
        string expected = "38 85 144 46 99";

        // Act
        string actual = AdjacentEqual.Sum(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
