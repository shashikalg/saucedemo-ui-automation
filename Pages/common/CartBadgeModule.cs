using System;
using OpenQA.Selenium;

namespace saucedemo_ui_automation.Pages.common
{
    public class CartBadgeModule : BasePage
    {
        private readonly By _spnCartText = By.XPath(".//*[@data-test='shopping-cart-badge']");

        public CartBadgeModule(IWebDriver driver) : base(driver)
        {
        }

        public int GetNoOfProductsInCart()
        {
            var elements = _driver.FindElements(_spnCartText);
            if (elements.Count > 0)
            {
                return int.Parse(elements[0].Text);
            }
            return 0;
        }

        public void ClickOnCartBadge()
        {
            _driver.FindElement(_spnCartText).Click();
        }
    }
}

