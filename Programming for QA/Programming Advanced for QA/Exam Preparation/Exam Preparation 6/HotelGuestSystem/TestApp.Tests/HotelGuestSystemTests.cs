using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestApp.Tests
{
    [TestFixture]
    public class HotelGuestSystemTests
    {
        [Test]
        public void Test_Constructor_CheckInitialEmptyGuestCollectionAndCount()
        {
            // Arrange
            List<string> expected = new List<string>();

            // Act
            HotelGuestSystem hotelGuestSystem = new HotelGuestSystem();
            int actual = hotelGuestSystem.GuestsCount;
            
            // Assert
            Assert.AreEqual(expected.Count, actual);
        }

        [Test]
        public void Test_RegisterGuest_ValidGuestName_AddNewGuest()
        {
            // Arrange
            string firstGuest = "Ivan";
            string secondGuest = "Petko";
            string thirdGuest = "Simeon";
            List<string> expected = new List<string>()
            {
                firstGuest,
                secondGuest,
                thirdGuest
            };

            // Act
            HotelGuestSystem hotelGuestSystem = new HotelGuestSystem();
            hotelGuestSystem.RegisterGuest(firstGuest);
            hotelGuestSystem.RegisterGuest(secondGuest);
            hotelGuestSystem.RegisterGuest(thirdGuest);
            List<string> actualList = hotelGuestSystem.GetAllGuests();
            int actual = hotelGuestSystem.GuestsCount;

            // Assert
            Assert.AreEqual(expected.Count, actual);
            Assert.AreEqual(expected[0], actualList[0]);
            Assert.AreEqual(expected[1], actualList[1]);
            Assert.AreEqual(expected[2], actualList[2]);
        }

        [Test]
        public void Test_RegisterGuest_NullOrEmptyGuestName_ThrowsArgumentException()
        {
            // Arrange
            string input = "";

            // Act
            HotelGuestSystem hotelGuestSystem = new HotelGuestSystem();

            // Assert
            Assert.Throws<ArgumentException>(() => hotelGuestSystem.RegisterGuest(input));
        }

        [Test]
        public void Test_RemoveGuest_ValidGuestName_RemoveFirstGuestName()
        {
            // Arrange
            string firstGuest = "Ivan";
            string secondGuest = "Petko";
            string thirdGuest = "Simeon";
            List<string> expected = new List<string>()
            {
                secondGuest,
                thirdGuest
            };

            // Act
            HotelGuestSystem hotelGuestSystem = new HotelGuestSystem();
            hotelGuestSystem.RegisterGuest(firstGuest);
            hotelGuestSystem.RegisterGuest(secondGuest);
            hotelGuestSystem.RegisterGuest(thirdGuest);
            hotelGuestSystem.RemoveGuest(firstGuest);
            List<string> actualList = hotelGuestSystem.GetAllGuests();
            int actual = hotelGuestSystem.GuestsCount;

            // Assert
            Assert.AreEqual(expected.Count, actual);
            Assert.AreEqual(expected[0], actualList[0]);
            Assert.AreEqual(expected[1], actualList[1]);
        }

        [Test]
        public void Test_RemoveGuest_NullOrEmptyGuestName_ThrowsArgumentException()
        {
            // Arrange
            string input = "";

            // Act
            HotelGuestSystem hotelGuestSystem = new HotelGuestSystem();

            // Assert
            Assert.Throws<ArgumentException>(() => hotelGuestSystem.RemoveGuest(input));
        }

        [Test]
        public void Test_GetAllGuests_RegisteredAndRemovedGuests_ReturnsExpectedGuestCollection()
        {
            // Arrange
            string firstGuest = "Ivan";
            string secondGuest = "Petko";
            string thirdGuest = "Simeon";
            List<string> expected = new List<string>()
            {
                firstGuest,
                thirdGuest
            };

            // Act
            HotelGuestSystem hotelGuestSystem = new HotelGuestSystem();
            hotelGuestSystem.RegisterGuest(firstGuest);
            hotelGuestSystem.RegisterGuest(secondGuest);
            hotelGuestSystem.RegisterGuest(thirdGuest);
            hotelGuestSystem.RemoveGuest(secondGuest);
            hotelGuestSystem.RemoveGuest(thirdGuest);
            hotelGuestSystem.RegisterGuest(thirdGuest);
            List<string> actualList = hotelGuestSystem.GetAllGuests();
            int actual= hotelGuestSystem.GuestsCount;

            // Assert
            Assert.AreEqual(expected.Count, actual);
            Assert.AreEqual(expected[0], actualList[0]);
            Assert.AreEqual(expected[1], actualList[1]);
        }
    }
}

