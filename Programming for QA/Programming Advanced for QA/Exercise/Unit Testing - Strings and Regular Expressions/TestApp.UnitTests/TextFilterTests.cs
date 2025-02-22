using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWord = new string[] { "VW" };
        string text = "Mercedes-Benz is a prestigious German automobile manufacturer known for producing luxury cars, trucks, and buses. Mercedes-Benz is famous for its groundbreaking innovations, including the development of the first modern automobile and advanced driver-assistance systems. Mercedes-Benz is renowned for its commitment to luxury, performance, and sophisticated design in every vehicle it produces.";
        string expected = "Mercedes-Benz is a prestigious German automobile manufacturer known for producing luxury cars, trucks, and buses. Mercedes-Benz is famous for its groundbreaking innovations, including the development of the first modern automobile and advanced driver-assistance systems. Mercedes-Benz is renowned for its commitment to luxury, performance, and sophisticated design in every vehicle it produces.";

        // Act
        string actual = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWord = new string[] { "Škoda" };
        string text = "Škoda is a Czech automobile manufacturer known for producing affordable and reliable cars for a wide range of customers. Škoda has made significant strides in automotive technology with features like the Virtual Cockpit and advanced driver assistance systems. Škoda’s design philosophy focuses on creating practical, high-quality vehicles that offer excellent value for money.";
        string expected = "***** is a Czech automobile manufacturer known for producing affordable and reliable cars for a wide range of customers. ***** has made significant strides in automotive technology with features like the Virtual Cockpit and advanced driver assistance systems. *****’s design philosophy focuses on creating practical, high-quality vehicles that offer excellent value for money.";

        // Act
        string actual = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWord = Array.Empty<string>();
        string text = "Audi is a leading German luxury car manufacturer known for its high-quality vehicles and advanced technology. Audi is renowned for pioneering innovations like the Quattro all-wheel-drive system and the e-tron electric vehicle lineup. Audi's design philosophy combines sleek aesthetics with cutting-edge engineering to deliver both luxury and performance.";
        string expected = "Audi is a leading German luxury car manufacturer known for its high-quality vehicles and advanced technology. Audi is renowned for pioneering innovations like the Quattro all-wheel-drive system and the e-tron electric vehicle lineup. Audi's design philosophy combines sleek aesthetics with cutting-edge engineering to deliver both luxury and performance.";

        // Act
        string actual = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] bannedWord = new string[] { " " };
        string text = "Starbucks is a global coffeehouse chain known for its premium coffee, specialty beverages, and inviting store atmosphere.";
        string expected = "Starbucks*is*a*global*coffeehouse*chain*known*for*its*premium*coffee,*specialty*beverages,*and*inviting*store*atmosphere.";

        // Act
        string actual = TextFilter.Filter(bannedWord, text);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
