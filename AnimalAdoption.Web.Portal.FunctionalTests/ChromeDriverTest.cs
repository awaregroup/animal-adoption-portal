using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AnimalAdoption.Web.Portal.FunctionalTests
{
    [TestClass]
    public class ChromeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from https://chromedriver.chromium.org/downloads
        // to install Chrome WebDriver.

        private ChromeDriver _driver;

        [TestInitialize]
        public void ChromeDriverInitialize()
        {
            // Initialize chrome driver 
            var options = new ChromeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new ChromeDriver(options);
        }

        [TestMethod]
        public void HomePage_LoadPage_LoadsAnimalsIn10Seconds()
        {
            // Remember to set this in the release pipeline
            var url = Environment.GetEnvironmentVariable("ANIMAL_ADOPTION_FUNCTIONAL_TEST_PATH") ?? "http://localhost:9000";            
            _driver.Url = url;
            var xPathToCheck = "/html/body/div/main/div/table/tbody/tr[1]/td[2]";
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var returnedAnimal = wait.Until((d) =>
            {
                return d.FindElement(By.XPath(xPathToCheck));
            });
            Assert.IsNotNull(returnedAnimal?.Text);
        }

        [TestCleanup]
        public void ChromeDriverCleanup()
        {
            if (_driver != null) {
                _driver.Quit();
            }
        }
    }
}
