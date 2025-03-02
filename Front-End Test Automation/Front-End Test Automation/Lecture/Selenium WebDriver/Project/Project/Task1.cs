using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task1
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
            driver.Navigate().GoToUrl("https://www.wikipedia.org/");
            var mainPageTitle = driver.Title;
            Console.WriteLine($"Main page title: {mainPageTitle}");
            Assert.That(mainPageTitle, Is.EqualTo("Wikipedia"));

            var searchBox = driver.FindElement(By.Id("searchInput"));
            searchBox.Click();
            searchBox.SendKeys("Quality Assurance" + Keys.Enter);
            var searchPageTitle = driver.Title;
            Console.WriteLine($"Search page title: {searchPageTitle}");
            Assert.That(searchPageTitle, Is.EqualTo("Quality assurance - Wikipedia"));
        }
    }
}
