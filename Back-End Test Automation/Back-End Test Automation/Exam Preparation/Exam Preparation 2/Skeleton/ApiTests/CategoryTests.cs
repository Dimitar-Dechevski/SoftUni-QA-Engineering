using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class CategoryTests : IDisposable
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
        public void Test_CategoryLifecycle_RecipeBook()
        {
            // Step 1: Create a new category

            // Arrange
            var createRequest = new RestRequest("/category", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new
            {
                name = "Vegan Recipes"
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
            });

            // Step 2: Get all categories and verify new category is included

            // Arrange
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            // Act
            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            var categories = JArray.Parse(getAllCategoriesResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllCategoriesResponse.Content.ToString(), Does.Contain("Vegan Recipes"), "Response content does not contain the expected value");
                Assert.That(categories.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");
                Assert.That(categories.Count, Is.GreaterThan(0), "Array contains no elements");

            });

            // Step 3: Get category by ID

            // Arrange
            var verifyAfterCreateRequest = new RestRequest("/category/{id}", Method.Get);
            verifyAfterCreateRequest.AddUrlSegment("id", categoryID);

            // Act
            var verifyAfterCreateResponse = client.Execute(verifyAfterCreateRequest);
            var category = JObject.Parse(verifyAfterCreateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterCreateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterCreateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(category["_id"]?.ToString(), Is.EqualTo(categoryID), "Category ID does not match the expected value");
                Assert.That(category["name"]?.ToString(), Is.EqualTo("Vegan Recipes"), "Category name does not match the expected value");
            });

            // Step 4: Edit the category and verify update

            // Arrange
            var updateRequest = new RestRequest("/category/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", categoryID);
            updateRequest.AddJsonBody(new
            {
                name = "Healthy Vegan Recipes"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Step 5: Attempt to update category with invalid data (negative test)

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
                Assert.That(updatedCategory["name"]?.ToString(), Is.EqualTo("Healthy Vegan Recipes"), "Category name does not match the expected value");
            });

            // Step 6: Delete the category

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

            // Step 7: Verify category is deleted

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
                Assert.That(verifyAfterDeleteResponse.Content.ToString(), Is.Null.Or.EqualTo("null"), "Response content does not match the expected value");
            });
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
