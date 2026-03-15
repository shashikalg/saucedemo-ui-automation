using System;
using OpenQA.Selenium;
using saucedemo_ui_automation.Models;
using saucedemo_ui_automation.Pages.Products;

namespace saucedemo_ui_automation.Pages.Ordering
{
    public class CheckoutOverviewPage : BasePage
    {
        private By _lblItemTotal = By.XPath("//*[@data-test='subtotal-label']");
        private By _summaryContainer = By.Id("checkout_summary_container");
        private By _productRow = By.XPath("//*[@data-test='inventory-item']");
        private By _btnFinish = By.Id("finish");

        public CheckoutOverviewPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitUntilCheckoutOverViewPageDisplayed()
        {
            WaitUntilElementVisible(_summaryContainer);
        }

        public String GetItemTotal()
        {
            return _driver.FindElement(_lblItemTotal).Text;
        }

        public void ClickOnFinishButton()
        {
            _driver.FindElement(_btnFinish).Click();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            IReadOnlyCollection<IWebElement> productElements = _driver.FindElements(_productRow);

            foreach (IWebElement productElement in productElements)
            {
                ProductCardModule productCard = new ProductCardModule(_driver, productElement);
                products.Add(productCard.ToProduct());
            }

            return products;
        }
    }
}

