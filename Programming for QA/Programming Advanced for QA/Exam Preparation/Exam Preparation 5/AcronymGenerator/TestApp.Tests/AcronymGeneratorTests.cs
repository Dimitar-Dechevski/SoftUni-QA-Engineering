using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class AcronymGeneratorTests
{
    [Test]
    public void Test_GenerateAcronym_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GenerateAcronym_SingleWord_ReturnsUpperCaseFirstLetter()
    {
        // Arrange
        string input = "bulgaria";
        string expected = "B";

        // Act
        string actual = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GenerateAcronym_MultipleWords_ReturnsUpperCaseFirstLetters()
    {
        // Arrange
        string input = "south africa";
        string expected = "SA";

        // Act
        string actual = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GenerateAcronym_WordsWithNonLetters_ReturnsAcronymWithoutNonLetters()
    {
        // Arrange
        string input = "936857";
        string expected = "";

        // Act
        string actual = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GenerateAcronym_PhraseWithSpecialCharacters_ReturnsUpperCaseFirstLetters()
    {
        // Arrange
        string input = "@#$!";
        string expected = "";

        // Act
        string actual = AcronymGenerator.GenerateAcronym(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
