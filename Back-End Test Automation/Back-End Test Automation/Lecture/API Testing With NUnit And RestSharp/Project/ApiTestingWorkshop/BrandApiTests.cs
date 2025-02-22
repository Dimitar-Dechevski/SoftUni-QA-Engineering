using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingWorkshop
{
    [TestFixture]
    public class BrandApiTests : IDisposable
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
        public void Test_GetAllBrands()
        {
            // Arrange
            var request = new RestRequest("/brand", Method.Get);

            // Act
            var response = client.Execute(request);
            var brands = JArray.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(brands.Count, Is.GreaterThan(5), "Array contains elements less than five");

                var specificBrands = new string[]
                {
                    "TechCorp",
                    "GameMaster"
                };

                foreach (var specificBrand in specificBrands)
                {
                    Assert.That(brands.ToString(), Does.Contain(specificBrand), "Response content does not contain the expected value");
                }

                foreach (var brand in brands)
                {
                    Assert.That(brand["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Brand ID is null or empty");
                    Assert.That(brand["title"]?.ToString(), Is.Not.Null.Or.Empty, "Brand title is null or empty");
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddBrand()
        {
            // Arrange
            var request = new RestRequest("brand", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "Test Brand"
            });

            // Act
            var response = client.Execute(request);
            var brand = JObject.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(brand["_id"]?.ToString(), Is.Not.Null.Or.Empty, "Brand ID is null or empty");
                Assert.That(brand["title"]?.ToString(), Is.EqualTo("Test Brand"), "Brand title does not match the expected value");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateBrand()
        {
            // Arrange
            var getAllBrandsRequest = new RestRequest("/brand", Method.Get);

            // Act
            var getAllBrandsResponse = client.Execute(getAllBrandsRequest);
            var brands = JArray.Parse(getAllBrandsResponse.Content);
            var brand = brands.FirstOrDefault(b => b["title"]?.ToString() == "Test Brand");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllBrandsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllBrandsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var updateRequest = new RestRequest("/brand/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", brand["_id"]?.ToString());
            updateRequest.AddJsonBody(new
            {
                title = "Demo Brand"
            });

            // Act
            GlobalConstants.UserWait();
            var updateResponse = client.Execute(updateRequest);
            var updatedBrand = JObject.Parse(updateResponse.Content);


            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedBrand["_id"]?.ToString(), Is.EqualTo(brand["_id"]?.ToString()), "Brand ID does not match the expected value");
                Assert.That(updatedBrand["title"]?.ToString(), Is.EqualTo("Demo Brand"), "Brand title does not match the expected value");
                Assert.That(updatedBrand.ContainsKey("createdAt"), Is.True, "Brand does not contain the expected field");
                Assert.That(updatedBrand.ContainsKey("updatedAt"), Is.True, "Brand does not contain the expected field");
                Assert.That(updatedBrand["updatedAt"]?.ToString(), Is.Not.EqualTo(updatedBrand["createdAt"]?.ToString()), "Brand updatedAt value is same as brand createdAt value");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteBrand()
        {
            // Arrange
            var getAllBrandsRequest = new RestRequest("/brand", Method.Get);

            // Act
            var getAllBrandsResponse = client.Execute(getAllBrandsRequest);
            var brands = JArray.Parse(getAllBrandsResponse.Content);
            var brand = brands.FirstOrDefault(b => b["title"]?.ToString() == "Demo Brand");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllBrandsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllBrandsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var deleteRequest = new RestRequest("/brand/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", brand["_id"]?.ToString());

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/brand/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", brand["_id"]?.ToString());

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
