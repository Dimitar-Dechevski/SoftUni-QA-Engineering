using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class StringModifierTests
{
    [Test]
    public void Test_Modify_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = StringModifier.Modify(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Modify_SingleWordWithEvenLength_ReturnsUppperCaseWord()
    {
        // Arrange
        string input = "bear";
        string expected = "BEAR";

        // Act
        string actual = StringModifier.Modify(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Modify_SingleWordWithOddLength_ReturnsToLowerCaseWord()
    {
        // Arrange
        string input = "DOG";
        string expected = "dog";

        // Act
        string actual = StringModifier.Modify(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Modify_MultipleWords_ReturnsModifiedString()
    {
        // Arrange
        string input = "Zebra deer EAGLE LioN";
        string expected = "zebra DEER eagle LION";

        // Act
        string actual = StringModifier.Modify(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}

