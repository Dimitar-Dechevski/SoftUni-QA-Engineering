using NUnit.Framework;

namespace TestApp.UnitTests;

public class SubstringTests
{
    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromMiddle()
    {
        // Arrange
        string input = "In the middle of the forest lives a bear which is very aggressive.";
        string word = "bear";
        string expected = "In the middle of the forest lives a which is very aggressive.";

        // Act
        string actual = Substring.RemoveOccurrences(word, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromStart()
    {
        // Arrange
        string input = "Еagle was flying high above the mountains.";
        string word = "Еagle";
        string expected = "was flying high above the mountains.";

        // Act
        string actual = Substring.RemoveOccurrences(word, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesSubstringFromEnd()
    {
        // Arrange
        string input = "In the garage are parked one motorcycle and one car.";
        string word = "car";
        string expected = "In the garage are parked one motorcycle and one .";

        // Act
        string actual = Substring.RemoveOccurrences(word, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_RemoveOccurrences_RemovesAllOccurrences()
    {
        // Arrange
        string input = "Adidas is a German sportswear company. Puma and Nike are major competitors of Adidas.";
        string word = "Adidas";
        string expected = "is a German sportswear company. Puma and Nike are major competitors of .";

        // Act
        string actual = Substring.RemoveOccurrences(word, input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
