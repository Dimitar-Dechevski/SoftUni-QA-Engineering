using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class SongTests
{
    private Song song;

    [SetUp]
    public void Setup()
    {
        song = new Song();
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsAllSongs_WhenWantedListIsAll()
    {
        // Arrange
        string[] songs = { "Folk_Song1_3:15", "Pop_Song2_4:07", "Folk_Song3_3:46" };
        string playlist = "all";
        string expected = $"Song1{Environment.NewLine}Song2{Environment.NewLine}Song3";

        // Act
        string actual = song.AddAndListSongs(songs, playlist);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsFilteredSongs_WhenWantedListIsSpecific()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:08", "Folk_Song2_2:45", "Rock_Song3_4:25" };
        string playlist = "Folk";
        string expected = $"Song2";

        // Act
        string actual = song.AddAndListSongs(songs, playlist);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongsMatchWantedList()
    {
        // Arrange
        string[] songs = { "Pop_Song1_4:44", "Folk_Song2_3:33", "Folk_Song3_2:22" };
        string playlist = "Rock";
        string expected = "";

        // Act
        string actual = song.AddAndListSongs(songs, playlist);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
