using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class CsvParserTests
{
    [Test]
    public void Test_ParseCsv_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string input = "";
        string[] expected = Array.Empty<string>();

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseCsv_SingleField_ReturnsArrayWithOneElement()
    {
        // Arrange
        string input = "Dog";
        string[] expected = new string[] { "Dog" };

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseCsv_MultipleFields_ReturnsArrayWithMultipleElements()
    {
        // Arrange
        string input = "Dog, Bear, Deer, Eagle";
        string[] expected = new string[] { "Dog", "Bear", "Deer", "Eagle" };

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseCsv_TrimsWhiteSpace_ReturnsCleanArray()
    {
        // Arrange
        string input = "   Wolf   ,   Mouse   ,   Cat   ";
        string[] expected = new string[] { "Wolf", "Mouse", "Cat" };

        // Act
        string[] actual = CsvParser.ParseCsv(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
