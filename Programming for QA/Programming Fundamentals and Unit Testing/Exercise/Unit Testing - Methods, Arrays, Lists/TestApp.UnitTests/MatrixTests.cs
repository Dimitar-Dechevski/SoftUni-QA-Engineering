using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatrixTests
{
    [Test]
    public void Test_MatrixAddition_ValidInput_ReturnsCorrectResult()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>() { new List<int>() { 1, 2 }, new List<int>() { 3, 4 } };
        List<List<int>> matrixB = new List<List<int>>() { new List<int>() { 5, 6 }, new List<int>() { 7, 8 } };
        List<List<int>> expected = new List<List<int>>() { new List<int>() { 6, 8 }, new List<int>() { 10, 12 } };

        // Act
        List<List<int>> actual = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_MatrixAddition_EmptyMatrices_ReturnsEmptyMatrix()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>();
        List<List<int>> matrixB = new List<List<int>>();
        List<List<int>> expected = new List<List<int>>();

        // Act
        List<List<int>> actual = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_MatrixAddition_DifferentDimensions_ThrowsArgumentException()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>() { new List<int>() { 15, 54 }, new List<int>() { 85, 33 } };
        List<List<int>> matrixB = new List<List<int>>() { new List<int>() { 111, 5, 99 }, new List<int>() { 96, 23, 11 } };

        // Act


        // Assert
        Assert.Throws<ArgumentException>(() => Matrix.MatrixAddition(matrixA, matrixB));
    }

    [Test]
    public void Test_MatrixAddition_NegativeNumbers_ReturnsCorrectResult()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>() { new List<int>() { -12, -25 }, new List<int>() { -36, -48 } };
        List<List<int>> matrixB = new List<List<int>>() { new List<int>() { -55, -68 }, new List<int>() { -73, -88 } };
        List<List<int>> expected = new List<List<int>>() { new List<int>() { -67, -93 }, new List<int>() { -109, -136 } };

        // Act
        List<List<int>> actual = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_MatrixAddition_ZeroMatrix_ReturnsOriginalMatrix()
    {
        // Arrange
        List<List<int>> matrixA = new List<List<int>>() { new List<int>() { 37, 46 }, new List<int>() { 15, 93 } };
        List<List<int>> matrixB = new List<List<int>>() { new List<int>() { 0, 0 }, new List<int>() { 0, 0 } };
        List<List<int>> expected = new List<List<int>>() { new List<int>() { 37, 46 }, new List<int>() { 15, 93 } };

        // Act
        List<List<int>> actual = Matrix.MatrixAddition(matrixA, matrixB);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
