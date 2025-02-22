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
    public class ColorManagementTests
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
        public void ColorLifecycleTest()
        {
            // Create a color

            // Arrange
            var createColorRequest = new RestRequest("/color", Method.Post);
            createColorRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createColorRequest.AddJsonBody(new
            {
                title = $"Test_{random.Next(999, 9999)}"
            });

            // Act
            var createColorResponse = client.Execute(createColorRequest);
            var color = JObject.Parse(createColorResponse.Content);
            var colorId = color["_id"]?.ToString();

            // Assert
            Assert.That(createColorResponse.IsSuccessful, Is.True, "Creating a color is failed");
            Assert.That(colorId, Is.Not.Null.Or.Empty, "Color ID is null or empty");

            // Retrieve a color by ID

            // Arrange
            var getColorByIdRequest = new RestRequest("/color/{id}", Method.Get);
            getColorByIdRequest.AddUrlSegment("id", colorId);

            // Act
            var getColorByIdResponse = client.Execute(getColorByIdRequest);

            // Assert
            Assert.That(getColorByIdResponse.IsSuccessful, Is.True, "Retrieving a color by ID is failed");

            // Delete a color

            // Arrange
            var deleteColorRequest = new RestRequest("/color/{id}", Method.Delete);
            deleteColorRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            deleteColorRequest.AddUrlSegment("id", colorId);

            // Act
            var deleteColorResponse = client.Execute(deleteColorRequest);

            // Assert
            Assert.That(deleteColorResponse.IsSuccessful, Is.True, "Deleting a color is failed");

            // Verify that color is deleted

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/color/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", colorId);

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.That(verifyAfterDeleteResponse.Content, Is.Null.Or.EqualTo("null"), "Color still exist after deletion");
        }

        [Test]
        public void ColorLifecycleNegativeTest()
        {
            // Create a color with invalid token

            // Arrange
            var invalidToken = "Test";
            var createColorRequest = new RestRequest("/color", Method.Post);
            createColorRequest.AddHeader("Authorization", $"Bearer {invalidToken}");
            createColorRequest.AddJsonBody(new
            {
                title = $"Test_{random.Next(999, 9999)}"
            });

            // Act
            var createColorResponse = client.Execute(createColorRequest);
            var color = JObject.Parse(createColorResponse.Content);
            var colorId = color["_id"]?.ToString();

            // Assert
            Assert.That(createColorResponse.IsSuccessful, Is.False, "Creating a color should be failed when token is invalid");
            Assert.That(createColorResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError), "Response status code is not 500 InternalServerError");

            // Retrieve a color by ID with invalid color ID

            // Arrange
            var invalidColorId = "Test";
            var getColorByIdRequest = new RestRequest("/color/{id}", Method.Get);
            getColorByIdRequest.AddUrlSegment("id", invalidColorId);

            // Act
            var getColorByIdResponse = client.Execute(getColorByIdRequest);

            // Assert
            Assert.That(getColorByIdResponse.IsSuccessful, Is.False, "Retrieving a color by ID should be failed when color ID is invalid");
            Assert.That(getColorByIdResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError), "Response status code is not 500 InternalServerError");

            // Delete a color with invalid token and invalid color ID

            // Arrange
            var deleteColorRequest = new RestRequest("/color/{id}", Method.Delete);
            deleteColorRequest.AddHeader("Authorization", $"Bearer {invalidToken}");
            deleteColorRequest.AddUrlSegment("id", invalidColorId);

            // Act
            var deleteColorResponse = client.Execute(deleteColorRequest);

            // Assert
            Assert.That(deleteColorResponse.IsSuccessful, Is.False, "Deleting a color should be failed when token and color ID are invalid ");
            Assert.That(deleteColorResponse.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError), "Response status code is not 500 InternalServerError");
        }
    }
}
