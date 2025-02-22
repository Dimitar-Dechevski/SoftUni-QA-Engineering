using NUnit.Framework;

using System;
using System.Linq;
using static NUnit.Framework.Constraints.Tolerance;

namespace TestApp.UnitTests;

public class ReverseConcatenateTests
{
    [Test]
    public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = string.Empty;

        // Act
        string actual = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
    {
        // Arrange
        string[] input = new string[] { "apple" };
        string expected = "apple";

        // Act
        string actual = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { "banana", "blueberry", "mango", "peach", "strawberry" };
        string expected = "strawberrypeachmangoblueberrybanana";

        // Act
        string actual = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = null;
        string expected = string.Empty;

        // Act
        string actual = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
    {
        // Arrange
        string[] input = new string[] { " " };
        string expected = " ";

        // Act
        string actual = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] input = new string[3333];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = (i * 3).ToString();
        }
        string expected = string.Join("", input.Reverse());

        // Act
        string actual = ReverseConcatenate.ReverseAndConcatenateStrings(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
