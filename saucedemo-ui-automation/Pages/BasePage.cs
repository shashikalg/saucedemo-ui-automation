using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace saucedemo_ui_automation.Pages
{
	public class BasePage
	{
		protected IWebDriver driver;
		private readonly int DefaultTimeoutInSec = 5;

		public BasePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void NavigateTo(String url)
		{
			driver.Navigate().GoToUrl(url);
		}

        public IWebElement WaitUntilElementVisible(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(DefaultTimeoutInSec));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public IWebElement WaitUntilElementVisible(By locator, int timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}

