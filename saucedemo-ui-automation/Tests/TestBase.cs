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
            var options = new ChromeOptions();
            options.AddArgument("--incognito");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            _driver = new ChromeDriver(options);
        }

        [OneTimeTearDown]
        public void TearDownTests()
        {
            _driver.Quit();
        }
    }
}
