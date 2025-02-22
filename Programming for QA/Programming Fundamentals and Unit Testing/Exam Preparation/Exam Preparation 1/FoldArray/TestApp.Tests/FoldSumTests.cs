using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class FoldSumTests
{
    [TestCase(new int[] { 10, 11, 12, 13 }, "21 25")]
    [TestCase(new int[] { -5, -6, -7, -8 }, "-11 -15")]
    [TestCase(new int[] { 15, 15, 15, 15 }, "30 30")]
    [TestCase(new int[] { 28, -88, 42, -72 }, "-60 -30")]
    [TestCase(new int[] { 20, 21, 22, 23, 24, 25, 26, 27 }, "43 43 51 51")]
    public void Test_FoldArray_ReturnsCorrectString(int[] arr, string expected)
    {
        // Arrange
        int[] numbers = arr;

        // Act
        string actual = FoldSum.FoldArray(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
