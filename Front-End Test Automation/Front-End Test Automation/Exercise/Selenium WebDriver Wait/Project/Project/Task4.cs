using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task4
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/javascript_alerts");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test, Order(1)]
        public void HandleBasicAlert()
        {
            driver.FindElement(By.XPath("//button[text()=\"Click for JS Alert\"]")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"));

            alert.Accept();

            var result = driver.FindElement(By.XPath("//p[@id=\"result\"]"));
            Assert.That(result.Text, Is.EqualTo("You successfully clicked an alert"));
        }

        [Test, Order(2)]
        public void HandleConfirmAlert()
        {
            //
            driver.FindElement(By.XPath("//button[text()=\"Click for JS Confirm\"]")).Click();

            IAlert acceptedAlert = driver.SwitchTo().Alert();

            Assert.That(acceptedAlert.Text, Is.EqualTo("I am a JS Confirm"));

            acceptedAlert.Accept();

            var acceptedResult = driver.FindElement(By.XPath("//p[@id=\"result\"]"));
            Assert.That(acceptedResult.Text, Is.EqualTo("You clicked: Ok"));

            //
            driver.FindElement(By.XPath("//button[text()=\"Click for JS Confirm\"]")).Click();

            IAlert dismissedAlert = driver.SwitchTo().Alert();

            Assert.That(dismissedAlert.Text, Is.EqualTo("I am a JS Confirm"));

            dismissedAlert.Dismiss();

            var dismissedResult = driver.FindElement(By.XPath("//p[@id=\"result\"]"));
            Assert.That(dismissedResult.Text, Is.EqualTo("You clicked: Cancel"));
        }

        [Test, Order(3)]
        public void HandlePromptAlert()
        {
            //
            driver.FindElement(By.XPath("//button[text()=\"Click for JS Prompt\"]")).Click();

            IAlert alertWithInput = driver.SwitchTo().Alert();

            Assert.That(alertWithInput.Text, Is.EqualTo("I am a JS prompt"));

            alertWithInput.SendKeys("test");
            alertWithInput.Accept();

            var resultWithInput = driver.FindElement(By.XPath("//p[@id=\"result\"]"));
            Assert.That(resultWithInput.Text, Is.EqualTo("You entered: test"));

            //
            driver.FindElement(By.XPath("//button[text()=\"Click for JS Prompt\"]")).Click();

            IAlert alertWithoutInput = driver.SwitchTo().Alert();

            Assert.That(alertWithoutInput.Text, Is.EqualTo("I am a JS prompt"));

            alertWithoutInput.SendKeys("");
            alertWithoutInput.Accept();

            var resultWithoutInput = driver.FindElement(By.XPath("//p[@id=\"result\"]"));
            Assert.That(resultWithoutInput.Text, Is.EqualTo("You entered:"));

            //
            driver.FindElement(By.XPath("//button[text()=\"Click for JS Prompt\"]")).Click();

            IAlert dismissedAlert = driver.SwitchTo().Alert();

            Assert.That(dismissedAlert.Text, Is.EqualTo("I am a JS prompt"));

            dismissedAlert.Dismiss();

            var dismissedResult = driver.FindElement(By.XPath("//p[@id=\"result\"]"));
            Assert.That(dismissedResult.Text, Is.EqualTo("You entered: null"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
