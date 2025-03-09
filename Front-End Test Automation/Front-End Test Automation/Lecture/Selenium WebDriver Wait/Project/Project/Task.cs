using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/dynamic.html");
        }

        [Test, Order(1)]
        public void AddBoxWithoutWaitsFails()
        {
            driver.FindElement(By.XPath("//input[@id=\"adder\"]")).Click();

            Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.XPath("//div[@id=\"box0\"]")));
        }

        [Test, Order(2)]
        public void RevealInputWithoutWaitsFail()
        {
            driver.FindElement(By.XPath("//input[@id=\"reveal\"]")).Click();

            IWebElement input = driver.FindElement(By.XPath("//input[@id=\"revealed\"]"));

            Assert.Throws<ElementNotInteractableException>(() => input.SendKeys("test"));
        }

        [Test, Order(3)]
        public void AddBoxWithThreadSleep()
        {
            driver.FindElement(By.XPath("//input[@id=\"adder\"]")).Click();
            Thread.Sleep(3000);

            IWebElement box = driver.FindElement(By.XPath("//div[@id=\"box0\"]"));

            Assert.That(box.Displayed, Is.True);
        }

        [Test, Order(4)]
        public void AddBoxWithImplicitWait()
        {
            driver.FindElement(By.XPath("//input[@id=\"adder\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement box = driver.FindElement(By.XPath("//div[@id=\"box0\"]"));

            Assert.That(box.Displayed, Is.True);
        }

        [Test, Order(5)]
        public void RevealInputWithImplicitWaits()
        {
            driver.FindElement(By.XPath("//input[@id=\"reveal\"]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement input = driver.FindElement(By.XPath("//input[@id=\"revealed\"]"));

            Assert.That(input.TagName, Is.EqualTo("input"));
        }

        [Test, Order(6)]
        public void RevealInputWithExplicitWaits()
        {
            driver.FindElement(By.XPath("//input[@id=\"reveal\"]")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            IWebElement input = driver.FindElement(By.XPath("//input[@id=\"revealed\"]"));
            wait.Until(drv => input.Displayed);
            input.SendKeys("test");

            Assert.That(input.GetAttribute("value"), Is.EqualTo("test"));
        }

        [Test, Order(7)]
        public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            driver.FindElement(By.XPath("//input[@id=\"adder\"]")).Click();

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(10);
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement box = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id=\"adder\"]")));

            Assert.That(box.Displayed, Is.True);
        }

        [Test, Order(8)]
        public void RevealInputWithCustomFluentWait()
        {
            IWebElement input = driver.FindElement(By.XPath("//input[@id=\"revealed\"]"));
            driver.FindElement(By.XPath("//input[@id=\"reveal\"]")).Click();

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver)
            {
                Timeout = TimeSpan.FromSeconds(5),
                PollingInterval = TimeSpan.FromMilliseconds(200)
            };
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(drv =>
            {
                input.SendKeys("test");
                return true;
            });

            Assert.That(input.TagName, Is.EqualTo("input"));
            Assert.That(input.GetAttribute("value"), Is.EqualTo("test"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
