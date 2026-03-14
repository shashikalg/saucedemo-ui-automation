using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace saucedemo_ui_automation.Pages
{
	public class BasePage
	{
		protected IWebDriver _driver;
		private readonly int _defaultTimeoutInSec = 5;

		public BasePage(IWebDriver driver)
		{
			this._driver = driver;
		}

        public IWebElement WaitUntilElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_defaultTimeoutInSec));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitUntilElementVisible(By locator, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}

