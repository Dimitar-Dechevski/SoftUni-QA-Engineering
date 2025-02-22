using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ReverseTests
{
    [Test]
    public void Test_ReverseArray_InputIsEmpty_ShouldReturnEmptyString()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        string expected = "";

        // Act
        string actual = Reverse.ReverseArray(numbers);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseArray_InputHasOneElement_ShouldReturnTheSameElement()
    {
        // Arrange
        int[] numbers = new int[] { 88 };
        string exprected = "88";

        // Act
        string actual = Reverse.ReverseArray(numbers);

        // Assert
        Assert.AreEqual(exprected, actual);
    }

    [Test]
    public void Test_ReverseArray_InputHasMultipleElements_ShouldReturnReversedString()
    {
        // Arrange
        int[] numbers = new int[] { 46, 79, 15, 11, 33, 99 };
        string exprected = "99 33 11 15 79 46";

        // Act
        string actual = Reverse.ReverseArray(numbers);

        // Assert
        Assert.AreEqual(exprected, actual);
    }
}
