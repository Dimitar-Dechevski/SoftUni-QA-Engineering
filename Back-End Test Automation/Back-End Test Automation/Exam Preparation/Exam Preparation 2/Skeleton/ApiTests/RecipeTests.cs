using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Xml.Linq;

namespace ApiTests
{
    [TestFixture]
    public class RecipeTests : IDisposable
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
        public void Test_GetAllRecipes()
        {
            // Arrange
            var request = new RestRequest("/recipe", Method.Get);

            // Act
            var response = client.Execute(request);
            var recipes = JArray.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(recipes.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");
                Assert.That(recipes.Count, Is.GreaterThan(0), "Array contains no elements");

                foreach (var recipe in recipes)
                {
                    Assert.That(recipe["title"]?.ToString(), Is.Not.Null.Or.Empty, "Recipe title is null or empty");
                    Assert.That(recipe["ingredients"]?.Type, Is.EqualTo(JTokenType.Array), "Recipe ingredients is not array");
                    Assert.That(recipe["instructions"]?.Type, Is.EqualTo(JTokenType.Array), "Recipe instructions is not array");
                    Assert.That(recipe["cookingTime"]?.ToString(), Is.Not.Null.Or.Empty, "Recipe cookingTime is null or empty");
                    Assert.That(recipe["servings"]?.ToString(), Is.Not.Null.Or.Empty, "Recipe servings is null or empty");
                    Assert.That(recipe["category"]?.ToString(), Is.Not.Null.Or.Empty, "Recipe category is null or empty");
                }
            });
        }

        [Test]
        public void Test_GetRecipeByTitle()
        {
            // Arrange
            var request = new RestRequest("/recipe", Method.Get);

            // Act
            var response = client.Execute(request);
            var recipes = JArray.Parse(response.Content);
            var recipe = recipes.FirstOrDefault(r => r["title"]?.ToString() == "Chocolate Chip Cookies");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(response.Content.ToString(), Does.Contain("Chocolate Chip Cookies"), "Response content does not contain the expected value");
                Assert.That(recipe["cookingTime"]?.Value<int>(), Is.EqualTo(25), "Recipe cookingTime does not match the expected value");
                Assert.That(recipe["servings"]?.Value<int>(), Is.EqualTo(24), "Recipe servings does not match the expected value");
                Assert.That(recipe["ingredients"].Count, Is.EqualTo(9), "Recipe ingredients does not match the expected value");
                Assert.That(recipe["instructions"].Count, Is.EqualTo(7), "Recipe instructions does not match the expected value");
            });
        }

        [Test]
        public void Test_AddRecipe()
        {
            // Arrange
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            // Act
            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            var category = categories.FirstOrDefault(c => c["name"]?.ToString() == "Desserts");
            var categoryID = category["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var createRequest = new RestRequest("/recipe", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new
            {
                title = "Test",
                ingredients = new[]
                {
                    new { name = "Ingredient" ,  quantity = "50g"}
                },
                instructions = new[]
                {
                    new {step = "Instruction" }
                },
                cookingTime = 30,
                servings = 15,
                category = categoryID
            });

            // Act
            var createResponse = client.Execute(createRequest);
            var createdRecipe = JObject.Parse(createResponse.Content);
            var recipeID = createdRecipe["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
             {
                 Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                 Assert.That(createResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
             });

            // Arrange
            var verifyAfterCreateRequest = new RestRequest("/recipe/{id}", Method.Get);
            verifyAfterCreateRequest.AddUrlSegment("id", recipeID);

            // Act
            var verifyAfterCreateResponse = client.Execute(verifyAfterCreateRequest);
            var recipe = JObject.Parse(verifyAfterCreateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterCreateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterCreateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(recipe["title"]?.ToString(), Is.EqualTo("Test"), "Recipe title does not match the expected value");
                Assert.That(recipe["cookingTime"]?.Value<int>(), Is.EqualTo(30), "Recipe cookingTime does not match the expected value");
                Assert.That(recipe["servings"]?.Value<int>(), Is.EqualTo(15), "Recipe servings does not match the expected value");
                Assert.That(recipe["category"]?.ToString(), Is.Not.Null.Or.Empty, "Recipe category is null or empty");
                Assert.That(recipe["category"]["_id"]?.ToString(), Is.EqualTo(categoryID), "Recipe category ID does not match the expected value");
                Assert.That(recipe["ingredients"].Type, Is.EqualTo(JTokenType.Array), "Recipe ingredients is not array");
                Assert.That(recipe["ingredients"].Count, Is.EqualTo(1), "Recipe ingredients does not match the expected value");
                foreach (var ingredient in recipe["ingredients"])
                {
                    Assert.That(ingredient["name"]?.ToString(), Is.EqualTo("Ingredient"), "Ingredient name does not match the expected value");
                    Assert.That(ingredient["quantity"]?.ToString(), Is.EqualTo("50g"), "Ingredient quantity does not match the expected value");
                }
                Assert.That(recipe["instructions"].Type, Is.EqualTo(JTokenType.Array), "Recipe instructions is not array");
                Assert.That(recipe["instructions"].Count, Is.EqualTo(1), "Recipe instructions does not match the expected value");
                foreach (var instruction in recipe["instructions"])
                {
                    Assert.That(instruction["step"]?.ToString(), Is.EqualTo("Instruction"), "Instruction step does not match the expected value");
                }
            });
        }

        [Test]
        public void Test_UpdateRecipe()
        {
            // Arrange
            var getAllRecipesRequest = new RestRequest("/recipe", Method.Get);

            // Act
            var getAllRecipesResponse = client.Execute(getAllRecipesRequest);
            var recipes = JArray.Parse(getAllRecipesResponse.Content);
            var recipe = recipes.FirstOrDefault(r => r["title"]?.ToString() == "Spaghetti Carbonara");
            var recipeID = recipe["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllRecipesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllRecipesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllRecipesResponse.Content.ToString(), Does.Contain("Spaghetti Carbonara"), "Response content does not contain the expected value");
            });

            // Arrange
            var updateRequest = new RestRequest("/recipe/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", recipeID);
            updateRequest.AddJsonBody(new
            {
                title = "Spaghetti Bolognese",
                servings = "4"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);
            var updatedRecipe = JObject.Parse(updateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedRecipe["title"]?.ToString(), Is.EqualTo("Spaghetti Bolognese"), "Recipe title does not match the expected value");
                Assert.That(updatedRecipe["servings"]?.ToString(), Is.EqualTo("4"), "Recipe servings does not match the expected value");
            });
        }

        [Test]
        public void Test_DeleteRecipe()
        {
            // Arrange
            var getAllRecipesRequest = new RestRequest("/recipe", Method.Get);

            // Act
            var getAllRecipesResponse = client.Execute(getAllRecipesRequest);
            var recipes = JArray.Parse(getAllRecipesResponse.Content);
            var recipe = recipes.FirstOrDefault(r => r["title"]?.ToString() == "Chicken Curry");
            var recipeID = recipe["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllRecipesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllRecipesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllRecipesResponse.Content.ToString(), Does.Contain("Chicken Curry"), "Response content does not contain the expected value");
            });

            // Arrange
            var deleteRequest = new RestRequest("/recipe/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", recipeID);

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/recipe/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", recipeID);

            // Act
            var verifyAfterDeleteResponse = client.Execute(verifyAfterDeleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterDeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(verifyAfterDeleteResponse.Content, Is.Null.Or.EqualTo("null"), "Response content does not match the expected value");
            });
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
