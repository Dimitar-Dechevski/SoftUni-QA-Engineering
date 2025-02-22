using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        exceptions = new Exceptions();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "test";
        string expected = "tset";

        // Act
        string actual = exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act 

        // Assert
        Assert.Throws<ArgumentNullException>(() => exceptions.ArgumentNullReverse(input));
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrange
        decimal price = 100;
        decimal discount = 20;
        decimal expected = 80;

        // Act
        decimal actual = exceptions.ArgumentCalculateDiscount(price, discount);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal price = 100;
        decimal discount = -20;

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => exceptions.ArgumentCalculateDiscount(price, discount));
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal price = 100;
        decimal discount = 120;

        // Act

        // Assert
        Assert.Throws<ArgumentException>(() => exceptions.ArgumentCalculateDiscount(price, discount));
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] numbers = new int[] { 25, 88, 46, 33, 97 };
        int index = 3;
        int expected = 33;

        // Act
        int actual = exceptions.IndexOutOfRangeGetElement(numbers, index);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] numbers = new int[] { 25, 88, 46, 33, 97 };
        int index = -3;

        // Act

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => exceptions.IndexOutOfRangeGetElement(numbers, index));
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] numbers = new int[] { 25, 88, 46, 33, 97 };
        int index = numbers.Length;

        // Act

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => exceptions.IndexOutOfRangeGetElement(numbers, index));
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] numbers = new int[] { 25, 88, 46, 33, 97 };
        int index = numbers.Length + 3;

        // Act

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => exceptions.IndexOutOfRangeGetElement(numbers, index));
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool isLoggedIn = true;
        string expected = "User logged in.";

        // Act
        string actual = exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool isLoggedIn = false;

        // Act

        // Assert
        Assert.Throws<InvalidOperationException>(() => exceptions.InvalidOperationPerformSecureOperation(isLoggedIn));
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "8";
        int expected = 8;

        // Act
        int actual = exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arrange
        string input = "test";

        // Act

        // Assert
        Assert.Throws<FormatException>(() => exceptions.FormatExceptionParseInt(input));
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }

        };
        string key = "three";
        int expected = 3;

        // Act
        int actual = exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 }

        };
        string key = "four";

        // Act

        // Assert
        Assert.Throws<KeyNotFoundException>(() => exceptions.KeyNotFoundFindValueByKey(input, key));
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int firstNumber = 15;
        int secondNumber = 73;
        int expected = 88;

        // Act
        int actual = exceptions.OverflowAddNumbers(firstNumber, secondNumber);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int firstNumber = int.MaxValue;
        int secondNumber = 1;

        // Act

        // Assert
        Assert.Throws<OverflowException>(() => exceptions.OverflowAddNumbers(firstNumber, secondNumber));
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int firstNumber = int.MinValue;
        int secondNumber = -1;

        // Act

        // Assert
        Assert.Throws<OverflowException>(() => exceptions.OverflowAddNumbers(firstNumber, secondNumber));
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 9;
        int divisor = 3;
        int expected = 3;

        // Act
        int actual = exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 9;
        int divisor = 0;

        // Act

        // Assert
        Assert.Throws<DivideByZeroException>(() => exceptions.DivideByZeroDivideNumbers(dividend, divisor));
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] numbers = new int[] { 15, 33, 46, 88, 27 };
        int index = 3;
        int expected = 209;

        // Act
        int actual = exceptions.SumCollectionElements(numbers, index);

        // Assert
        Assert.AreEqual(expected, actual);

    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] numbers = null;
        int index = 3;

        // Act

        // Assert
        Assert.Throws<ArgumentNullException>(() => exceptions.SumCollectionElements(numbers, index));
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] numbers = new int[] { 15, 33, 46, 88, 27 };
        int index = -3;

        // Act

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => exceptions.SumCollectionElements(numbers, index));
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            { "nine", "9" },
            { "eight", "8" },
            { "six", "6" }
        };
        string key = "eight";
        int expected = 8;

        // Act
        int actual = exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            { "nine", "9" },
            { "eight", "8" },
            { "six", "6" }
        };
        string key = "three";

        // Act

        // Assert
        Assert.Throws<KeyNotFoundException>(() => exceptions.GetElementAsNumber(input, key));
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            { "nine", "9" },
            { "eight", "8" },
            { "six", "test" }
        };
        string key = "six";

        // Act

        // Assert
        Assert.Throws<FormatException>(() => exceptions.GetElementAsNumber(input, key));
    }
}
