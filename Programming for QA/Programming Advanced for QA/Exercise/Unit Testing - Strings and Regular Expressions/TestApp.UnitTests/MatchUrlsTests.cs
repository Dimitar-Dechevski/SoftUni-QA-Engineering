using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class MatchUrlsTests
{
    [Test]
    public void Test_ExtractUrls_EmptyText_ReturnsEmptyList()
    {
        // Arrange
        string input = "";
        List<string> expected = new List<string>();

        // Act
        List<string> actual = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractUrls_NoUrlsInText_ReturnsEmptyList()
    {
        // Arrange
        string input = "https://www.Croatia., //www.Italy.com, https:www..com";
        List<string> expected = new List<string>();

        // Act
        List<string> actual = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractUrls_SingleUrlInText_ReturnsSingleUrl()
    {
        // Arrange
        string input = "https://www.Bulgaria#78.com";
        List<string> expected = new List<string>() { "https://www.Bulgaria#78.com" };

        // Act
        List<string> actual = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractUrls_MultipleUrlsInText_ReturnsAllUrls()
    {
        // Arrange
        string input = "https://www.Serbia#88.com, https://www.France#33.com, https://www.Japan#72.com";
        List<string> expected = new List<string>() { "https://www.Serbia#88.com", "https://www.France#33.com", "https://www.Japan#72.com" };

        // Act
        List<string> actual = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ExtractUrls_UrlsInQuotationMarks_ReturnsUrlsInQuotationMarks()
    {
        // Arrange
        string input = "https://Albania#18.com, https://www.CanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanadaCanada#93.com";
        List<string> expected = new List<string>() { "https://Albania#18.com" };

        // Act
        List<string> actual = MatchUrls.ExtractUrls(input);

        // Assert
        CollectionAssert.AreEqual(expected, actual);
    }
}
