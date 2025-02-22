using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingWorkshop
{
    [TestFixture]
    public class BlogManagementTests
    {
        private RestClient client;
        private string adminToken;
        private string userToken;
        private Random random;

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(GlobalConstants.baseUrl);
            random = new Random();
            adminToken = GlobalConstants.GetAuthenticationToken("admin@gmail.com", "admin@gmail.com");
            userToken = GlobalConstants.GetAuthenticationToken("johndoe@example.com", "password123");

            Assert.That(adminToken, Is.Not.Null.Or.Empty, "Admin authentication token is null or empty");
            Assert.That(userToken, Is.Not.Null.Or.Empty, "User Authentication token is null or empty");
        }

        [TearDown]
        public void Dispose()
        {
            client.Dispose();
        }

        [Test]
        public void BlogPostLifecycleTest()
        {
            // Create a blog

            // Arrange
            var createBlogRequest = new RestRequest("/blog", Method.Post);
            createBlogRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createBlogRequest.AddJsonBody(new
            {
                title = $"Test_{random.Next(999, 9999)}",
                description = "Test",
                category = "Test"
            });

            // Act
            var createBlogResponse = client.Execute(createBlogRequest);
            var blog = JObject.Parse(createBlogResponse.Content);
            var blogId = blog["_id"]?.ToString();
            var blogTitle = blog["title"]?.ToString();

            // Assert
            Assert.That(createBlogResponse.IsSuccessful, Is.True, "Creating a blog is failed");
            Assert.That(blogId, Is.Not.Null.Or.Empty, "Blog ID is null or empty");

            // Update a blog 

            // Arrange
            var updateBlogRequest = new RestRequest("/blog/{id}", Method.Put);
            updateBlogRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            updateBlogRequest.AddUrlSegment("id", blogId);
            updateBlogRequest.AddJsonBody(new
            {
                title = $"Updated_{blogTitle}",
                description = "Updated Test"
            });

            // Act
            var updateBlogResponse = client.Execute(updateBlogRequest);

            // Assert
            Assert.That(updateBlogResponse.IsSuccessful, Is.True, "Updating a blog is failed");

            // Delete a blog 

            // Arrange
            var deleteBlogRequest = new RestRequest("/blog/{id}", Method.Delete);
            deleteBlogRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            deleteBlogRequest.AddUrlSegment("id", blogId);

            // Act
            var deleteBlogResponse = client.Execute(deleteBlogRequest);

            // Assert
            Assert.That(deleteBlogResponse.IsSuccessful, Is.True, "Deleting a blog is failed");

            // Verify that blog is deleted

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/blog/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", blogId);

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.That(verifyAfterDeleteResponse.Content, Is.Null.Or.EqualTo("null"), "Blog still exist after deletion");
        }
    }
}
