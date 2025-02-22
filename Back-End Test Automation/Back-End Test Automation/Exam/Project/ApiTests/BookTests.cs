using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Net;

namespace ApiTests
{
    [TestFixture]
    public class BookTests : IDisposable
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
        public void Test_GetAllBooks()
        {
            // Arrange
            var request = new RestRequest("/book", Method.Get);

            // Act
            var response = client.Execute(request);
            var books = JArray.Parse(response.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(books.Type, Is.EqualTo(JTokenType.Array), "Response content is not array");
                Assert.That(books.Count, Is.GreaterThan(0), "Array contains no elements");

                foreach (var book in books)
                {
                    Assert.That(book["title"]?.ToString(), Is.Not.Null.Or.Empty, "Book title is null or empty");
                    Assert.That(book["author"]?.ToString(), Is.Not.Null.Or.Empty, "Book author is null or empty");
                    Assert.That(book["description"]?.ToString(), Is.Not.Null.Or.Empty, "Book description is null or empty");
                    Assert.That(book["price"]?.Value<decimal>(), Is.Not.Null.Or.Empty, "Book price is null or empty");
                    Assert.That(book["pages"]?.Value<int>(), Is.Not.Null.Or.Empty, "Book pages is null or empty");
                    Assert.That(book["category"]?.ToString(), Is.Not.Null.Or.Empty, "Book category is null or empty");
                }
            });
        }

        [Test]
        public void Test_GetBookByTitle()
        {
            // Arrange
            var request = new RestRequest("/book", Method.Get);

            // Act
            var response = client.Execute(request);
            var books = JArray.Parse(response.Content);
            var book = books.FirstOrDefault(b => b["title"]?.ToString() == "The Great Gatsby");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(response.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(response.Content.ToString(), Does.Contain("The Great Gatsby"), "Response content does not contain the expected value");
                Assert.That(book["author"]?.ToString(), Is.EqualTo("F. Scott Fitzgerald"), "Book author does not match the expected value");
            });
        }

        [Test]
        public void Test_AddBook()
        {
            // Arrange
            var getAllCategoriesRequest = new RestRequest("/category", Method.Get);

            // Act
            var getAllCategoriesResponse = client.Execute(getAllCategoriesRequest);
            var categories = JArray.Parse(getAllCategoriesResponse.Content);
            var category = categories.FirstOrDefault(c => c["title"]?.ToString() == "Mystery");
            var categoryID = category["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllCategoriesResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllCategoriesResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var createRequest = new RestRequest("/book", Method.Post);
            createRequest.AddHeader("Authorization", $"Bearer {token}");
            createRequest.AddJsonBody(new
            {
                title = "Test",
                author = "Test",
                description = "Test",
                price = 27.99,
                pages = 296,
                category = categoryID
            });

            // Act
            var createResponse = client.Execute(createRequest);
            var createdBook = JObject.Parse(createResponse.Content);
            var bookID = createdBook["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(createResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(createResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterCreateRequest = new RestRequest("/book/{id}", Method.Get);
            verifyAfterCreateRequest.AddUrlSegment("id", bookID);

            // Act
            var verifyAfterCreateResponse = client.Execute(verifyAfterCreateRequest);
            var book = JObject.Parse(verifyAfterCreateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(verifyAfterCreateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(verifyAfterCreateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(book["title"]?.ToString(), Is.EqualTo("Test"), "Book title does not match the expected value");
                Assert.That(book["author"]?.ToString(), Is.EqualTo("Test"), "Book author does not match the expected value");
                Assert.That(book["description"]?.ToString(), Is.EqualTo("Test"), "Book description does not match the expected value");
                Assert.That(book["price"]?.Value<decimal>(), Is.EqualTo(27.99), "Book price does not match the expected value");
                Assert.That(book["pages"]?.Value<int>(), Is.EqualTo(296), "Book pages does not match the expected value");
                Assert.That(book["category"]?.ToString(), Is.Not.Null.Or.Empty, "Book category is null or empty");
                Assert.That(book["category"]["_id"]?.ToString(), Is.EqualTo(categoryID), "Book category ID does not match the expected value");
            });
        }

        [Test]
        public void Test_UpdateBook()
        {
            // Arrange
            var getAllBooksRequest = new RestRequest("/book", Method.Get);

            // Act
            var getAllBooksResponse = client.Execute(getAllBooksRequest);
            var books = JArray.Parse(getAllBooksResponse.Content);
            var book = books.FirstOrDefault(b => b["title"]?.ToString() == "The Catcher in the Rye");
            var bookID = book["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllBooksResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllBooksResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllBooksResponse.Content.ToString, Does.Contain("The Catcher in the Rye"), "Response content does not contain the expected value");
            });

            // Arrange
            var updateRequest = new RestRequest("/book/{id}", Method.Put);
            updateRequest.AddHeader("Authorization", $"Bearer {token}");
            updateRequest.AddUrlSegment("id", bookID);
            updateRequest.AddJsonBody(new
            {
                title = "Updated Book Title",
                author = "Updated Author"
            });

            // Act
            var updateResponse = client.Execute(updateRequest);
            var updatedBook = JObject.Parse(updateResponse.Content);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(updateResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(updateResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(updatedBook["title"]?.ToString(), Is.EqualTo("Updated Book Title"), "Book title does not match the expected value");
                Assert.That(updatedBook["author"]?.ToString(), Is.EqualTo("Updated Author"), "Book author does not match the expected value");
            });
        }

        [Test]
        public void Test_DeleteBook()
        {
            // Arrange
            var getAllBooksRequest = new RestRequest("/book", Method.Get);

            // Act
            var getAllBooksResponse = client.Execute(getAllBooksRequest);
            var books = JArray.Parse(getAllBooksResponse.Content);
            var book = books.FirstOrDefault(b => b["title"]?.ToString() == "To Kill a Mockingbird");
            var bookID = book["_id"]?.ToString();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(getAllBooksResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(getAllBooksResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
                Assert.That(getAllBooksResponse.Content.ToString, Does.Contain("To Kill a Mockingbird"), "Response content does not contain the expected value");
            });

            // Arrange
            var deleteRequest = new RestRequest("/book/{id}", Method.Delete);
            deleteRequest.AddHeader("Authorization", $"Bearer {token}");
            deleteRequest.AddUrlSegment("id", bookID);

            // Act
            var deleteResponse = client.Execute(deleteRequest);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Response status code is not 200 OK");
                Assert.That(deleteResponse.Content, Is.Not.Null.Or.Empty, "Response content is null or empty");
            });

            // Arrange
            var verifyAfterDeleteRequest = new RestRequest("/book/{id}", Method.Get);
            verifyAfterDeleteRequest.AddUrlSegment("id", bookID);

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
