using System;

using NUnit.Framework;

using TestApp.Chat;

namespace TestApp.Tests;

[TestFixture]
public class ChatRoomTests
{
    private ChatRoom chatRoom = null!;

    [SetUp]
    public void Setup()
    {
        chatRoom = new ChatRoom();
    }

    [Test]
    public void Test_SendMessage_MessageSentToChatRoom()
    {
        // Arrange
        string sender = "Admin";
        string message = "Test";
        string expected = $"Chat Room Messages:{Environment.NewLine}" +
                          $"Admin: Test - Sent at {DateTime.Now.Date.ToString("d")}";

        // Act
        chatRoom.SendMessage(sender, message);
        string actual = chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayChat_NoMessages_ReturnsEmptyString()
    {
        // Arrange
        string expected = "";

        // Act
        string actual = chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayChat_WithMessages_ReturnsFormattedChat()
    {
        // Arrange
        string firstSender = "Admin";
        string firstMessage = "Test";
        string secondSender = "Admin";
        string secondMessage = "Test passed";
        string expected = $"Chat Room Messages:{Environment.NewLine}" +
                          $"Admin: Test - Sent at {DateTime.Now.Date.ToString("d")}{Environment.NewLine}" +
                          $"Admin: Test passed - Sent at {DateTime.Now.Date.ToString("d")}";

        // Act
        chatRoom.SendMessage(firstSender, firstMessage);
        chatRoom.SendMessage(secondSender, secondMessage);
        string actual = chatRoom.DisplayChat();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
