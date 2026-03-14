using System;
using OpenQA.Selenium;

namespace saucedemo_ui_automation.Pages.Ordering
{
	public class CheckoutPage: BasePage
	{

		private By _checkoutContainer = By.Id("checkout_info_container");
		private By _txtFirstName = By.Id("first-name");
        private By _txtLastName = By.Id("last-name");
        private By _txtZipCode = By.Id("postal-code");
        private By _btnContinue = By.Id("continue");

        public CheckoutPage(IWebDriver driver): base(driver)
		{
		}

		public void WaitTillCheckoutPageIsLoaded()
		{
            WaitUntilElementVisible(_checkoutContainer);
        }

		public void EnterFirstName(String firstName)
		{
			_driver.FindElement(_txtFirstName).SendKeys(firstName);
		}

        public void EnterLastName(String lastName)
        {
            _driver.FindElement(_txtLastName).SendKeys(lastName);
        }

        public void EnterZipCode(String zipCode)
        {
            _driver.FindElement(_txtZipCode).SendKeys(zipCode);
        }

        public void ClickOnContinueButton()
        {
            _driver.FindElement(_btnContinue).Click();
        }
    }
}

