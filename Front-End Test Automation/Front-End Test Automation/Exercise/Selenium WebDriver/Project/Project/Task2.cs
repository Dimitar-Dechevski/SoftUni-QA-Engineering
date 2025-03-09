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
    public class Task2
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
            string filePath = System.IO.Directory.GetCurrentDirectory() + "/productInformation.csv";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            IWebElement productTable = driver.FindElement(By.XPath("//table"));
            ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody//tr"));

            foreach (var tableRow in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableData = tableRow.FindElements(By.XPath("td"));

                foreach (var currentTableData in tableData)
                {
                    string productData = currentTableData.Text;
                    string[] productInfo = productData.Split("\n");
                    string product = productInfo[0].Trim() + "," + productInfo[1].Trim() + "\n";

                    File.AppendAllText(filePath, product);
                }
            }

            Assert.That(File.Exists(filePath), Is.True, "CSV file was not created.");
            Assert.That(new FileInfo(filePath).Length, Is.GreaterThan(0), "CSV file is empty.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
