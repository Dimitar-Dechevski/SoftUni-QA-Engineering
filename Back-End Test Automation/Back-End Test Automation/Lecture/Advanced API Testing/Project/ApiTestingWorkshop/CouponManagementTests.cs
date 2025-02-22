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
    public class CouponManagementTests
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
        public void CouponLifecycleTest()
        {
            // Retrieve all products and randomly select two distinct product IDs

            // Arrange
            var getAllProductsRequest = new RestRequest("/product", Method.Get);

            // Act
            var getAllProductsResponse = client.Execute(getAllProductsRequest);
            var products = JArray.Parse(getAllProductsResponse.Content);
            var productsIDs = products.Select(p => p["_id"]?.ToString()).ToList();
            var firstProductId = productsIDs[random.Next(productsIDs.Count)];
            var secondProductId = productsIDs[random.Next(productsIDs.Count)];

            while (firstProductId == secondProductId)
            {
                secondProductId = productsIDs[random.Next(productsIDs.Count)];
            }

            // Assert
            Assert.That(getAllProductsResponse.IsSuccessful, Is.True, "Retrieving all products is failed");
            Assert.That(products.Count, Is.GreaterThan(2), "Array contains elements less than two");
            Assert.That(firstProductId, Is.Not.Null.Or.Empty, "First product ID is null or empty");
            Assert.That(secondProductId, Is.Not.Null.Or.Empty, "Second product ID is null or empty");

            // Create a coupon

            // Arrange
            var createCouponRequest = new RestRequest("/coupon", Method.Post);
            createCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createCouponRequest.AddJsonBody(new
            {
                name = $"Test_{random.Next(999, 9999)}",
                discount = 20,
                expiry = "2026-12-31"
            });

            // Act
            var createCouponResponse = client.Execute(createCouponRequest);
            var coupon = JObject.Parse(createCouponResponse.Content);
            var couponId = coupon["_id"]?.ToString();
            var couponName = coupon["name"]?.ToString();

            // Assert
            Assert.That(createCouponResponse.IsSuccessful, Is.True, "Creating a coupon is failed");
            Assert.That(couponId, Is.Not.Null.Or.Empty, "Coupon ID is null or empty");

            // Add a product to cart

            // Arrange
            var addToCartRequest = new RestRequest("/user/cart", Method.Post);
            addToCartRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToCartRequest.AddJsonBody(new
            {
                cart = new[]
                {
                  new  { _id = firstProductId, count = 1, color = "red" },
                  new  { _id = secondProductId, count = 2, color = "blue" }
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
                coupon = couponName
            });

            // Act
            var applyCouponResponse = client.Execute(applyCouponRequest);

            // Assert
            Assert.That(applyCouponResponse.IsSuccessful, Is.True, "Applying a coupon is failed");

            // Delete a coupon

            // Arrange
            var deleteCouponRequest = new RestRequest("/coupon/{id}", Method.Delete);
            deleteCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            deleteCouponRequest.AddUrlSegment("id", couponId);

            // Act
            var deleteCouponResponse = client.Execute(deleteCouponRequest);

            // Assert
            Assert.That(deleteCouponResponse.IsSuccessful, Is.True, "Deleting a coupon is failed");

            // Verify that coupon is deleted

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/coupon/{id}", Method.Get);
            verifyAfterDeleteRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            verifyAfterDeleteRequest.AddUrlSegment("id", couponId);

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.That(verifyAfterDeleteResponse.Content, Is.Null.Or.EqualTo("null"), "Coupon still exist after deletion");
        }

        [Test]
        public void CouponApplicationToOrderTest()
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

            // Create a coupon

            // Arrange
            var createCouponRequest = new RestRequest("/coupon", Method.Post);
            createCouponRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            createCouponRequest.AddJsonBody(new
            {
                name = $"Test_{random.Next(999, 9999)}",
                discount = 10,
                expiry = "2027-12-31"
            });

            // Act
            var createCouponResponse = client.Execute(createCouponRequest);
            var coupon = JObject.Parse(createCouponResponse.Content);
            var couponId = coupon["_id"]?.ToString();
            var couponName = coupon["name"]?.ToString();

            // Assert
            Assert.That(createCouponResponse.IsSuccessful, Is.True, "Creating a coupon is failed");
            Assert.That(couponId, Is.Not.Null.Or.Empty, "Coupon ID is null or empty");

            // Add a product to cart

            // Arrange
            var addToCartRequest = new RestRequest("/user/cart", Method.Post);
            addToCartRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToCartRequest.AddJsonBody(new
            {
                cart = new[]
                {
                  new  { _id = productId, count = 3, color = "green" }
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
                coupon = couponName
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
        }

    }
}
