using OpenQA.Selenium;
using saucedemo_ui_automation.Pages.Ordering;
using saucedemo_ui_automation.Pages.UserOnboarding;

namespace saucedemo_ui_automation.Functions.Login
{
	public class LoginFunctions : FunctionBase
	{
		private LoginPage _loginPage;
        private ProductsPage _productsPage;

		public LoginFunctions(IWebDriver driver) : base(driver)
        {
            _loginPage = new LoginPage(driver);
            _productsPage = new ProductsPage(driver);
        }

		public void LogInWithValidUser(String username, String password)
		{
            _loginPage.WaitTillLoginPageIsLoaded();
            _loginPage.EnterUserName(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();
            _productsPage.waitUntilProductsPageIsLoaded();
        }
	}
}

