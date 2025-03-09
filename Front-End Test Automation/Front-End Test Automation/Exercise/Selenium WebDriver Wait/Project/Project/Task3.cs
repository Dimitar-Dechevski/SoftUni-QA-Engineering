using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Project
{
    public class Task3
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test, Order(1)]
        public void HandleMultipleWindows()
        {
            driver.FindElement(By.XPath("//a[text()=\"Click Here\"]")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            Assert.That(windowHandles.Count, Is.EqualTo(2));

            driver.SwitchTo().Window(windowHandles[1]);

            var newWindowTitle = driver.FindElement(By.XPath("//h3"));

            Assert.That(newWindowTitle.Text, Is.EqualTo("New Window"));

            driver.SwitchTo().Window(windowHandles[0]);
        }

        [Test, Order(2)]
        public void HandleNoSuchWindowException()
        {
            driver.FindElement(By.XPath("//a[text()=\"Click Here\"]")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            Assert.That(windowHandles.Count, Is.EqualTo(2));

            driver.SwitchTo().Window(windowHandles[1]);

            driver.Close();

            try
            {
                driver.SwitchTo().Window(windowHandles[1]);
            }
            catch (NoSuchWindowException ex)
            {
                Assert.Pass("Window was closed");
            }
            finally
            {
                driver.SwitchTo().Window(windowHandles[0]);
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
