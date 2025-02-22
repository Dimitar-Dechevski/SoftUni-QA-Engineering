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
    public class ColorApiTests : IDisposable
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
        public void Test_GetAllColors()
        {
            // Arrange
            var request = new RestRequest("/color", Method.Get);

            // Act
            var response = client.Execute(request);
            var colors = JArray.Parse(response.Content);
            var specificColors = new string[]
            {
                "Black",
                "White",
                "Red"
            };

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(colors.Count, Is.EqualTo(10), "Array contains elements less than ten");
                Assert.That(colors.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");

                foreach (var specificColor in specificColors)
                {
                    Assert.That(colors.ToString(), Does.Contain(specificColor), "Response content does not contain the expected value");
                }

                foreach (var color in colors)
                {
                    Assert.That(color["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Color ID is null or empty");
                    Assert.That(color["title"]?.ToString(), Is.Not.Null.Or.Empty, "Color title is null or empty");
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddColor()
        {
            // Arrange
            var request = new RestRequest("/color", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "Test Color"
            });

            // Act
            var response = client.Execute(request);
            var color = JObject.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(color["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Color ID is null or empty");
                Assert.That(color["title"]?.ToString(), Is.EqualTo("Test Color"), "Color title does not match the expected value");
                Assert.That(color.ContainsKey("createdAt"), Is.True, "Color does not contain the expected field");
                Assert.That(color.ContainsKey("updatedAt"), Is.True, "Color does not contain the expected field");
                Assert.That(DateTime.TryParse(color["createdAt"]?.ToString(), out _), Is.True, "Color createdAt type is not datetime");
                Assert.That(DateTime.TryParse(color["updatedAt"]?.ToString(), out _), Is.True, "Color updatedAt type is not datetime");
                Assert.That(color["createdAt"]?.ToString(), Is.EqualTo(color["updatedAt"]?.ToString()), "Brand createdAt value is not same as brand updatedAt value");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateColor()
        {
            // Arrange
            var getAllColorsRequest = new RestRequest("/color", Method.Get);

            // Act
            var getAllColorsResponse = client.Execute(getAllColorsRequest);
            var colors = JArray.Parse(getAllColorsResponse.Content);
            var color = colors.FirstOrDefault(c => c["title"]?.ToString() == "Test Color");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllColorsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllColorsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var updateRequest = new RestRequest("/color/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", color["_id"]?.ToString());
            updateRequest.AddJsonBody(new
            {
                title = "Demo Color"
            });

            // Act
            GlobalConstants.UserWait();
            var updateResponse = client.Execute(updateRequest);
            var updatedColor = JObject.Parse(updateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedColor["_id"]?.ToString(), Is.EqualTo(color["_id"]?.ToString()), "Color ID does not match the expected value");
                Assert.That(updatedColor["title"]?.ToString(), Is.EqualTo("Demo Color"), "Color title does not match the expected value");
                Assert.That(updatedColor.ContainsKey("createdAt"), Is.True, "Color does not contain the expected field");
                Assert.That(updatedColor.ContainsKey("updatedAt"), Is.True, "Color does not contain the expected field");
                Assert.That(DateTime.TryParse(updatedColor["createdAt"]?.ToString(), out _), Is.True, "Color createdAt type is not datetime");
                Assert.That(DateTime.TryParse(updatedColor["updatedAt"]?.ToString(), out _), Is.True, "Color updatedAt type is not datetime");
                Assert.That(updatedColor["updatedAt"]?.ToString(), Is.Not.EqualTo(updatedColor["createdAt"]?.ToString()), "Brand updatedAt value is same as brand createdAt value");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteColor()
        {
            // Arrange
            var getAllColorsRequest = new RestRequest("/color", Method.Get);

            // Act
            var getAllColorsResponse = client.Execute(getAllColorsRequest);
            var colors = JArray.Parse(getAllColorsResponse.Content);
            var color = colors.FirstOrDefault(c => c["title"]?.ToString() == "Demo Color");

            // Arrange
            Assert.Multiple(() =>
            {
                Assert.That(getAllColorsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllColorsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var deleteRequest = new RestRequest("/color/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", color["_id"]?.ToString());

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/color/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", color["_id"]?.ToString());

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterDeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(verifyAfterDeleteResponse.Content.ToString(), Is.EqualTo("null"), "Response content does not match the expected value");
            });

        }
    }
}
