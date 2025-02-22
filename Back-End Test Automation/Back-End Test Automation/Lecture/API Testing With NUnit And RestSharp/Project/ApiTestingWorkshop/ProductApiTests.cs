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
    public class ProductApiTests : IDisposable
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
        public void Test_GetAllProducts()
        {
            // Arrange
            var request = new RestRequest("/product", Method.Get);

            // Act
            var response = client.Execute(request);
            var products = JArray.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");

                var specificProducts = new string[]
                {
                "Smartphone Alpha",
                "Wireless Headphones"
                };

                foreach (var specificProduct in specificProducts)
                {
                    Assert.That(products.ToString(), Does.Contain(specificProduct), "Response content does not contain the expected value");
                }

                var items = new Dictionary<string, decimal>
                {
                    { "Smartphone Alpha", 999 },
                    { "Wireless Headphones", 199 }
                };

                foreach (var product in products)
                {
                    var title = product["title"]?.ToString();

                    if (items.ContainsKey(title))
                    {
                        Assert.That(product["price"]?.Value<decimal>(), Is.EqualTo(items[title]), "Product price does not match the expected value");
                    }
                }
            });
        }

        [Test, Order(2)]
        public void Test_AddProduct()
        {
            // Arrange
            var request = new RestRequest("/product", Method.Post);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddJsonBody(new
            {
                title = "Test Product",
                slug = "test-product",
                description = "Test Description",
                price = 15.99,
                category = "Test",
                brand = "Test",
                quantity = 11
            });

            // Act
            var response = client.Execute(request);
            var product = JObject.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(product["title"]?.ToString(), Is.EqualTo("Test Product"), "Product title does not match the expected value");
                Assert.That(product["slug"]?.ToString(), Is.EqualTo("test-product"), "Product slug does not match the expected value");
                Assert.That(product["description"]?.ToString(), Is.EqualTo("Test Description"), "Product description does not match the expected value");
                Assert.That(product["price"]?.Value<decimal>(), Is.EqualTo(15.99), "Product price does not match the expected value");
                Assert.That(product["category"]?.ToString(), Is.EqualTo("Test"), "Product category does not match the expected value");
                Assert.That(product["brand"]?.ToString(), Is.EqualTo("Test"), "Product brand does not match the expected value");
                Assert.That(product["quantity"]?.Value<int>(), Is.EqualTo(11), "Product quantity does not match the expected value");
            });
        }

        [Test, Order(3)]
        public void Test_UpdateProduct_InvalidProductId()
        {
            // Arrange
            var request = new RestRequest("/product/{id}", Method.Put);
            request.AddHeader("Authorization", $"Bearer {token}");
            request.AddUrlSegment("id", "test");
            request.AddJsonBody(new
            {
                title = "Demo Product",
                slug = "demo-product",
                description = "Demo Description",
                price = 11.99,
                category = "Demo",
                brand = "Demo",
                quantity = 15
            });

            // Act
            var response = client.Execute(request);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest).Or.EqualTo(HttpStatusCode.InternalServerError), "Response status code is not 400 BadRequest or 500 InternalServerError");
                Assert.That(response.Content, Does.Contain("This id is not valid or not Found"), "Response content does not contain the expected value");
            });
        }

        [Test, Order(4)]
        public void Test_DeleteProduct()
        {
            // Arrange
            var getAllProductsRequest = new RestRequest("/product", Method.Get);

            // Act
            var getAllProductsResponse = client.Execute(getAllProductsRequest);
            var products = JArray.Parse(getAllProductsResponse.Content);
            var product = products.FirstOrDefault(p => p["slug"]?.ToString() == "test-product");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllProductsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllProductsResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var deleteRequest = new RestRequest("product/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", product["_id"]?.ToString());

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/product/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", product["_id"]?.ToString());

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
