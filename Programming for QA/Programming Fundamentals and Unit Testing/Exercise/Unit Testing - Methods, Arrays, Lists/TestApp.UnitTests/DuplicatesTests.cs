using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class DuplicatesTests
{

    [Test]
    public void Test_RemoveDuplicates_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] numbers = Array.Empty<int>();
        int[] expected = Array.Empty<int>();

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveDuplicates_NoDuplicates_ReturnsOriginalArray()
    {
        // Arrange
        int[] numbers = new int[] { 15, 30, 9, 67, 84 };
        int[] expected = new int[] { 15, 30, 9, 67, 84 };

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveDuplicates_SomeDuplicates_ReturnsUniqueArray()
    {
        // Arrange
        int[] numbers = new int[] { 46, 86, 33, 99, 46, 86, 99 };
        int[] expected = new int[] { 46, 86, 33, 99 };

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveDuplicates_AllDuplicates_ReturnsSingleElementArray()
    {
        // Arrange
        int[] numbers = new int[] { 88, 88, 88, 88, 88, 88 };
        int[] expected = new int[] { 88 };

        // Act
        int[] actual = Duplicates.RemoveDuplicates(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
