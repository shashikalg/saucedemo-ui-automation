using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace saucedemo_ui_automation.Tests
{
    public class TestBase
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void SetupTests()
        {
            _driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDownTests()
        {
            _driver.Quit();
        }
    }
}
