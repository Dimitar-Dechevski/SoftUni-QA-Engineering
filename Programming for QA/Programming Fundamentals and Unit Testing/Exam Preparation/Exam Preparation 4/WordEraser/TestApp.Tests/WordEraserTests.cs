using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;

public class WordEraserTests
{
    [Test]
    public void Test_Erase_EmptyWordsList_ShouldReturnEmptyString()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> input = new List<string>();
        string word = "Bulgaria";
        string expected = "";

        // Act
        string actual = wordEraser.Erase(input, word);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Erase_NullWordsList_ShouldReturnEmptyString()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> input = null;
        string word = "Bulgaria";
        string expected = "";

        // Act
        string actual = wordEraser.Erase(input, word);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Erase_NullOrEmptyWordToErase_ShouldReturnStringOfGivenWordsList()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> input = new List<string>() { "Bulgaria", "France", "Spain", "Italy", "Serbia" };
        string word = "";
        string expected = "Bulgaria France Spain Italy Serbia";

        // Act
        string actual = wordEraser.Erase(input, word);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Erase_ValidInput_ShouldReturnEmptyString_WhenAllWordsMatchedTheWordToErase()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> input = new List<string>() { "Bulgaria", "Bulgaria", "Bulgaria", "Bulgaria", "Bulgaria" };
        string word = "Bulgaria";
        string expected = "";

        // Act
        string actual = wordEraser.Erase(input, word);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Erase_ValidInput_ShouldReturnStringWithoutErasedWords_WhenFewOfWordsMatchedWordToArese()
    {
        // Arrange
        WordEraser wordEraser = new WordEraser();
        List<string> input = new List<string>() { "Bulgaria", "France", "Spain", "Italy", "Serbia" };
        string word = "Bulgaria";
        string expected = "France Spain Italy Serbia";

        // Act
        string actual = wordEraser.Erase(input, word);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

