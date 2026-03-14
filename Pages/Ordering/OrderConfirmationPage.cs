using System;
using OpenQA.Selenium;

namespace saucedemo_ui_automation.Pages.Ordering
{
	public class OrderConfirmationPage: BasePage
	{

		private By _lblHeader = By.XPath(".//*[@data-test='complete-header']");
		private By checkoutCompleteContainer = By.Id("checkout_complete_container");
		private By _btnBackToHome = By.Id("back-to-products");

		public OrderConfirmationPage(IWebDriver driver):base(driver)
		{
		}

		public void WaitUntilOrderConfirmationPageDisplayed()
		{
			WaitUntilElementVisible(checkoutCompleteContainer);
		}

		public String GetOrderCompletionHeader()
		{
			return _driver.FindElement(_lblHeader).Text;
		}

		public void ClickOnBackToHomeButton()
		{
			_driver.FindElement(_btnBackToHome).Click();
		}
	}
}

