using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestingWorkshop
{
    [TestFixture]
    public class ProductManagementTests
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
        public void ProductLifecycleTest()
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
                price = 25.50,
                category = "Test",
                brand = "Test",
                quantity = 5
            });

            // Act
            var createProductResponse = client.Execute(createProductRequest);
            var product = JObject.Parse(createProductResponse.Content);
            var productId = product["_id"]?.ToString();

            // Assert
            Assert.That(createProductResponse.IsSuccessful, Is.True, "Creating a product is failed");
            Assert.That(productId, Is.Not.Null.Or.Empty, "Product ID is null or empty");

            // Retrieve a product by ID

            // Arrange
            var getProductByIdRequest = new RestRequest("/product/{id}", Method.Get);
            getProductByIdRequest.AddUrlSegment("id", productId);

            // Act
            var getProductByIdResponse = client.Execute(getProductByIdRequest);

            // Assert
            Assert.That(getProductByIdResponse.IsSuccessful, Is.True, "Retrieving a product by ID is failed");
            Assert.That(getProductByIdResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");

            // Update a product

            // Arrange
            var updateProductRequest = new RestRequest("/product/{id}", Method.Put);
            updateProductRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            updateProductRequest.AddUrlSegment("id", productId);
            randomNumber = random.Next(999, 9999);
            updateProductRequest.AddJsonBody(new
            {
                title = $"Test {randomNumber}",
                slug = $"test-{randomNumber}",
                description = "Bug",
                price = 19.75
            });

            // Act
            var updateProductResponse = client.Execute(updateProductRequest);

            // Assert
            Assert.That(updateProductResponse.IsSuccessful, Is.True, "Updating a product is failed");

            // Delete a product

            // Arrange
            var deleteProductRequest = new RestRequest("/product/{id}", Method.Delete);
            deleteProductRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            deleteProductRequest.AddUrlSegment("id", productId);

            // Act
            var deleteProductResponse = client.Execute(deleteProductRequest);

            // Assert
            Assert.That(deleteProductResponse.IsSuccessful, Is.True, "Deleting a product is failed");

            // Verify that product is deleted

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/product/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", productId);

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.That(verifyAfterDeleteResponse.Content, Is.Null.Or.EqualTo("null"), "Product still exist after deletion");
        }

        [Test]
        public void ProductRatingsLifecycleTest()
        {
            // Retrieve all product and select one product ID

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

            // Add a review to product

            // Arrange
            var addReviewRequest = new RestRequest("/product/rating", Method.Put);
            addReviewRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addReviewRequest.AddJsonBody(new
            {
                star = 5,
                prodId = productId,
                comment = "Test"
            });

            // Act
            var addReviewResponse = client.Execute(addReviewRequest);

            // Assert
            Assert.That(addReviewResponse.IsSuccessful, Is.True, "Adding a review to product is failed");

            // Add a product to wishlist

            // Arrange
            var addToWishlistRequest = new RestRequest("/product/wishlist", Method.Put);
            addToWishlistRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToWishlistRequest.AddJsonBody(new
            {
                prodId = productId
            });

            // Act
            var addToWishlistResponse = client.Execute(addToWishlistRequest);

            // Assert
            Assert.That(addToWishlistResponse.IsSuccessful, "Adding a product to wishlist is failed");
        }

        [Test]
        public void ComplexProductInteractionTest()
        {
            // Retrieve all product and select one product ID

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

            // Add a product to wishlist

            // Arrange
            var addToWishlistRequest = new RestRequest("/product/wishlist", Method.Put);
            addToWishlistRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addToWishlistRequest.AddJsonBody(new
            {
                prodId = productId
            });

            // Act
            var addToWishlistResponse = client.Execute(addToWishlistRequest);

            // Assert
            Assert.That(addToWishlistResponse.IsSuccessful, "Adding a product to wishlist is failed");

            // Upload a photo to product

            // Arrange
            var uploadPhotoRequest = new RestRequest("/product/upload/{id}", Method.Put);
            uploadPhotoRequest.AddHeader("Authorization", $"Bearer {adminToken}");
            uploadPhotoRequest.AddUrlSegment("id", productId);
            uploadPhotoRequest.AddJsonBody(new
            {
                images = new[]
                {
                    "https://example.com/image.jpg"
                }
            });

            // Act
            var uploadPhotoResponse = client.Execute(uploadPhotoRequest);

            // Assert
            Assert.That(uploadPhotoResponse.IsSuccessful, Is.True, "Uploading a photo to product is failed");

            // Add a review to product

            // Arrange
            var addReviewRequest = new RestRequest("/product/rating", Method.Put);
            addReviewRequest.AddHeader("Authorization", $"Bearer {userToken}");
            addReviewRequest.AddJsonBody(new
            {
                star = 5,
                prodId = productId,
                comment = "Test"
            });

            // Act
            var addReviewResponse = client.Execute(addReviewRequest);

            // Assert
            Assert.That(addReviewResponse.IsSuccessful, Is.True, "Adding a review to product is failed");

            // Remove a product from wishlist

            // Arrange
            var removeFromWishlistRequest = new RestRequest("/product/wishlist", Method.Put);
            removeFromWishlistRequest.AddHeader("Authorization", $"Bearer {userToken}");
            removeFromWishlistRequest.AddJsonBody(new
            {
                prodId = productId
            });

            // Act
            var removeFromWishlistResponse = client.Execute(removeFromWishlistRequest);

            // Assert
            Assert.That(removeFromWishlistResponse.IsSuccessful, "Removing a product from wishlist is failed");
        }
    }
}
