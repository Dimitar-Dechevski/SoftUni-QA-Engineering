using Microsoft.VisualBasic;
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
    public class UserManagementTests
    {
        private RestClient client;
        private string adminToken;
        private Random random;

        [SetUp]
        public void SetUp()
        {
            client = new RestClient(GlobalConstants.baseUrl);
            random = new Random();
            adminToken = GlobalConstants.GetAuthenticationToken("admin@gmail.com", "admin@gmail.com");

            Assert.That(adminToken, Is.Not.Null.Or.Empty, "Admin authentication token is null or empty");
        }

        [TearDown]
        public void Dispose()
        {
            client.Dispose();
        }

        [Test]
        public void UserLoginTest()
        {
            // User login

            // Arrange
            var loginRequest = new RestRequest("/user/login", Method.Post);
            loginRequest.AddJsonBody(new
            {
                email = "johndoe@example.com",
                password = "password123"
            });

            // Act
            var loginResponse = client.Execute(loginRequest);
            var user = JObject.Parse(loginResponse.Content);
            var userToken = user["token"]?.ToString();

            // Assert
            Assert.That(loginResponse.IsSuccessful, Is.True, "User login is failed");
            Assert.That(loginResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            Assert.That(userToken, Is.Not.Null.Or.Empty, "User token is null or empty");

            // User registration

            // Arrange
            var registrationRequest = new RestRequest("/user/register", Method.Post);
            var randomNumber = random.Next(999, 9999);
            registrationRequest.AddJsonBody(new
            {
                firstname = $"User{randomNumber}",
                lastname = $"User{randomNumber}",
                email = $"test{randomNumber}@test.com",
                mobile = $"{randomNumber}",
                password = $"test{randomNumber}"
            });

            // Act
            var registrationResponse = client.Execute(registrationRequest);

            // Assert
            Assert.That(registrationResponse.IsSuccessful, Is.True, "User registration is failed");

            // Password reset

            // Arrange
            var passwordResetRequest = new RestRequest("/user/forgot-password-token", Method.Post);
            passwordResetRequest.AddJsonBody(new
            {
                email = $"test{randomNumber}@test.com"
            });

            // Act
            var passwordResetResponse = client.Execute(passwordResetRequest);

            // Assert
            Assert.That(passwordResetResponse.IsSuccessful, Is.True, "Password resetting is failed");
            Assert.That(passwordResetResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
        }

        [Test]
        public void UserSignupLoginUpdateAndDeleteTest()
        {
            // Arrange
            var registrationRequest = new RestRequest("/user/register", Method.Post);
            var randomNumber = random.Next(999, 9999);
            registrationRequest.AddJsonBody(new
            {
                firstname = $"User{randomNumber}",
                lastname = $"User{randomNumber}",
                email = $"test{randomNumber}@test.com",
                mobile = $"{randomNumber}",
                password = $"test{randomNumber}"
            });

            // Act
            var registrationResponse = client.Execute(registrationRequest);

            // Assert
            Assert.That(registrationResponse.IsSuccessful, Is.True, "User registration is failed");
            Assert.That(registrationResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");

            // User login

            // Arrange
            var loginRequest = new RestRequest("/user/login", Method.Post);
            loginRequest.AddJsonBody(new
            {
                email = $"test{randomNumber}@test.com",
                password = $"test{randomNumber}"
            });

            // Act
            var loginResponse = client.Execute(loginRequest);
            var user = JObject.Parse(loginResponse.Content);
            var userToken = user["token"]?.ToString();
            var userId = user["_id"]?.ToString();

            // Assert
            Assert.That(loginResponse.IsSuccessful, Is.True, "User login is failed");
            Assert.That(loginResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            Assert.That(userToken, Is.Not.Null.Or.Empty, "User token is null or empty");
            Assert.That(userId, Is.Not.Null.Or.Empty, "User ID is null or empty");

            // User update

            // Arrange
            var updateUserRequest = new RestRequest("/user/edit-user", Method.Put);
            randomNumber = random.Next(999, 9999);
            updateUserRequest.AddHeader("Authorization", $"Bearer {userToken}");
            updateUserRequest.AddJsonBody(new
            {
                firstname = $"User{randomNumber}",
                lastname = $"User{randomNumber}",
                email = $"test{randomNumber}@test.com",
                mobile = $"{randomNumber}"
            });

            // Act
            var updateUserResponse = client.Execute(updateUserRequest);

            // Assert
            Assert.That(updateUserResponse.IsSuccessful, Is.True, "User update is failed");
            Assert.That(updateUserResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");

            // User delete

            // Arrange
            var deleteUserRequest = new RestRequest("/user/{id}", Method.Delete);
            deleteUserRequest.AddUrlSegment("id", userId);

            // Act
            var deleteUserResponse = client.Execute(deleteUserRequest);

            // Assert
            Assert.That(deleteUserResponse.IsSuccessful, Is.True, "User delete is failed");
        }

        [Test]
        public void ProductAndUserCartTest()
        {
            // Create a product

            // Arrange
            var createProductRequest = new RestRequest("/product", Method.Post);
            createProductRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            var randomNumber = random.Next(999, 9999);
            createProductRequest.AddJsonBody(new
            {
                title = $"Test {randomNumber}",
                slug = $"test-{randomNumber}",
                description = "Test",
                price = 33.33,
                category = "Test",
                brand = "Test",
                quantity = 3
            });

            // Act
            var createProductResponse = client.Execute(createProductRequest);
            var product = JObject.Parse(createProductResponse.Content);
            var productId = product["_id"]?.ToString();

            // Assert
            Assert.That(createProductResponse.IsSuccessful, Is.True, "Creating a product is failed");
            Assert.That(productId, Is.Not.Null.Or.Empty, "Product ID is null or empty");

            // User login

            // Arrange
            var loginRequest = new RestRequest("/user/login", Method.Post);
            loginRequest.AddJsonBody(new
            {
                email = "johndoe@example.com",
                password = "password123"
            });

            // Act
            var loginResponse = client.Execute(loginRequest);
            var user = JObject.Parse(loginResponse.Content);
            var userToken = user["token"]?.ToString();

            // Assert
            Assert.That(loginResponse.IsSuccessful, Is.True, "User login is failed");
            Assert.That(loginResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            Assert.That(userToken, Is.Not.Null.Or.Empty, "User token is null or empty");

            // Add a product to cart

            // Arrange
            var addToCartRequest = new RestRequest("/user/cart", Method.Post);
            addToCartRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToCartRequest.AddJsonBody(new
            {
                cart = new[]
                {
                  new  { _id = productId, count = 7, color = "white" }
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

            // Delete a product

            // Arrange
            var deleteProductRequest = new RestRequest("/product/{id}", Method.Delete);
            deleteProductRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            deleteProductRequest.AddUrlSegment("id", productId);

            // Act
            var deleteProductResponse = client.Execute(deleteProductRequest);

            // Assert
            Assert.That(deleteProductResponse.IsSuccessful, Is.True, "Deleting a product is failed");
        }
    }
}
