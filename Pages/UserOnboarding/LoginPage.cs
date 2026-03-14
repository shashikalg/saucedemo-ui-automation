using System;
using OpenQA.Selenium;

namespace saucedemo_ui_automation.Pages.UserOnboarding
{
	public class LoginPage : BasePage
	{
		private readonly By _lblLoginLogo = By.ClassName("login_logo");
		private readonly By _txtUserName = By.Id("user-name");
		private readonly By _txtPassword = By.Id("password");
        private readonly By _btnLogin = By.Id("login-button");


        public LoginPage(IWebDriver driver) : base(driver)
        {
		}

		public void WaitTillLoginPageIsLoaded()
		{
            WaitUntilElementVisible(_lblLoginLogo);
        }

		public void EnterUserName(String username)
		{
			_driver.FindElement(_txtUserName).SendKeys(username);
		}

        public void EnterPassword(String password)
        {
			_driver.FindElement(_txtPassword).SendKeys(password);
        }

		public void ClickLogin()
		{
			_driver.FindElement(_btnLogin).Click();
		}
    }
}

