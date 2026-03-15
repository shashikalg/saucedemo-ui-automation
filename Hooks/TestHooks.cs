using OpenQA.Selenium;
using Reqnroll;
using saucedemo_ui_automation.Factories;
using saucedemo_ui_automation.Functions.Login;
using saucedemo_ui_automation.Functions.Products;

namespace saucedemo_ui_automation.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public TestHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = WebDriverFactory.CreateDriver();

            _scenarioContext.Set(driver, "WebDriver");
            _scenarioContext.Set(new LoginFunctions(driver), "LoginFunctions");
            _scenarioContext.Set(new OrderFunctions(driver), "OrderFunctions");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TryGetValue("WebDriver", out IWebDriver driver))
            {
                driver.Quit();
            }
        }
    }
}
