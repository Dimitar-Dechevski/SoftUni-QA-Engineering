using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.UnitTests;

public class NumberProcessorTests
{
    [Test]
    public void Test_ProcessNumbers_SquareEvenNumbers()
    {
        // Arrange
        List<int> numbers = new List<int>() { 12, 20, 8 };
        List<double> expected = new List<double>() { 144, 400, 64 };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ProcessNumbers_SquareRootOddNumbers()
    {
        // Arrange
        List<int> numbers = new List<int>() { 81, 25, 49 };
        List<double> expected = new List<double>() { 9, 5, 7 };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ProcessNumbers_HandleZero()
    {
        // Arrange
        List<int> numbers = new List<int>() { 0 };
        List<double> expected = new List<double>() { 0 };

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ProcessNumbers_EmptyInput()
    {
        // Arrange
        List<int> numbers = new List<int>();
        List<double> expected = new List<double>();

        // Act
        List<double> actual = NumberProcessor.ProcessNumbers(numbers);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
