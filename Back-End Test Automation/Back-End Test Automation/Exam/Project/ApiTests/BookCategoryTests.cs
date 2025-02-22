using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class BookCategoryTests : IDisposable
    {
        private RestClient client;
        private string token;

        [SetUp]
        public void Setup()
        {
            client = new RestClient(GlobalConstants.BaseUrl);
            token = GlobalConstants.AuthenticateUser("john.doe@example.com", "password123");

            Assert.That(token, Is.Not.Null.Or.Empty, "Authentication token should not be null or empty");
        }

        [Test]
        public void Test_BookCategoryLifecycle()
        {
            // Step 1: Create a new book category

            // Arrange
            var createRequest = new RestRequest("/category", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new
            {
                title = "Fictional Literature"
            });

            // Act
            var createResponse = client.Execute(createRequest);
            var createdCategory = JObject.Parse(createResponse.Content);
            var categoryID = createdCategory["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(createResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(createdCategory["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Category ID is null or empty");
                Assert.That(createdCategory["title"]?.ToString(), Is.EqualTo("Fictional Literature"), "Category title does not match the expected value");
            });

            // Step 2: Retrieve all book categories and verify the newly created category is present

            // Arrange
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            // Act
            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            var category = categories.FirstOrDefault(c => c["title"]?.ToString() == "Fictional Literature");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllCategoriesResponse.Content.ToString(), Does.Contain("Fictional Literature"), "Response content does not contain the expected value");
                Assert.That(categories.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");
                Assert.That(categories.Count, Is.GreaterThan(0), "Array contains no elements");
                Assert.That(category["_id"]?.ToString(), Is.EqualTo(categoryID), "Category ID does not match the expected value");

            });

            // Step 3: Update the category title

            // Arrange
            var updateRequest = new RestRequest("/category/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", categoryID);
            updateRequest.AddJsonBody(new
            {
                title = "Updated Fictional Literature"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Step 4: Verify that the category details have been updated

            // Arrange
            var verifyAfterUpdateRequest = new RestRequest("/category/{id}", Method.Get);
            verifyAfterUpdateRequest.AddUrlSegment("id", categoryID);

            // Act
            var verifyAfterUpdateResponse = client.Execute(verifyAfterUpdateRequest);
            var updatedCategory = JObject.Parse(verifyAfterUpdateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterUpdateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterUpdateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedCategory["title"]?.ToString(), Is.EqualTo("Updated Fictional Literature"), "Category title does not match the expected value");
            });

            // Step 5: Delete the category and validate it's no longer accessible

            // Arrange
            var deleteRequest = new RestRequest("/category/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", categoryID);

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Step 6: Verify that the deleted category cannot be found

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/category/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", categoryID);

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterDeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Null.Or.EqualTo("null"), "Response content does not match the expected value");
            });
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
