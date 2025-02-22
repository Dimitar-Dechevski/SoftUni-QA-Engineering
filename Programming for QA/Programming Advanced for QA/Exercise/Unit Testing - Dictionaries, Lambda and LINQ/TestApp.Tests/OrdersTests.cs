using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();
        string expected = "";

        // Act
        string actual = Orders.Order(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "water 2.50 75", "apple 5.75 25", "bread 0.45 200", "apple 3.75 125" };
        string expected = $"water -> 187.50{Environment.NewLine}" +
            $"apple -> 562.50{Environment.NewLine}" +
            $"bread -> 90.00";

        // Act
        string actual = Orders.Order(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "orange 5 88", "milk 3 93", "meat 9 350" };
        string expected = $"orange -> 440.00{Environment.NewLine}" +
            $"milk -> 279.00{Environment.NewLine}" +
            $"meat -> 3150.00";

        // Act
        string actual = Orders.Order(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "flour 1.44 123.5", "tomato 3.74 46.8", "onion 0.66 88.3" };
        string expected = $"flour -> 177.84{Environment.NewLine}" +
            $"tomato -> 175.03{Environment.NewLine}" +
            $"onion -> 58.28";

        // Act
        string actual = Orders.Order(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
