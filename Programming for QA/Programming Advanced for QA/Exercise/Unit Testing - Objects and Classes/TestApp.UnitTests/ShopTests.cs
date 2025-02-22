using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop shop;

    [SetUp]
    public void SetUp()
    {
        shop = new Shop();
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        string[] products = new string[] { "924203 Apple 50 250", "431281 Samsung 88 200", "871949 Nokia 196 33.50" };
        string expected = $"431281{Environment.NewLine}-- Samsung - $200.00: 88{Environment.NewLine}-- $17600.00{Environment.NewLine}" +
                          $"924203{Environment.NewLine}-- Apple - $250.00: 50{Environment.NewLine}-- $12500.00{Environment.NewLine}" +
                          $"871949{Environment.NewLine}-- Nokia - $33.50: 196{Environment.NewLine}-- $6566.00";

        // Act
        string actual = shop.AddAndGetBoxes(products);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        // Arrange
        string[] products = Array.Empty<string>();
        string expected = "";

        // Act
        string actual = shop.AddAndGetBoxes(products);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
