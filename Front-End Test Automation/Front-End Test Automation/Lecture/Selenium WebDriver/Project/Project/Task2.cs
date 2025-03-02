using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task2
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void Test()
        {
            driver.Navigate().GoToUrl("https://nakov.com");
            var mainPageTitle = driver.Title;
            Assert.That(mainPageTitle.Contains("Svetlin Nakov – Official Web Site"));
            Console.WriteLine($"Main page title: {mainPageTitle}");

            var searchButton = driver.FindElement(By.XPath("//a[@class=\"smoothScroll\"]"));
            Assert.That(searchButton.Text.Contains("SEARCH"));
            Console.WriteLine(searchButton.Text);

            searchButton.Click();
            var searchInput = driver.FindElement(By.XPath("//input[@class=\"s\"]"));
            var placeholderText = searchInput.GetAttribute("placeholder");
            Assert.That(placeholderText, Is.EqualTo("Search this site"));
            Console.WriteLine(placeholderText);
        }
    }
}
