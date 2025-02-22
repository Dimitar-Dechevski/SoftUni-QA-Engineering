using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class FruitsTests
{
    [Test]
    public void Test_GetFruitQuantity_FruitExists_ReturnsQuantity()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            ["banana"] = 8,
            ["apple"] = 15,
            ["kiwi"] = 12,
            ["orange"] = 3
        };
        string fruit = "kiwi";
        int expected = 12;

        // Act
        int actual = Fruits.GetFruitQuantity(dict, fruit);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_FruitDoesNotExist_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            ["banana"] = 8,
            ["apple"] = 15,
            ["kiwi"] = 12,
            ["orange"] = 3
        };
        string fruit = "pear";
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(dict, fruit);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_EmptyDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>();
        string fruit = "pear";
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(dict, fruit);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_NullDictionary_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> dict = null;
        string fruit = "pear";
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(dict, fruit);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetFruitQuantity_NullFruitName_ReturnsZero()
    {
        // Arrange
        Dictionary<string, int> dict = new Dictionary<string, int>
        {
            ["banana"] = 8,
            ["apple"] = 15,
            ["kiwi"] = 12,
            ["orange"] = 3
        };
        string fruit = null;
        int expected = 0;

        // Act
        int actual = Fruits.GetFruitQuantity(dict, fruit);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
