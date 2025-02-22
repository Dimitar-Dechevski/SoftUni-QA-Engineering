using NUnit.Framework;

namespace TestApp.Tests
{
    public class HashTagCheckerTests
    {
        [Test]
        public void Test_GetHashTags_ValidTextWithOneHashTag_ReturnMessageForOneHashTags()
        {
            // Arrange
            string input = "#Bulgaria";
            string expected = "Only one! You know exactly what you #tag.";

            // Act
            string actual = HashTagChecker.GetHashTags(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetHashTags_ValidText_ReturnMessageForEvenHashTags()
        {
            // Arrange
            string input = "#Bulgaria#";
            string expected = "The text contains an even number of #tags (2 in total).";

            // Act
            string actual = HashTagChecker.GetHashTags(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetHashTags_ValidText_ReturnMessageForOddHashTags()
        {
            // Arrange
            string input = "#Bulgaria#Croatia#";
            string expected = "The text contains an odd number of #tags (3 in total).";

            // Act
            string actual = HashTagChecker.GetHashTags(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetHashTags_NullOrEmptyText_ReturnsErrorMessage()
        {
            // Arrange
            string input = "";
            string expected = "No content...";

            // Act
            string actual = HashTagChecker.GetHashTags(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_GetHashTags_TestWithoutHashTags_ReturnsErrorMessage()
        {
            // Arrange
            string input = "Bulgaria";
            string expected = "The text does not contain #tags.";

            // Act
            string actual = HashTagChecker.GetHashTags(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

