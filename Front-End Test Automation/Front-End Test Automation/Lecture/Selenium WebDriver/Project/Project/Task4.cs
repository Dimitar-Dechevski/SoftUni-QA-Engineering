using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            driver.Navigate().GoToUrl("D:\\QA\\Front-End Test Automation\\Front-End Test Automation\\Lecture\\Selenium WebDriver\\SimpleForm\\Locators.html");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

        [Test]
        public void Test()
        {
            var title = driver.FindElement(By.XPath("//h2"));
            Assert.That(title.Text, Is.EqualTo("Contact Form"));

            var radioButton = driver.FindElement(By.XPath("//input[@value=\"m\"]"));
            radioButton.Click();
            Assert.That(radioButton.Selected, Is.True);

            var firstName = driver.FindElement(By.XPath("//input[@id=\"fname\"]"));
            firstName.Clear();
            firstName.SendKeys("Butch");
            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Butch"));

            var lastName = driver.FindElement(By.XPath("//input[@id=\"lname\"]"));
            lastName.Clear();
            lastName.SendKeys("Coolidge");
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Coolidge"));

            var section = driver.FindElement(By.XPath("//h3"));
            Assert.That(section.Displayed, Is.True);

            var phoneNumber = driver.FindElement(By.XPath("//div[@class=\"additional-info\"]//input[@type=\"text\"]"));
            phoneNumber.SendKeys("0888999777");
            Assert.That(phoneNumber.GetAttribute("value"), Is.EqualTo("0888999777"));

            var checkbox = driver.FindElement(By.XPath("//input[@name=\"newsletter\"]"));
            checkbox.Click();
            Assert.That(checkbox.Selected, Is.True);

            driver.FindElement(By.XPath("//input[@class=\"button\"]")).Click();

            var message = driver.FindElement(By.XPath("//h1"));
            Assert.That(message.Text, Is.EqualTo("Thank You!"));
        }
    }
}
