using NUnit.Framework;

using System;

namespace TestApp.Tests;

public class CountRealNumbersTests
{
    [Test]
    public void Test_Count_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        int[] input = Array.Empty<int>();
        string expected = "";

        // Act
        string actual = CountRealNumbers.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithSingleNumber_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 7 };
        string expected = $"7 -> 1";

        // Act
        string actual = CountRealNumbers.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithMultipleNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 5, 3, 9, 33, 5, 256, 3 };
        string expected = $"3 -> 2{Environment.NewLine}" +
            $"5 -> 2{Environment.NewLine}" +
            $"9 -> 1{Environment.NewLine}" +
            $"33 -> 1{Environment.NewLine}" +
            $"256 -> 1";

        // Act
        string actual = CountRealNumbers.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithNegativeNumbers_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { -15, -12, -6, -88, -12, -1999, -15 };
        string expected = $"-1999 -> 1{Environment.NewLine}" +
            $"-88 -> 1{Environment.NewLine}" +
            $"-15 -> 2{Environment.NewLine}" +
            $"-12 -> 2{Environment.NewLine}" +
            $"-6 -> 1";

        // Act
        string actual = CountRealNumbers.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Count_WithZero_ShouldReturnCountString()
    {
        // Arrange
        int[] input = new int[] { 7, 9, -3, -46, 0, 84, -15 };
        string expected = $"-46 -> 1{Environment.NewLine}" +
            $"-15 -> 1{Environment.NewLine}" +
            $"-3 -> 1{Environment.NewLine}" +
            $"0 -> 1{Environment.NewLine}" +
            $"7 -> 1{Environment.NewLine}" +
            $"9 -> 1{Environment.NewLine}" +
            $"84 -> 1";

        // Act
        string actual = CountRealNumbers.Count(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
