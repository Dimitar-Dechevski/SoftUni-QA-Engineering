using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://practice.bpbonline.com/");
        }

        [Test]
        public void Test()
        {
            driver.FindElement(By.XPath("//span[text()=\"My Account\"]")).Click();
            driver.FindElement(By.XPath("//span[text()=\"Continue\"]")).Click();
            driver.FindElement(By.XPath("//input[@value=\"m\"]")).Click();
            driver.FindElement(By.XPath("//input[@name=\"firstname\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@name=\"lastname\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@class=\"hasDatepicker\"]")).SendKeys("03/15/1995" + Keys.Enter);

            Random random = new Random();
            int randomNumber = random.Next(999, 9999);
            string email = $"email_{randomNumber}@gmail.com";
            driver.FindElement(By.XPath("//input[@name=\"email_address\"]")).SendKeys(email);
            driver.FindElement(By.XPath("//input[@name=\"company\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@name=\"street_address\"]")).SendKeys("random");
            driver.FindElement(By.XPath("//input[@name=\"suburb\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@name=\"postcode\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@name=\"city\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@name=\"state\"]")).SendKeys("test");

            SelectElement selectedCountry = new SelectElement(driver.FindElement(By.XPath("//select[@name=\"country\"]")));
            selectedCountry.SelectByText("Croatia");
            driver.FindElement(By.XPath("//input[@name=\"telephone\"]")).SendKeys("test");
            driver.FindElement(By.XPath("//input[@name=\"newsletter\"]")).Click();
            driver.FindElement(By.XPath("//input[@name=\"password\"]")).SendKeys("password");
            driver.FindElement(By.XPath("//input[@name=\"confirmation\"]")).SendKeys("password");
            driver.FindElement(By.XPath("//span[text()=\"Continue\"]")).Click();

            Assert.That(driver.FindElement(By.XPath("//h1")).Text, Is.EqualTo("Your Account Has Been Created!"));
            driver.FindElement(By.XPath("//span[text()=\"Log Off\"]")).Click();
            driver.FindElement(By.XPath("//span[text()=\"Continue\"]")).Click();
            Console.WriteLine($"User Account Created with email: {email}");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
