using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests;

[TestFixture]
public class StringLengthCalculatorTests
{
    [Test]
    public void Test_Calculate_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = "";
        int expected = 0;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Calculate_SingleEvenLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "bear";
        int expected = 820;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Calculate_SingleOddLengthWord_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "sheep";
        int expected = 267;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Calculate_WholeSentenceString_ReturnsCorrectInteger()
    {
        // Arrange
        string input = "dog eagle rabbit";
        int expected = 3032;

        // Act
        int actual = StringLengthCalculator.Calculate(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

}

