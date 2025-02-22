using NUnit.Framework;
using System;
using TestApp.Library;

namespace TestApp.Tests;

[TestFixture]
public class LibraryCatalogTests
{
    private LibraryCatalog catalog = null!;

    [SetUp]
    public void SetUp()
    {
        this.catalog = new LibraryCatalog();
    }

    [Test]
    public void Test_AddBook_BookAddedToCatalog()
    {
        // Arrange
        string isbn = "978-3-2785-4449-0";
        string title = "1984";
        string author = "George Orwell";
        string expected = $"Library Catalog:{Environment.NewLine}" +
                          $"1984 by George Orwell (ISBN: 978-3-2785-4449-0)";

        // Act
        catalog.AddBook(isbn, title, author);
        string actual = catalog.DisplayCatalog();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetBook_BookExists_ReturnsBook()
    {
        // Arrange
        string isbn = "978-3-2785-4449-0";
        string title = "1984";
        string author = "George Orwell";
        Book expected = new Book(isbn, title, author);

        // Act
        catalog.AddBook(isbn, title, author);
        Book actual = catalog.GetBook(isbn);

        // Assert
        Assert.AreEqual(expected.Isbn, actual.Isbn);
        Assert.AreEqual(expected.Title, actual.Title);
        Assert.AreEqual(expected.Author, actual.Author);
    }

    [Test]
    public void Test_GetBook_BookDoesNotExist_ThrowsArgumentException()
    {
        // Arrange
        string isbn = "978-3-2785-4449-0";

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => catalog.GetBook(isbn));
    }

    [Test]
    public void Test_DisplayCatalog_NoBooks_ReturnsEmptyString()
    {
        // Arrange
        string expected = "";

        // Act
        string actual = catalog.DisplayCatalog();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayCatalog_WithBooks_ReturnsFormattedCatalog()
    {
        // Arrange
        string firstIsbn = "978-3-2785-4449-0";
        string firstTitle = "1984";
        string firstAuthor = "George Orwell";
        string secondIsbn = "978-0-6457-3145-3";
        string secondTitle = "Atomic Habits";
        string secondAuthor = "James Clear";
        string expected = $"Library Catalog:{Environment.NewLine}" +
                          $"1984 by George Orwell (ISBN: 978-3-2785-4449-0){Environment.NewLine}" +
                          $"Atomic Habits by James Clear (ISBN: 978-0-6457-3145-3)";

        // Act
        catalog.AddBook(firstIsbn, firstTitle, firstAuthor);
        catalog.AddBook(secondIsbn, secondTitle, secondAuthor);
        string actual = catalog.DisplayCatalog();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
