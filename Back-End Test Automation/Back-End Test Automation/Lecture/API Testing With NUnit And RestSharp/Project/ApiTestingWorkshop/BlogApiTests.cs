using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingWorkshop
{
    [TestFixture]
    public class BlogApiTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(GlobalConstants.baseUrl);
            token = GlobalConstants.GetAuthenticationToken("admin@gmail.com", "admin@gmail.com");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token is null or empty");
        }

        public void Dispose()
        {
            client.Dispose();
        }

        [Test, Order(1)]
        public void Test_GetAllBlogs()
        {
            // Arrange
            var request = new RestRequest("/blog", Method.Get);

            // Act
            var response = client.Execute(request);
            var blogs = JArray.Parse(response.Content);

            // Assert 
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(response.Content.Count, Is.GreaterThan(0), "Array contains no elements");
                Assert.That(blogs.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");

                foreach (var blog in blogs)
                {
                    Assert.That(blog["title"]?.ToString(), Is.Not.Null.Or.Empty, "Blog title is null or empty");
                    Assert.That(blog["description"]?.ToString(), Is.Not.Null.Or.Empty, "Blog description is null or empty");
                    Assert.That(blog["author"]?.ToString(), Is.Not.Null.Or.Empty, "Blog author is null or empty");
                    Assert.That(blog["category"]?.ToString(), Is.Not.Null.Or.Empty, "Blog category is null or empty");
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddBlog()
        {
            // Arrange
            var request = new RestRequest("/blog", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "Test Blog",
                description = "Test Description",
                category = "Test"
            });

            // Act
            var response = client.Execute(request);
            var blog = JObject.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(blog["title"]?.ToString(), Is.EqualTo("Test Blog"), "Blog title does not match the expected value");
                Assert.That(blog["description"]?.ToString(), Is.EqualTo("Test Description"), "Blog description does not match the expected value");
                Assert.That(blog["category"]?.ToString(), Is.EqualTo("Test"), "Blog category does not match the expected value");
                Assert.That(blog["author"]?.ToString(), Is.Not.Null.Or.Empty, "Blog category is null or empty");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateBlog()
        {
            // Arrange
            var getAllBlogsRequest = new RestRequest("/blog", Method.Get);

            // Act
            var getAllBlogsResponse = client.Execute(getAllBlogsRequest);
            var blogs = JArray.Parse(getAllBlogsResponse.Content);
            var blog = blogs.FirstOrDefault(b => b["title"]?.ToString() == "Test Blog");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllBlogsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllBlogsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var updateRequest = new RestRequest("/blog/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", blog["_id"]?.ToString());
            updateRequest.AddJsonBody(new
            {
                title = "Demo Blog",
                description = "Demo Description",
                category = "Demo"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);
            var updatedBlog = JObject.Parse(updateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedBlog["title"]?.ToString(), Is.EqualTo("Demo Blog"), "Blog title does not match the expected value");
                Assert.That(updatedBlog["description"]?.ToString(), Is.EqualTo("Demo Description"), "Blog description does not match the expected value");
                Assert.That(updatedBlog["category"]?.ToString(), Is.EqualTo("Demo"), "Blog category does not match the expected value");
                Assert.That(updatedBlog["author"]?.ToString(), Is.Not.Null.Or.Empty, "Blog category is null or empty");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteBlog()
        {
            // Arrange
            var getAllBlogsRequest = new RestRequest("/blog", Method.Get);

            // Act
            var getAllBlogsResponse = client.Execute(getAllBlogsRequest);
            var blogs = JArray.Parse(getAllBlogsResponse.Content);
            var blog = blogs.FirstOrDefault(b => b["title"]?.ToString() == "Demo Blog");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllBlogsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllBlogsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var deleteRequest = new RestRequest("/blog/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", blog["_id"]?.ToString());

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/blog/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", blog["_id"]?.ToString());

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterDeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(verifyAfterDeleteResponse.Content.ToString(), Is.Null.Or.EqualTo("null"), "Response content does not match the expected value");
            });
        }

    }
}
