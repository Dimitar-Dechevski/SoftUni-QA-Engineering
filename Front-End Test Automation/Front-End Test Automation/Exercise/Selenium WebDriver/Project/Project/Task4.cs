using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
        private IWebElement firstNumberInput;
        private IWebElement secondNumberInput;
        private IWebElement operationInput;
        private IWebElement result;
        private IWebElement calculateButton;
        private IWebElement resetButton;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("D:\\QA\\Front-End Test Automation\\Front-End Test Automation\\Exercise\\Selenium WebDriver\\number-calculator/number-calculator.html");

            firstNumberInput = driver.FindElement(By.XPath("//input[@id=\"number1\"]"));
            secondNumberInput = driver.FindElement(By.XPath("//input[@id=\"number2\"]"));
            operationInput = driver.FindElement(By.XPath("//select[@id=\"operation\"]"));
            result = driver.FindElement(By.XPath("//div[@id=\"result\"]"));
            calculateButton = driver.FindElement(By.XPath("//input[@id=\"calcButton\"]"));
            resetButton = driver.FindElement(By.XPath("//input[@id=\"resetButton\"]"));
        }

        public void Calculate(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            resetButton.Click();

            if (!string.IsNullOrEmpty(firstNumber))
            {
                firstNumberInput.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                secondNumberInput.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(operationInput).SelectByText(operation);
            }

            calculateButton.Click();

            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }

        [TestCase("first number", "+ (sum)", "3", "Result: invalid input")]
        [TestCase("6", "+ (sum)", "second number", "Result: invalid input")]
        [TestCase("first number", "+ (sum)", "second number", "Result: invalid input")]
        [TestCase("", "+ (sum)", "3", "Result: invalid input")]
        [TestCase("6", "", "3", "Result: invalid operation")]
        [TestCase("6", "+ (sum)", "", "Result: invalid input")]
        [TestCase("", "+ (sum)", "", "Result: invalid input")]
        [TestCase("9", "+ (sum)", "3", "Result: 12")]
        [TestCase("9", "- (subtract)", "3", "Result: 6")]
        [TestCase("9", "* (multiply)", "3", "Result: 27")]
        [TestCase("9", "/ (divide)", "3", "Result: 3")]
        [TestCase("9", "/ (divide)", "0", "Result: Invalid Calculation")]
        [TestCase("-10.55", "+ (sum)", "4", "Result: -6.55")]
        [TestCase("10", "+ (sum)", "-4.38", "Result: 5.62")]
        [TestCase("-10.55", "+ (sum)", "-4.38", "Result: -14.93")]
        [TestCase("-10.55", "- (subtract)", "-4.38", "Result: -6.17")]
        [TestCase("-10.55", "* (multiply)", "-4.38", "Result: 46.209")]
        [TestCase("-10.55", "/ (divide)", "-4.38", "Result: 2.40867579909")]
        [TestCase("   8   ", "+ (sum)", "   -4.50   ", "Result: 3.5")]
        [TestCase("Infinity", "+ (sum)", "7", "Result: Infinity")]
        [TestCase("7", "+ (sum)", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "+ (sum)", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "+ (sum)", "8", "Result: Infinity")]
        [TestCase("Infinity", "- (subtract)", "8", "Result: Infinity")]
        [TestCase("Infinity", "* (multiply)", "8", "Result: Infinity")]
        [TestCase("Infinity", "/ (divide)", "8", "Result: Infinity")]
        [TestCase("8", "+ (sum)", "Infinity", "Result: Infinity")]
        [TestCase("8", "- (subtract)", "Infinity", "Result: -Infinity")]
        [TestCase("8", "* (multiply)", "Infinity", "Result: Infinity")]
        [TestCase("8", "/ (divide)", "Infinity", "Result: 0")]
        public void Test(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            Calculate(firstNumber, operation, secondNumber, expectedResult);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
