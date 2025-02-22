using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class WordLengthAnalyzerTests
{
    [Test]
    public void Test_AnalyzeSentence_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = "";
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_InvalidWordsWithDigits_ReturnsEmptyDictionary()
    {
        // Arrange
        string input = "fox8 panda3 dog9";
        Dictionary<string, int> expected = new Dictionary<string, int>();

        // Act
        Dictionary<string, int> actual = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_WordsWithDifferentThanLetterSymbols_ReturnsDictionaryOnlyWithValidWordTypesCount()
    {
        // Arrange
        string input = "lion@ bear# zebra";
        Dictionary<string, int> expected = new Dictionary<string, int>() 
        {
            ["medium"] = 1
        };

        // Act
        Dictionary<string, int> actual = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AnalyzeSentence_WholeSentenceWithValidWords_ReturnsAllTypeOfWordsWithCorrectCount()
    {
        // Arrange
        string input = "goat rabbit squirrel deer hedgehog hippopotamus";
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["short"] = 2,
            ["medium"] = 3,
            ["long"] = 1
        };

        // Act
        Dictionary<string, int> actual = WordLengthAnalyzer.AnalyzeSentence(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}

