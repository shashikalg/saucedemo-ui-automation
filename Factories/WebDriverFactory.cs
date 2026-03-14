using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using saucedemo_ui_automation.Constants;

namespace saucedemo_ui_automation.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            return FrameworkConfig.Browser switch
            {
                Common.BrowserType.Chrome => CreateChromeDriver(),
                _ => throw new ArgumentException($"Unsupported browser: {FrameworkConfig.Browser}")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--incognito");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            if (FrameworkConfig.HeadlessMode)
            {
                options.AddArgument("--headless=new");
            }

            return new ChromeDriver(options);
        }
    }
}