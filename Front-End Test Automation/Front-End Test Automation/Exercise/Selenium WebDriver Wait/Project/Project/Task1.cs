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
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test, Order(1)]
        public void SearchProduct_Keyboard_ShouldAddToCart()
        {
            driver.FindElement(By.XPath("//input[@name=\"keywords\"]")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@alt=\"Quick Find\"]")).Click();

            var product = driver.FindElement(By.XPath("//table[@class=\"productListingData\"]//a[text()=\"Microsoft Internet Keyboard PS/2\"]"));
            Assert.That(product.Displayed, Is.True);

            driver.FindElement(By.XPath("//span[text()=\"Buy Now\"]")).Click();

            var cartTitle = driver.FindElement(By.XPath("//h1"));
            Assert.That(cartTitle.Text, Is.EqualTo("What's In My Cart?"));

            var productInCart = driver.FindElement(By.XPath("//div[@class=\"contentContainer\"]//strong[text()=\"Microsoft Internet Keyboard PS/2\"]"));
            Assert.That(productInCart.Text, Is.EqualTo("Microsoft Internet Keyboard PS/2"));
        }

        [Test, Order(2)]
        public void SearchProduct_Junk_ShouldThrowNoSuchElementException()
        {
            driver.FindElement(By.XPath("//input[@name=\"keywords\"]")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@alt=\"Quick Find\"]")).Click();

            var noProductMessage = driver.FindElement(By.XPath("//div[@class=\"contentContainer\"]//p"));
            Assert.That(noProductMessage.Text, Is.EqualTo("There is no product that matches the search criteria."));

            try
            {
                driver.FindElement(By.XPath("//span[text()=\"Buy Now\"]")).Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass("Buy button was not present");
            }

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
