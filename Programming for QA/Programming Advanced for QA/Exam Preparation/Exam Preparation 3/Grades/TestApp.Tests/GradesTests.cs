using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class GradesTests
{
    [Test]
    public void Test_GetBestStudents_ReturnsBestThreeStudents()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            ["Ivan"] = 5,
            ["Dimitar"] = 3,
            ["Petko"] = 4,
            ["Georgi"] = 6,
            ["Simeon"] = 5
        };
        string expected = $"Georgi with average grade 6.00{Environment.NewLine}" +
                          $"Ivan with average grade 5.00{Environment.NewLine}" +
                          $"Simeon with average grade 5.00";

        // Act
        string actual = Grades.GetBestStudents(dict);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBestStudents_EmptyGrades_ReturnsEmptyString()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string expected = "";

        // Act
        string actual = Grades.GetBestStudents(dict);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBestStudents_LessThanThreeStudents_ReturnsAllStudents()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            ["Ivan"] = 5,
            ["Dimitar"] = 3
        };
        string expected = $"Ivan with average grade 5.00{Environment.NewLine}" +
                          $"Dimitar with average grade 3.00";

        // Act
        string actual = Grades.GetBestStudents(dict);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBestStudents_SameGrade_ReturnsInAlphabeticalOrder()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
            ["Ivan"] = 5,
            ["Dimitar"] = 5,
            ["Petko"] = 5,
            ["Georgi"] = 5,
            ["Simeon"] = 5
        };
        string expected = $"Dimitar with average grade 5.00{Environment.NewLine}" +
                          $"Georgi with average grade 5.00{Environment.NewLine}" +
                          $"Ivan with average grade 5.00";

        // Act
        string actual = Grades.GetBestStudents(dict);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
