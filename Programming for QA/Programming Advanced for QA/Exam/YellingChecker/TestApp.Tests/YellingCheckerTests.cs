using System;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class YellingCheckerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>();
        string input = "";

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyUpperCaseWords_ReturnsDictionaryWithYellingEntriesOnly()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>() 
        {
            ["yelling"] = 3
        };
        string input = "BEAR DOG DEER";

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyLowerCaseWords_ReturnsDictionaryWithSpeakingLowerEntriesOnly()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["speaking lower"] = 3
        };
        string input = "sheep tiger zebra";

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_OnlyMixedCaseWords_ReturnsDictionaryWithASpeakingNormalEntriesOnly()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["speaking normal"] = 3
        };
        string input = "Rabbit Shark Lion";

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_LowerUpperMixedCasesWords_ReturnsDictionaryWithAllTypeOfEntries()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["speaking lower"] = 1,
            ["speaking normal"] = 1,
            ["yelling"] = 1
        };
        string input = "fox Pigeon PANDA";

        // Act
        Dictionary<string, int> actual = YellingChecker.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}

