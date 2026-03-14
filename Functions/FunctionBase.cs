using System;
using OpenQA.Selenium;

namespace saucedemo_ui_automation.Functions.Login
{
    public class FunctionBase
    {
        protected IWebDriver _driver;

        public FunctionBase(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo(String url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.FullScreen();
        }
    }
}

