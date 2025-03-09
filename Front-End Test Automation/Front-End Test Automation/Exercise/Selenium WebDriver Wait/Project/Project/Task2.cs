using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Project
{
    public class Task2
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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var product = wait.Until(drv => drv.FindElement(By.XPath("//table[@class=\"productListingData\"]//a[text()=\"Microsoft Internet Keyboard PS/2\"]")));
            Assert.That(product.Displayed, Is.True);

            var buyButton = wait.Until(drv => drv.FindElement(By.XPath("//span[text()=\"Buy Now\"]")));
            buyButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                var buyButton = wait.Until(drv => drv.FindElement(By.XPath("//span[text()=\"Buy Now\"]")));
                buyButton.Click();
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Pass("Buy button was not present");
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
