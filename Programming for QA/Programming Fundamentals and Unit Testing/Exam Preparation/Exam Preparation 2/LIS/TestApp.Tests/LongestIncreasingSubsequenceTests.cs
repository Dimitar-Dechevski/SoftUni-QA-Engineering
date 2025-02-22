using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class LongestIncreasingSubsequenceTests
{
    [Test]
    public void Test_GetLis_NullArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] numbers = null;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => LongestIncreasingSubsequence.GetLis(numbers));
    }

    [Test]
    public void Test_GetLis_EmptyArray_ReturnsEmptyString()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        string expected = string.Empty;

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetLis_SingleElementArray_ReturnsElement()
    {
        // Arrange
        int[] numbers = new int[] { 8 };
        string expected = "8";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetLis_UnsortedArray_ReturnsLongestIncreasingSubsequence()
    {
        // Arrange
        int[] numbers = new int[] { 11, 8, 9, 10, 7, 5 };
        string expected = "8 9 10";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetLis_SortedArray_ReturnsItself()
    {
        // Arrange
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6 };
        string expected = "1 2 3 4 5 6";

        // Act
        string actual = LongestIncreasingSubsequence.GetLis(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
