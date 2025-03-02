using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class Task3
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
            var lastName = driver.FindElement(By.Id("lname"));
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Vega"));

            var checkbox = driver.FindElement(By.Name("newsletter"));
            Assert.That(checkbox.Selected, Is.False);

            var hyperlink = driver.FindElement(By.TagName("a"));
            Assert.That(hyperlink.Text, Is.EqualTo("Softuni Official Page"));

            var informationElement = driver.FindElement(By.ClassName("information"));
            Assert.That(informationElement.GetCssValue("background-color"), Is.EqualTo("rgba(255, 255, 255, 1)"));

            var hyperlinkByLinkText = driver.FindElement(By.LinkText("Softuni Official Page"));
            Assert.That(hyperlinkByLinkText.GetDomAttribute("href"), Is.Not.Null);

            var hyperlinkByPartialLinkText = driver.FindElement(By.PartialLinkText("Official Page"));
            Assert.That(hyperlinkByPartialLinkText.Text.Contains("Official Page"));

            var firstNameByID = driver.FindElement(By.CssSelector("#fname"));
            Assert.That(firstNameByID.GetAttribute("value"), Is.EqualTo("Vincent"));

            var firstNameByName = driver.FindElement(By.CssSelector("input[name=\"fname\"]"));
            Assert.That(firstNameByName.GetAttribute("value"), Is.EqualTo("Vincent"));

            var button = driver.FindElement(By.CssSelector("input[class*=\"button\"]"));
            Assert.That(button.GetAttribute("value"), Is.EqualTo("Submit"));

            var phoneNumberByCSS = driver.FindElement(By.CssSelector("div.additional-info > p > input[type=\"text\"]"));
            Assert.That(phoneNumberByCSS.Displayed, Is.True);

            var phoneNumberBySpecificCSS = driver.FindElement(By.CssSelector("form div.additional-info input[type=\"text\"]"));
            Assert.That(phoneNumberBySpecificCSS.Displayed, Is.True);

            var radioButtonByAbsoluteXPath = driver.FindElement(By.XPath("/html/body/form/input[1]"));
            Assert.That(radioButtonByAbsoluteXPath.GetAttribute("value"), Is.EqualTo("m"));

            var radioButtonByRelativeXPath = driver.FindElement(By.XPath("//input[@value=\"m\"]"));
            Assert.That(radioButtonByRelativeXPath.GetAttribute("value"), Is.EqualTo("m"));

            var lastNameByRelativeXPath = driver.FindElement(By.XPath("//input[@name=\"lname\"]"));
            Assert.That(lastNameByRelativeXPath.GetAttribute("value"), Is.EqualTo("Vega"));

            var checkboxByRelativeXPath = driver.FindElement(By.XPath("//input[@type=\"checkbox\"]"));
            Assert.That(lastNameByRelativeXPath.GetDomAttribute("type"), Is.Not.Null);

            var buttonByRelativeXPath = driver.FindElement(By.XPath("//input[@class=\"button\"]"));
            Assert.That(buttonByRelativeXPath.GetAttribute("value"), Is.EqualTo("Submit"));

            var phoneNumberByRelativeXPath = driver.FindElement(By.XPath("//div[@class=\"additional-info\"]//input[@type=\"text\"]"));
            Assert.That(phoneNumberByRelativeXPath.Displayed, Is.True);
        }
    }
}
