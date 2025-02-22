using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.Tests;

public class GroupingTests
{
    [Test]
    public void Test_GroupNumbers_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<int> input = new List<int>();
        string expected = "";

        // Act
        string actual = Grouping.GroupNumbers(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GroupNumbers_WithEvenAndOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 2, 3, 6, 8, 9, 7, 12, 33 };
        string expected = $"Even numbers: 2, 6, 8, 12{Environment.NewLine}" +
            $"Odd numbers: 3, 9, 7, 33";

        // Act
        string actual = Grouping.GroupNumbers(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyEvenNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 4, 16, 32, 64 };
        string expected = $"Even numbers: 4, 16, 32, 64";

        // Act
        string actual = Grouping.GroupNumbers(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GroupNumbers_WithOnlyOddNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { 5, 21, 57, 81 };
        string expected = $"Odd numbers: 5, 21, 57, 81";

        // Act
        string actual = Grouping.GroupNumbers(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GroupNumbers_WithNegativeNumbers_ShouldReturnGroupedString()
    {
        // Arrange
        List<int> input = new List<int>() { -4, -6, -11, -13, -27, -64, -108, -121 };
        string expected = $"Even numbers: -4, -6, -64, -108{Environment.NewLine}" +
            $"Odd numbers: -11, -13, -27, -121";

        // Act
        string actual = Grouping.GroupNumbers(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
