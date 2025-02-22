using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class SubstringExtractorTests
{
    [Test]
    public void Test_ExtractSubstringBetweenMarkers_SubstringFound_ReturnsExtractedSubstring()
    {
        // Arrange
        string input = "abcdef";
        string start = "b";
        string end = "e";
        string expected = "cd";

        // Act
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, start, end);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartMarkerNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "abcdef";
        string start = "z";
        string end = "e";
        string expected = "Substring not found";

        // Act
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, start, end);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EndMarkerNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "abcdef";
        string start = "b";
        string end = "w";
        string expected = "Substring not found";

        // Act
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, start, end);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersNotFound_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "abcdef";
        string start = "s";
        string end = "t";
        string expected = "Substring not found";

        // Act
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, start, end);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_EmptyInput_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "";
        string start = "b";
        string end = "e";
        string expected = "Substring not found";

        // Act
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, start, end);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractSubstringBetweenMarkers_StartAndEndMarkersOverlapping_ReturnsNotFoundMessage()
    {
        // Arrange
        string input = "abcdef";
        string start = "b";
        string end = "b";
        string expected = "Substring not found";

        // Act
        string actual = SubstringExtractor.ExtractSubstringBetweenMarkers(input, start, end);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
