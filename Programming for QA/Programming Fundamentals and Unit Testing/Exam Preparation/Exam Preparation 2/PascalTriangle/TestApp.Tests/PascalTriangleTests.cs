using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class PascalTriangleTests
{
    [TestCase(-1, "")]
    [TestCase(0, "")]
    [TestCase(2, "1 " + "\n" + "1 1 " + "\n")]
    [TestCase(3, "1 " + "\n" + "1 1 " + "\n" + "1 2 1 " + "\n")]
    [TestCase(4, "1 " + "\n" + "1 1 " + "\n" + "1 2 1 " + "\n" + "1 3 3 1 " + "\n")]
    public void Test_PrintTriangle_ShouldReturnCorrectString(int n, string expected)
    {
        // Arrange

        // Act
        string actual = PascalTriangle.PrintTriangle(n);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
