using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class PatternTests
{
    [Test]
    public void Test_SortInPattern_SortsIntArrayInPattern_SortsCorrectly()
    {
        // Arrange
        int[] numbers = new int[] { 86, 15, 20, 15, 36, 97, 5, 56 };
        int[] expected = new int[] { 5, 97, 15, 86, 20, 56, 36 };

        // Act
        int[] actual = Pattern.SortInPattern(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SortInPattern_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        int[] expected = Array.Empty<int>();

        // Act
        int[] actual = Pattern.SortInPattern(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SortInPattern_SingleElementArray_ReturnsSameArray()
    {
        // Arrange
        int[] numbers = new int[] { 86 };
        int[] expected = new int[] { 86 };

        // Act
        int[] actual = Pattern.SortInPattern(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
