using NUnit.Framework;
using System;

namespace TestApp.Tests;

public class ExtractFileTests
{
    [Test]
    public void Test_GetFile_NullPath_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(input));
    }

    [Test]
    public void Test_GetFile_EmptyPath_ThrowsArgumentNullException()
    {
        // Arrange
        string input = "";

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => ExtractFile.GetFile(input));
    }

    [Test]
    public void Test_GetFile_ValidPath_ReturnsFileNameAndExtension()
    {
        // Arrange
        string input = "D:\\QA\\Exam preparation.docx";
        string expected = "File name: Exam preparation" + "\n" + "File extension: docx";

        // Act
        string actual = ExtractFile.GetFile(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFile_PathWithNoExtension_ReturnsFileNameOnly()
    {
        // Arrange
        string input = "D:\\QA\\Exam preparation";
        string expected = "File name: Exam preparation";

        // Act
        string actual = ExtractFile.GetFile(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFile_PathWithSpecialCharacters_ReturnsFileNameAndExtension()
    {
        // Arrange
        string input = "D:\\QA@\\Exam preparation.docx";
        string expected = "File name: Exam preparation" + "\n" + "File extension: docx";

        // Act
        string actual = ExtractFile.GetFile(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
