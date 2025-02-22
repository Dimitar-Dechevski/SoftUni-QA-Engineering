using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article article;

    [SetUp]
    public void SetUp()
    {
        article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] input = new string[] { "VW Golf Bild", "Champions Wimbledon Times", "Invincibles Arsenal Guardian" };
        Article expected = new Article();
        for (int i = 0; i < input.Length; i++)
        {
            string[] tokens = input[i].Split(" ");
            Article currentArticle = new Article();
            currentArticle.Title = tokens[0];
            currentArticle.Content = tokens[1];
            currentArticle.Author = tokens[2];
            expected.ArticleList.Add(currentArticle);
        }

        // Act
        Article actual = article.AddArticles(input);

        // Assert
        Assert.AreEqual(expected.ArticleList.Count, actual.ArticleList.Count);

        for (int i = 0; i < actual.ArticleList.Count; i++)
        {
            Assert.AreEqual(expected.ArticleList[i].Title, actual.ArticleList[i].Title);
            Assert.AreEqual(expected.ArticleList[i].Content, actual.ArticleList[i].Content);
            Assert.AreEqual(expected.ArticleList[i].Author, actual.ArticleList[i].Author);
        }

    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] input = new string[] { "VW Golf Bild", "Champions Wimbledon Times", "Invincibles Arsenal Guardian" };
        string criteria = "title";
        Article currentArticle = article.AddArticles(input);
        string expected = $"Champions - Wimbledon: Times{Environment.NewLine}" +
                          $"Invincibles - Arsenal: Guardian{Environment.NewLine}" +
                          $"VW - Golf: Bild";

        // Act
        string actual = article.GetArticleList(currentArticle, criteria);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] input = new string[] { "VW Golf Bild", "Champions Wimbledon Times", "Invincibles Arsenal Guardian" };
        string criteria = "test";
        Article currentArticle = article.AddArticles(input);
        string expected = "";

        // Act
        string actual = article.GetArticleList(currentArticle, criteria);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
