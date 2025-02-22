using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class FakeTests
{
    [Test]
    public void Test_RemoveStringNumbers_RemovesDigitsFromCharArray()
    {
        // Arrange
        char[] input = new char[] { '9', '3', '#', '7', '5', 'm' };
        char[] expected = new char[] { '#', 'm' };

        //Act
        char[] actual = Fake.RemoveStringNumbers(input);

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveStringNumbers_NoDigitsInInput_ReturnsSameArray()
    {
        // Arrange
        char[] input = new char[] { 'd', 'q', '#', 'r', 'p', '@' };
        char[] expected = new char[] { 'd', 'q', '#', 'r', 'p', '@' };

        //Act
        char[] actual = Fake.RemoveStringNumbers(input);

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveStringNumbers_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        char[] input = Array.Empty<char>();
        char[] expected = Array.Empty<char>();

        //Act
        char[] actual = Fake.RemoveStringNumbers(input);

        //Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
