using NUnit.Framework;
using System;

using System.Collections.Generic;

namespace TestApp.Tests;

public class DrumSetTests
{
    [Test]
    public void Test_Drum_TerminateCommandNotGiven_ThrowsArgumentException()
    {
        // Arrange
        decimal money = 50;
        List<int> quality = new List<int>() { 10, 15, 35 };
        List<string> command = new List<string>() { "5" };

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => DrumSet.Drum(money, quality, command));
    }

    [Test]
    public void Test_Drum_StringGivenAsCommand_ThrowsArgumentException()
    {
        // Arrange
        decimal money = 100;
        List<int> quality = new List<int>() { 65, 75, 90 };
        List<string> command = new List<string>() { "Error", "Hit it again, Gabsy!" };

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => DrumSet.Drum(money, quality, command));
    }

    [Test]
    public void Test_Drum_ReturnsCorrectQualityAndAmount()
    {
        // Arrange
        decimal money = 200;
        List<int> quality = new List<int>() { 15, 20, 25, 45 };
        List<string> command = new List<string>() { "35", "Hit it again, Gabsy!" };
        string expected = "15 20 25 10" + "\n" + "Gabsy has 20.00lv.";

        // Act
        string actual = DrumSet.Drum(money, quality, command);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Drum_BalanceZero_WithOneDrumLeftOver_ReturnsCorrectQualityAndAmount()
    {
        // Arrange
        decimal money = 0;
        List<int> quality = new List<int>() { 50, 70, 85, 60, 95 };
        List<string> command = new List<string>() { "55", "Hit it again, Gabsy!" };
        string expected = "15 30 5 40" + "\n" + "Gabsy has 0.00lv.";

        // Act
        string actual = DrumSet.Drum(money, quality, command);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Drum_NotEnoughBalance_RemovesAllDrums_ReturnsCorrectQualityAndAmount()
    {
        // Arrange
        decimal money = 30;
        List<int> quality = new List<int>() { 15, 20, 25 };
        List<string> command = new List<string>() { "30", "Hit it again, Gabsy!" };
        string expected = "\n" + "Gabsy has 30.00lv.";

        // Act
        string actual = DrumSet.Drum(money, quality, command);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
