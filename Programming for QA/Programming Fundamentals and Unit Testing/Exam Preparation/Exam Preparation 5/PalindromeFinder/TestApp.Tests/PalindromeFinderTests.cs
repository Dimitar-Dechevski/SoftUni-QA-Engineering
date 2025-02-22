using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestApp.Tests;
public class PalindromeFinderTests
{
    [Test]
    public void Test_GetPalindromes_NullWordsList_ReturnsEmptyString()
    {
        // Arrange
        List<string> input = null;
        string expected = "";

        // Act
        string actual = PalindromeFinder.GetPalindromes(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPalindromes_EmptyWordsList_ReturnsEmptyString()
    {
        // Arrange
        List<string> input = new List<string>();
        string expected = "";

        // Act
        string actual = PalindromeFinder.GetPalindromes(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPalindromes_ListWithWords_ReturnsOnlyPalidromeWords()
    {
        // Arrange
        List<string> input = new List<string>() { "bear", "wolf", "zebra", "dog", "cat tac"};
        string expected = "cat tac";

        // Act
        string actual = PalindromeFinder.GetPalindromes(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPalindromes_ListWithoutPalindromeWords_ReturnsEmptyString()
    {
        // Arrange
        List<string> input = new List<string>() { "bear", "wolf", "zebra", "dog", "cat" };
        string expected = "";

        // Act
        string actual = PalindromeFinder.GetPalindromes(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetPalindromes_ListOnlyWithPalidromeWords_ReturnsStringWithAllWords()
    {
        // Arrange
        List<string> input = new List<string>() { "bear raeb", "wolf flow", "zebra arbez", "dog god", "cat tac" };
        string expected = "bear raeb wolf flow zebra arbez dog god cat tac";

        // Act
        string actual = PalindromeFinder.GetPalindromes(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

