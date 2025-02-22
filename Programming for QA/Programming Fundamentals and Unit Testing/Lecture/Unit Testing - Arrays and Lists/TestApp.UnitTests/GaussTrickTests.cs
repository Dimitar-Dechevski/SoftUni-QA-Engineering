using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class GaussTrickTests
{
    [Test]
    public void Test_SumPairs_InputIsEmptyList_ShouldReturnEmptyList()
    {
        // Arrange
        List<int> numbers = new List<int>();
        List<int> expected = new List<int>();

        // Act
        List<int> result = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    [Test]
    public void Test_SumPairs_InputHasSingleElement_ShouldReturnSameElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 15 };
        List<int> expected = new List<int>() { 15 };

        // Act
        List<int> actual = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SumPairs_InputHasEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> numbers = new List<int>() { 15, 88, 37, 46 };
        List<int> expected = new List<int>() { 61, 125 };

        // Act
        List<int> actual = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SumPairs_InputHasOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 15, 88, 33, 37, 46 };
        List<int> expected = new List<int>() { 61, 125, 33 };

        // Act
        List<int> actual = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeEvenCountElements_ShouldReturnSumPairs()
    {
        // Arrange
        List<int> numbers = new List<int>() { 15, 88, 33, 37, 46, 64, 11, 99 };
        List<int> expected = new List<int>() { 114, 99, 97, 83 };

        // Act
        List<int> actual = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_SumPairs_InputHasLargeOddCountElements_ShouldReturnWithMiddleElement()
    {
        // Arrange
        List<int> numbers = new List<int>() { 15, 88, 33, 37, 30, 46, 64, 11, 99 };
        List<int> expected = new List<int>() { 114, 99, 97, 83, 30 };

        // Act
        List<int> actual = GaussTrick.SumPairs(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
