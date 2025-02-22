using NUnit.Framework;

namespace TestApp.UnitTests;

public class CalculateTests
{
    [TestCase(9, 6, 15)]
    [TestCase(9, -6, 3)]
    [TestCase(9, 0, 9)]
    [TestCase(0, 6, 6)]
    [TestCase(-9, 6, -3)]
    [TestCase(-9, -6, -15)]
    public void Test_Addition(int firstNumber, int secondNumber, int result)
    {
        // Arrange
        Calculate calculator = new Calculate();
        int expected = result;

        // Act
        int actual = calculator.Addition(firstNumber, secondNumber);

        // Assert
        Assert.AreEqual(expected, actual, "Addition did not work properly.");
    }

    [TestCase(8, 3, 5)]
    [TestCase(8, -3, 11)]
    [TestCase(8, 0, 8)]
    [TestCase(0, 3, -3)]
    [TestCase(-8, 3, -11)]
    [TestCase(-8, -3, -5)]
    public void Test_Subtraction(int firstNumber, int secondNumber, int result)
    {
        //Arrange
        Calculate calculator = new Calculate();
        int expected = result;

        //Act
        int actual = calculator.Subtraction(firstNumber, secondNumber);

        // Assert
        Assert.AreEqual(expected, actual, "Subtraction did not work properly.");
    }
}
