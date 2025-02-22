using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class DestinationTests : IDisposable
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
        public void Test_GetAllDestinations()
        {
            // Arrange
            var request = new RestRequest("/destination", Method.Get);

            // Act
            var response = client.Execute(request);
            var destinations = JArray.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(destinations.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");
                Assert.That(destinations.Count, Is.GreaterThan(0), "Array contains no elements");

                foreach (var destination in destinations)
                {
                    Assert.That(destination["name"]?.ToString(), Is.Not.Null.Or.Empty, "Destination name is null or empty");
                    Assert.That(destination["location"]?.ToString(), Is.Not.Null.Or.Empty, "Destination location is null or empty");
                    Assert.That(destination["description"]?.ToString(), Is.Not.Null.Or.Empty, "Destination description is null or empty");
                    Assert.That(destination["category"]?.ToString(), Is.Not.Null.Or.Empty, "Destination category is null or empty");
                    Assert.That(destination["attractions"]?.Type, Is.EqualTo(JTokenType.Array), "Destination attractions is not array");
                    Assert.That(destination["bestTimeToVisit"]?.ToString(), Is.Not.Null.Or.Empty, "Destination bestTimeToVisit is null or empty");
                }
            });
        }

        [Test]
        public void Test_GetDestinationByName()
        {
            // Arrange
            var request = new RestRequest("/destination", Method.Get);

            // Act
            var response = client.Execute(request);
            var destinations = JArray.Parse(response.Content);
            var destination = destinations.FirstOrDefault(d => d["name"]?.ToString() == ("New York City"));

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(response.Content.ToString(), Does.Contain("New York City"), "Response content does not contain the expected value");
                Assert.That(destination["location"]?.ToString(), Is.EqualTo("New York, USA"), "Destination location does not match the expected value.");
                Assert.That(destination["description"]?.ToString(), Is.EqualTo("The largest city in the USA, known for its skyscrapers, culture, and entertainment."), "Destination description does not match the expected value");
            });
        }

        [Test]
        public void Test_AddDestination()
        {
            // Arrange
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            // Act
            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            var category = categories.FirstOrDefault(c => c["name"]?.ToString() == "Mountains");
            var categoryID = category["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var createRequest = new RestRequest("/destination", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new
            {
                name = "Test",
                location = "Test",
                description = "Test",
                attractions = new[]
                {
                    "Test1",
                    "Test2",
                    "Test3"
                },
                bestTimeToVisit = "Test",
                category = categoryID
            });

            // Act
            var createResponse = client.Execute(createRequest);
            var createdDestination = JObject.Parse(createResponse.Content);
            var destinationID = createdDestination["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(createResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterCreateRequest = new RestRequest("/destination/{id}", Method.Get);
            verifyAfterCreateRequest.AddUrlSegment("id", destinationID);

            // Act
            var verifyAfterCreateResponse = client.Execute(verifyAfterCreateRequest);
            var destination = JObject.Parse(verifyAfterCreateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterCreateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterCreateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(destination["name"]?.ToString(), Is.EqualTo("Test"), "Destination name does not match the expected value");
                Assert.That(destination["location"]?.ToString(), Is.EqualTo("Test"), "Destination location does not match the expected value");
                Assert.That(destination["description"]?.ToString(), Is.EqualTo("Test"), "Destination description does not match the expected value");
                Assert.That(destination["bestTimeToVisit"]?.ToString(), Is.EqualTo("Test"), "Destination bestTimeToVisit does not match the expected value");
                Assert.That(destination["category"], Is.Not.Null.Or.Empty, "Destination category is null or empty");
                Assert.That(destination["category"]["_id"]?.ToString(), Is.EqualTo(categoryID), "Category ID does not match the expected value");
                Assert.That(destination["attractions"].Type, Is.EqualTo(JTokenType.Array), "Destination attractions is not array");
                Assert.That(destination["attractions"].Count, Is.EqualTo(3), "Numbers of attractions does not match the expected value");
                Assert.That(destination["attractions"][0]?.ToString(), Is.EqualTo("Test1"), "First attraction does not match the expected value");
                Assert.That(destination["attractions"][1]?.ToString(), Is.EqualTo("Test2"), "Second attraction does not match the expected value");
                Assert.That(destination["attractions"][2]?.ToString(), Is.EqualTo("Test3"), "Third attraction does not match the expected value");
            });
        }

        [Test]
        public void Test_UpdateDestination()
        {
            // Arrange
            var getAllDestinationsRequest = new RestRequest("/destination", Method.Get);

            // Act
            var getAllDestinationsResponse = client.Execute(getAllDestinationsRequest);
            var destinations = JArray.Parse(getAllDestinationsResponse.Content);
            var destination = destinations.FirstOrDefault(d => d["name"]?.ToString() == "Machu Picchu");
            var destinationID = destination["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllDestinationsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllDestinationsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllDestinationsResponse.Content.ToString(), Does.Contain("Machu Picchu"), "Response content does not contain the expected value");
            });

            // Arrange
            var updateRequest = new RestRequest("/destination/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", destinationID);
            updateRequest.AddJsonBody(new
            {
                name = "Demo",
                bestTimeToVisit = "Demo"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);
            var updatedDestination = JObject.Parse(updateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedDestination["name"]?.ToString(), Is.EqualTo("Demo"), "Destination name does not match the expected value");
                Assert.That(updatedDestination["bestTimeToVisit"]?.ToString(), Is.EqualTo("Demo"), "Destination bestTimeToVisit does not match the expected value");
            });

        }

        [Test]
        public void Test_DeleteDestination()
        {
            // Arrange
            var getAllDestinationsRequest = new RestRequest("/destination", Method.Get);

            // Act
            var getAllDestinationsResponse = client.Execute(getAllDestinationsRequest);
            var destinations = JArray.Parse(getAllDestinationsResponse.Content);
            var destination = destinations.FirstOrDefault(d => d["name"]?.ToString() == "Yellowstone National Park");
            var destinationID = destination["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllDestinationsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllDestinationsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllDestinationsResponse.Content.ToString(), Does.Contain("Yellowstone National Park"), "Response content does not contain the expected value");
            });

            // Arrange
            var deleteRequest = new RestRequest("/destination/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", destinationID);

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/destination/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", destinationID);

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
