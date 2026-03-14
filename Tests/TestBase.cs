using OpenQA.Selenium;
using saucedemo_ui_automation.Factories;

namespace saucedemo_ui_automation.Tests
{
    public class TestBase
    {
        protected IWebDriver _driver;

        [OneTimeSetUp]
        public void SetupTests()
        {
            _driver = WebDriverFactory.CreateDriver();
        }

        [OneTimeTearDown]
        public void TearDownTests()
        {
            _driver.Quit();
        }
    }
}
