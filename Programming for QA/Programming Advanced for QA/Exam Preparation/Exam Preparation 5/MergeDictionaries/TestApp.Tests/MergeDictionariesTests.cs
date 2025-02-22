using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class MergeDictionariesTests
{
    [Test]
    public void Test_Merge_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDict = new Dictionary<string, int>();
        Dictionary<string, int> secondDict = new Dictionary<string, int>();
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = MergeDictionaries.Merge(firstDict, secondDict);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Merge_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsNonEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDict = new Dictionary<string, int>();
        Dictionary<string, int> secondDict = new Dictionary<string, int>()
        {
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };

        // Act
        Dictionary<string, int> actual = MergeDictionaries.Merge(firstDict, secondDict);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Merge_TwoNonEmptyDictionaries_ReturnsMergedDictionary()
    {
        // Arrange
        Dictionary<string, int> firstDict = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["four"] = 4,
            ["eight"] = 8,
            ["ten"] = 10
        };
        Dictionary<string, int> secondDict = new Dictionary<string, int>()
        {
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["four"] = 4,
            ["eight"] = 8,
            ["ten"] = 10,
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };

        // Act
        Dictionary<string, int> actual = MergeDictionaries.Merge(firstDict, secondDict);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Merge_OverlappingKeys_ReturnsMergedDictionaryWithValuesFromDict2()
    {
        // Arrange
        Dictionary<string, int> firstDict = new Dictionary<string, int>()
        {
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };
        Dictionary<string, int> secondDict = new Dictionary<string, int>()
        {
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["seven"] = 7,
            ["six"] = 6,
            ["five"] = 5,
            ["nine"] = 9,
            ["three"] = 3
        };

        // Act
        Dictionary<string, int> actual = MergeDictionaries.Merge(firstDict, secondDict);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
