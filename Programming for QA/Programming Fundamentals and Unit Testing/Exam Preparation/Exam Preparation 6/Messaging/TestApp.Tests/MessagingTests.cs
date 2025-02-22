using NUnit.Framework;

using System.Collections.Generic;

namespace TestApp.Tests;

public class MessagingTests
{
    [Test]
    public void Test_GetMessage_WithValidInput_ReturnsExpectedMessage()
    {
        // Arrange
        List<int> input = new List<int>() { 1, 2, 3, 4, 5 };
        string text = "message";
        string expected = "esgme";

        // Act
        string actual = Messaging.GetMessage(input, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetMessage_EmptyList_ReturnsEmptyString()
    {
        // Arrange
        List<int> input = new List<int>();
        string text = "message";
        string expected = "";

        // Act
        string actual = Messaging.GetMessage(input, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetMessage_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        List<int> input = new List<int>() { 1, 2, 3, 4, 5 };
        string text = "";
        string expected = "";

        // Act
        string actual = Messaging.GetMessage(input, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetMessage_NullList_ReturnsEmptyString()
    {
        // Arrange
        List<int> input = null;
        string text = "message";
        string expected = "";

        // Act
        string actual = Messaging.GetMessage(input, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetMessage_NullString_ReturnsEmptyString()
    {
        // Arrange
        List<int> input = new List<int>() { 1, 2, 3, 4, 5 };
        string text = null;
        string expected = "";

        // Act
        string actual = Messaging.GetMessage(input, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
