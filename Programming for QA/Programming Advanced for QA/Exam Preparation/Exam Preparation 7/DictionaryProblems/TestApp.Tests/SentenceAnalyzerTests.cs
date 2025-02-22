using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SentenceAnalyzerTests
{
    [Test]
    public void Test_Analyze_EmptyString_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>();
        string input = "";

        // Act
        Dictionary<string, int> actual = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Analyze_SingleLetter_ReturnsDictionaryWithSingleLetterEntry()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["letters"] = 1
        };
        string input = "D";

        // Act
        Dictionary<string, int> actual = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Analyze_SingleDigit_ReturnsDictionaryWithSingleDigitEntry()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["digits"] = 1
        };
        string input = "8";

        // Act
        Dictionary<string, int> actual = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Analyze_WholeSentence_ReturnsDictionaryWithAllSymbolTypesCount()
    {
        // Arrange
        Dictionary<string, int> expected = new Dictionary<string, int>()
        {
            ["letters"] = 4,
            ["digits"] = 2,
            ["special characters"] = 4
        };
        string input = "Test #33 !!!";

        // Act
        Dictionary<string, int> actual = SentenceAnalyzer.Analyze(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}

