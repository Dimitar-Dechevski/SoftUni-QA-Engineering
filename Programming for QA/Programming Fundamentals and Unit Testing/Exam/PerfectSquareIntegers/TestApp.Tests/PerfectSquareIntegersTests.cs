using NUnit.Framework;

namespace TestApp.Tests
{
    public class PerfectSquareIntegersTests
    {
        [Test]
        public void Test_FindPerfectSquares_StartNumberGreaterThanEndNumber_ReturnsErrorMessage()
        {
            // Arrange
            int startNumber = 33;
            int endNumber = 15;
            string expected = "Start number should be less than end number.";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_GetSameSquareIntegerForStartAndEnd_ReturnsSameSquareInteger()
        {
            // Arrange
            int startNumber = 196;
            int endNumber = 196;
            string expected = "196";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_GetZeroAsSingleInteger_ReturnsZero()
        {
            // Arrange
            int startNumber = 0;
            int endNumber = 0;
            string expected = "0";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_RangeIncludesMultiplePerfectSquares_RetursOnlySquareIntegers()
        {
            // Arrange
            int startNumber = 1;
            int endNumber = 400;
            string expected = "1 4 9 16 25 36 49 64 81 100 121 144 169 196 225 256 289 324 361 400";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_FindPerfectSquares_NoPerfectSquaresInRange_ReturnsEmptyString()
        {
            // Arrange
            int startNumber = 10;
            int endNumber = 15;
            string expected = "";

            // Act
            string actual = PerfectSquareIntegers.FindPerfectSquares(startNumber, endNumber);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

