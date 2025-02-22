using Newtonsoft.Json;
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
    public class OrderManagementTests
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
        public void ComplexOrderLifecycleTest()
        {
            // Retrieve all products and select one product ID

            // Arrange
            var getAllProductsRequest = new RestRequest("/product", Method.Get);

            // Act
            var getAllProductsResponse = client.Execute(getAllProductsRequest);
            var products = JArray.Parse(getAllProductsResponse.Content);
            var productsIDs = products.Select(p => p["_id"]?.ToString()).ToList();
            var productId = productsIDs[random.Next(productsIDs.Count)];

            // Assert
            Assert.That(getAllProductsResponse.IsSuccessful, Is.True, "Retrieving all products is failed");
            Assert.That(products.Count, Is.GreaterThan(0), "Array contains no elements");
            Assert.That(productId, Is.Not.Null.Or.Empty, "Product ID is null or empty");

            // Add a product to cart

            // Arrange
            var addToCartRequest = new RestRequest("/user/cart", Method.Post);
            addToCartRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToCartRequest.AddJsonBody(new
            {
                cart = new[]
                {
                  new  { _id = productId, count = 5, color = "orange" }
                }
            });

            // Act
            var addToCartResponse = client.Execute(addToCartRequest);

            // Assert
            Assert.That(addToCartResponse.IsSuccessful, Is.True, "Adding a product to cart is failed");

            // Apply a coupon

            // Arrange
            var applyCouponRequest = new RestRequest("/user/cart/applycoupon", Method.Post);
            applyCouponRequest.AddHeader("Authorization", $"Bearer {userToken}");
            applyCouponRequest.AddJsonBody(new
            {
                coupon = "BLACKFRIDAY"
            });

            // Act
            var applyCouponResponse = client.Execute(applyCouponRequest);

            // Assert
            Assert.That(applyCouponResponse.IsSuccessful, Is.True, "Applying a coupon is failed");

            // Place the order

            // Arrange
            var placeOrderRequest = new RestRequest("/user/cart/cash-order", Method.Post);
            placeOrderRequest.AddHeader("Authorization", $"Bearer {userToken}");
            placeOrderRequest.AddJsonBody(JsonConvert.SerializeObject(new
            {
                COD = true,
                couponApplied = true
            }));

            // Act
            var placeOrderResponse = client.Execute(placeOrderRequest);

            // Assert
            Assert.That(placeOrderResponse.IsSuccessful, Is.True, "Placing the order is failed");

            // Retrieve the order

            // Arrange
            var getOrderRequest = new RestRequest("/user/get-orders", Method.Get);
            getOrderRequest.AddHeader("Authorization", $"Bearer {userToken}");

            // Act
            var getOrderResponse = client.Execute(getOrderRequest);
            var order = JObject.Parse(getOrderResponse.Content);
            var orderId = order["_id"]?.ToString();

            // Assert
            Assert.That(getOrderResponse.IsSuccessful, Is.True, "Retrieving the order is failed");
            Assert.That(orderId, Is.Not.Null.Or.Empty, "Order ID is null or empty");

            // Update an order

            // Arrange
            var updateOrderRequest = new RestRequest("/user/order/update-order/{id}", Method.Put);
            updateOrderRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            updateOrderRequest.AddUrlSegment("id", orderId);
            updateOrderRequest.AddJsonBody(new
            {
                status = "Cancelled"
            });

            // Act
            var updateOrderResponse = client.Execute(updateOrderRequest);

            // Assert
            Assert.That(updateOrderResponse.IsSuccessful, Is.True, "Updating an order is failed");
        }
    }
}
