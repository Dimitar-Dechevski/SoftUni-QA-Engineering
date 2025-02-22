using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> first = new Dictionary<string, int>();
        Dictionary<string, int> second = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(first, second);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> first = new Dictionary<string, int>()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3
        };
        Dictionary<string, int> second = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(first, second);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> first = new Dictionary<string, int>()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3
        };
        Dictionary<string, int> second = new Dictionary<string, int>()
        {
            ["d"] = 4,
            ["e"] = 5,
            ["f"] = 6
        };
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(first, second);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> first = new Dictionary<string, int>()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3
        };
        Dictionary<string, int> second = new Dictionary<string, int>()
        {
            ["d"] = 4,
            ["a"] = 1,
            ["c"] = 3
        };
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["a"] = 1,
            ["c"] = 3
        };

        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(first, second);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> first = new Dictionary<string, int>()
        {
            ["a"] = 1,
            ["b"] = 2,
            ["c"] = 3
        };
        Dictionary<string, int> second = new Dictionary<string, int>()
        {
            ["d"] = 4,
            ["a"] = 9,
            ["c"] = 8
        };
        Dictionary<string, int> expected = new Dictionary<string, int>();
       
        // Act
        Dictionary<string, int> actual = DictionaryIntersection.Intersect(first, second);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);
        CollectionAssert.AreEqual(expected, actual);
    }
}
