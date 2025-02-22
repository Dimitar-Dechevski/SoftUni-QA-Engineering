using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using TestApp.Product;

namespace TestApp.Tests;

[TestFixture]
public class ProductInventoryTests
{
    private ProductInventory inventory = null!;

    [SetUp]
    public void SetUp()
    {
        inventory = new ProductInventory();
    }

    [Test]
    public void Test_AddProduct_ProductAddedToInventory()
    {
        // Arrange
        string productName = "Water";
        double productPrice = 2.88;
        int productQuantity = 6;
        string expected = $"Product Inventory:{Environment.NewLine}" +
                          $"Water - Price: $2.88 - Quantity: 6";

        // Act
        inventory.AddProduct(productName, productPrice, productQuantity);
        string actual = inventory.DisplayInventory();

        //Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayInventory_NoProducts_ReturnsEmptyString()
    {
        // Arrange
        string expected = "Product Inventory:";

        // Act
        string actual = inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayInventory_WithProducts_ReturnsFormattedInventory()
    {
        // Arrange
        inventory.AddProduct("Apple", 3.85, 5);
        inventory.AddProduct("Tomato", 2.44, 8);
        inventory.AddProduct("Bread", 1.38, 3);
        string expected = $"Product Inventory:{Environment.NewLine}" +
                          $"Apple - Price: $3.85 - Quantity: 5{Environment.NewLine}" +
                          $"Tomato - Price: $2.44 - Quantity: 8{Environment.NewLine}" +
                          $"Bread - Price: $1.38 - Quantity: 3";

        // Act
        string actual = inventory.DisplayInventory();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateTotalValue_NoProducts_ReturnsZero()
    {
        // Arrange
        double expected = 0;

        // Act
        double actual = inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateTotalValue_WithProducts_ReturnsTotalValue()
    {
        // Arrange
        inventory.AddProduct("Apple", 3.85, 5);
        inventory.AddProduct("Tomato", 2.44, 8);
        inventory.AddProduct("Bread", 1.38, 3);
        double expected = 42.91;

        // Act
        double actual = inventory.CalculateTotalValue();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
