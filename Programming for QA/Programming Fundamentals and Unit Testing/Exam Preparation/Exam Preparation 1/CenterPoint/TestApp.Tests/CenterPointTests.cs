using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class CenterPointTests
{
    [Test]
    public void Test_GetClosest_WhenFirstPointIsCloser_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 1.00;
        double y1 = 3.00;
        double x2 = 3.00;
        double y2 = 3.00;
        string expected = "(1, 3)";

        // Act
        string actual = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsCloser_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 2.00;
        double y1 = 4.00;
        double x2 = 2.00;
        double y2 = 3.00;
        string expected = "(2, 3)";

        // Act
        string actual = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenBothPointsHaveEqualDistance_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = 1.00;
        double y1 = 2.00;
        double x2 = 1.00;
        double y2 = 2.00;
        string expected = "(1, 2)";

        // Act
        string actual = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenFirstPointIsNegative_ShouldReturnFirstPoint()
    {
        // Arrange
        double x1 = -1.00;
        double y1 = -4.00;
        double x2 = 1.00;
        double y2 = 4.00;
        string expected = "(-1, -4)";

        // Act
        string actual = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetClosest_WhenSecondPointIsNegative_ShouldReturnSecondPoint()
    {
        // Arrange
        double x1 = 3.00;
        double y1 = 6.00;
        double x2 = -3.00;
        double y2 = -6.00;
        string expected = "(-3, -6)";

        // Act
        string actual = CenterPoint.GetClosest(x1, y1, x2, y2);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
