using NUnit.Framework;
using System;

namespace TestApp.UnitTests;

public class MatchDatesTests
{
    [Test]
    public void Test_Match_ValidDate_ReturnsExpectedResult()
    {
        // Arrange
        string input = "15-Jan-1746, 18/Sep/2008, 27.May.1876";
        string expected = "Day: 15, Month: Jan, Year: 1746";

        // Act
        string actual = MatchDates.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_NoMatch_ReturnsEmptyString()
    {
        // Arrange
        string input = "12-Mar.1453, 03-Dec/1845, 23.Jun/1948";
        string expected = "";

        // Act
        string actual = MatchDates.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_MultipleMatches_ReturnsFirstMatch()
    {
        // Arrange
        string input = "08-Oct-1763, 25/Apr/1888, 11.Jul.1975";
        string expected = "Day: 08, Month: Oct, Year: 1763";

        // Act
        string actual = MatchDates.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        string expected = "";

        // Act
        string actual = MatchDates.Match(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Match_NullInput_ThrowsArgumentException()
    {
        // Arrange
        string input = null;

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => MatchDates.Match(input));
    }
}
