using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestApp.Tests
{
    public class VowelsCounterTests
    {
        [Test]
        public void Test_CountTotalVowels_GetEmptyList_ReturnsZero()
        {
            // Arrange
            List<string> input = new List<string>();
            int expected = 0;

            // Act
            int actual = VowelsCounter.CountTotalVowels(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_GetListWithEmptyStringValues_ReturnsZero()
        {
            // Arrange
            List<string> input = new List<string>() { "", "", "" };
            int expected = 0;

            // Act
            int actual = VowelsCounter.CountTotalVowels(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_MultipleLowerCaseStrings_ReturnsVowelsCount()
        {
            // Arrange
            List<string> input = new List<string>() { "coyote", "dolphin", "bee", "eagle", "koala" };
            int expected = 13;

            // Act
            int actual = VowelsCounter.CountTotalVowels(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_GetStringsWithNoVowels_ReturnsZero()
        {
            // Arrange
            List<string> input = new List<string>() { "ktm", "vw", "bmw", "wrc", "dtm" };
            int expected = 0;

            // Act
            int actual = VowelsCounter.CountTotalVowels(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_CountTotalVowels_StringsWithMixedCaseVowels_ReturnsVowelsCount()
        {
            // Arrange
            List<string> input = new List<string>() { "PandA", "PenGuin", "ElEphant", "HiPPopOtamus", "DEEr" };
            int expected = 15;

            // Act
            int actual = VowelsCounter.CountTotalVowels(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

