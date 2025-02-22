using NUnit.Framework;

using System.Collections.Generic;
using System.Reflection.Emit;

namespace TestApp.UnitTests;

public class PalindromeTests
{
    [Test]
    public void Test_IsPalindrome_ValidPalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "Cat tac", "Dog God", "ChicKen nekCIHC" };
        bool expected = true;

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_IsPalindrome_EmptyList_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>();
        bool expected = true;

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_IsPalindrome_SingleWord_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "Snake EKAnS" };
        bool expected = true;

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_IsPalindrome_NonPalindrome_ReturnsFalse()
    {
        // Arrange
        List<string> input = new List<string>() { "WOlf FOL", "fOX XO" };
        bool expected = false;

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_IsPalindrome_MixedCasePalindrome_ReturnsTrue()
    {
        // Arrange
        List<string> input = new List<string>() { "LION noIL", "tiGER reGit", "ZebrA ARBeZ" };
        bool expected = true;

        // Act
        bool actual = Palindrome.IsPalindrome(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
