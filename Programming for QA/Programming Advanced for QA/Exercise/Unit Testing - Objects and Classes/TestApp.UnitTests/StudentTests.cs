using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class StudentTests
{
    private Student student;

    [SetUp]
    public void SetUp()
    {
        student = new Student();
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsStudentsInCity_WhenCityExists()
    {
        // Arrange
        string[] students = new string[] { "Ivan Ivanov 23 Plovdiv", "Georgi Ivanov 21 Devin", "Georgi Dimitrov 22 Plovdiv" };
        string town = "Plovdiv";
        string expected = $"Ivan Ivanov is 23 years old.{Environment.NewLine}Georgi Dimitrov is 22 years old.";

        // Act
        string actual = student.AddAndGetByCity(students, town);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenCityDoesNotExist()
    {
        // Arrange
        string[] students = new string[] { "Dimitar Ivanov 23 Plovdiv", "Plamen Ivanov 21 Devin", "Simeon Dimitrov 22 Plovdiv" };
        string town = "Velingrad";
        string expected = "";

        // Act
        string actual = student.AddAndGetByCity(students, town);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetByCity_ReturnsEmptyString_WhenNoStudentsGiven()
    {
        // Arrange
        string[] students = Array.Empty<string>();
        string town = "Smolyan";
        string expected = "";

        // Act
        string actual = student.AddAndGetByCity(students, town);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
