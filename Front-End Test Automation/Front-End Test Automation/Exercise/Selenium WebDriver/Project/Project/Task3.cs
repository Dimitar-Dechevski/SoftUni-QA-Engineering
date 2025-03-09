using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace Project
{
    public class Task3
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
            string filePath = Directory.GetCurrentDirectory() + "/manufacturer.txt";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            SelectElement manufacturerDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name=\"manufacturers_id\"]")));

            IList<IWebElement> allManufacturersOptions = manufacturerDropdown.Options;
            List<string> manufacturersNames = new List<string>();

            foreach (var manufacturerElement in allManufacturersOptions)
            {
                manufacturersNames.Add(manufacturerElement.Text);
            }
            manufacturersNames.RemoveAt(0);

            foreach (var manufacturer in manufacturersNames)
            {
                manufacturerDropdown.SelectByText(manufacturer);
                manufacturerDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name=\"manufacturers_id\"]")));

                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(filePath, $"The manufacturer {manufacturer} has no products\n");
                }
                else
                {
                    IWebElement table = driver.FindElement(By.XPath("//table[@class=\"productListingData\"]"));

                    File.AppendAllText(filePath, $"\n\nThe manufacturer {manufacturer} products are listed--\n");
                    ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.XPath("//tbody//tr"));

                    foreach (var tableRow in tableRows)
                    {
                        File.AppendAllText(filePath, tableRow.Text + "\n");
                    }
                }
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
