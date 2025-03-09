using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Project
{
    public class Task5
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://codepen.io/pervillalva/full/abPoNLd");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test, Order(1)]
        public void TestIFrameByIndex()
        {
            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

            driver.FindElement(By.XPath("//button[@class=\"dropbtn\"]"));

            var dropdownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class=\"dropdown-content\"]//a")));

            foreach (var dropdownOption in dropdownOptions)
            {
                Console.WriteLine(dropdownOption.Text);
                Assert.That(dropdownOption.Displayed, Is.True);
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test, Order(2)]
        public void TestIFrameByID()
        {
            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("result")));

            driver.FindElement(By.XPath("//button[@class=\"dropbtn\"]"));

            var dropdownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class=\"dropdown-content\"]//a")));

            foreach (var dropdownOption in dropdownOptions)
            {
                Console.WriteLine(dropdownOption.Text);
                Assert.That(dropdownOption.Displayed, Is.True);
            }

            driver.SwitchTo().DefaultContent();
        }

        [Test, Order(3)]
        public void TestIFrameByWebElement()
        {
            driver.Navigate().Refresh();

            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[@class=\"result-iframe\"]")));

            driver.FindElement(By.XPath("//button[@class=\"dropbtn\"]"));

            var dropdownOptions = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class=\"dropdown-content\"]//a")));

            foreach (var dropdownOption in dropdownOptions)
            {
                Console.WriteLine(dropdownOption.Text);
                Assert.That(dropdownOption.Displayed, Is.True);
            }

            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
