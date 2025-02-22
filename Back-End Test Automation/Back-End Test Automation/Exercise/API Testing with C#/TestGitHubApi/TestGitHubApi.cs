using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;
using NUnit.Framework;
using System.Runtime.CompilerServices;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        long lastCreatedIssueNumber;
        long lastCreatedCommentId;
        string repo = "test-nakov-repo";

        [SetUp]
        public void Setup()
        {
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "Dimitar-Dechevski", "//token");
        }


        [Test, Order(1)]
        public void Test_GetAllIssuesFromARepo()
        {
            // Arrange

            // Act
            var issues = client.GetAllIssues(repo);

            // Assert
            Assert.That(issues.Count, Is.GreaterThan(0));

            foreach (var issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0));
                Assert.That(issue.Number, Is.GreaterThan(0));
                Assert.That(issue.Title, Is.Not.Empty);
                Assert.That(issue.Body, Is.Not.Empty);
            }
        }

        [Test, Order(2)]
        public void Test_GetIssueByValidNumber()
        {
            // Arrange
            long issueNumber = 8;

            // Act
            var issue = client.GetIssueByNumber(repo, issueNumber);

            // Assert
            Assert.That(issue, Is.Not.Null);
            Assert.That(issue.Id, Is.GreaterThan(0));
            Assert.That(issue.Number, Is.EqualTo(issueNumber));
            Assert.That(issue.Title, Is.Not.Empty);
            Assert.That(issue.Body, Is.Not.Empty);
        }

        [Test, Order(3)]
        public void Test_GetAllLabelsForIssue()
        {
            // Arrange
            long issueNumber = 8;

            // Act
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            // Assert
            Assert.That(labels.Count, Is.GreaterThan(0));

            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0));
                Assert.That(label.Name, Is.Not.Empty);
                Console.WriteLine($"Label: {label.Id} - Name: {label.Name}");
            }
        }

        [Test, Order(4)]
        public void Test_GetAllCommentsForIssue()
        {
            // Arrange
            long issueNumber = 8;

            // Act
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            // Assert
            Assert.That(comments.Count, Is.GreaterThan(0));

            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0));
                Assert.That(comment.Body, Is.Not.Empty);
                Console.WriteLine($"Comment: {comment.Id} - Body: {comment.Body}");
            }
        }

        [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            // Arrange
            string title = "Title";
            string body = "Body";

            // Act
            var issue = client.CreateIssue(repo, title, body);

            // Assert
            Assert.That(issue.Id, Is.GreaterThan(0));
            Assert.That(issue.Number, Is.GreaterThan(0));
            Assert.That(issue.Title, Is.Not.Empty);
            Assert.That(issue.Title, Is.EqualTo(title));
            Assert.That(issue.Body, Is.Not.Empty);
            Assert.That(issue.Body, Is.EqualTo(body));
            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;
        }

        [Test, Order(6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            // Arrange
            long issueNumber = lastCreatedIssueNumber;
            string body = "Comment";

            // Act
            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);

            // Assert
            Assert.That(comment.Id, Is.GreaterThan(0));
            Assert.That(comment.Body, Is.Not.Empty);
            Assert.That(comment.Body, Is.EqualTo(body));
            Console.WriteLine(comment.Id);
            lastCreatedCommentId = comment.Id;
        }

        [Test, Order(7)]
        public void Test_GetCommentById()
        {
            // Arrange
            long commentId = lastCreatedCommentId;

            // Act
            var comment = client.GetCommentById(repo, commentId);

            // Assert
            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId));
            Assert.That(comment.Body, Is.Not.Empty);
        }


        [Test, Order(8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            // Arrange
            long commentId = lastCreatedCommentId;
            string body = "New Comment";

            // Act
            var comment = client.EditCommentOnGitHubIssue(repo, commentId, body);

            // Assert
            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId));
            Assert.That(comment.Body, Is.Not.Empty);
            Assert.That(comment.Body, Is.EqualTo(body));
        }

        [Test, Order(9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            // Arrange
            long commentId = lastCreatedCommentId;

            // Act
            var result = client.DeleteCommentOnGitHubIssue(repo, commentId);

            // Assert
            Assert.That(result, Is.True);
        }


    }
}

