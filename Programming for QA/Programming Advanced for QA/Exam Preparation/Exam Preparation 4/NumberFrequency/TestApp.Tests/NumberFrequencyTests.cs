using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class NumberFrequencyTests
{
    [Test]
    public void Test_CountDigits_ZeroNumber_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<int, int> expected = new Dictionary<int, int>();
        int number = 0;

        // Act
        Dictionary<int, int> actual = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CountDigits_SingleDigitNumber_ReturnsDictionaryWithSingleEntry()
    {
        // Arrange
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [8] = 1
        };
        int number = 8;

        // Act
        Dictionary<int, int> actual = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CountDigits_MultipleDigitNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [8] = 2,
            [7] = 1,
            [6] = 1,
            [5] = 1,
            [3] = 2
        };
        int number = 8765383;

        // Act
        Dictionary<int, int> actual = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CountDigits_NegativeNumber_ReturnsDictionaryWithDigitFrequencies()
    {
        // Arrange
        Dictionary<int, int> expected = new Dictionary<int, int>()
        {
            [9] = 2,
            [6] = 1,
            [2] = 2,
            [1] = 1,
            [4] = 1
        };
        int number = -9621492;

        // Act
        Dictionary<int, int> actual = NumberFrequency.CountDigits(number);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
