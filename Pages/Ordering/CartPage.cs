using System;
using OpenQA.Selenium;
using saucedemo_ui_automation.Models;
using saucedemo_ui_automation.Pages.Products;

namespace saucedemo_ui_automation.Pages.Ordering
{
    public class CartPage : BasePage
    {
        private By _productRow = By.XPath(".//*[@data-test='inventory-item']");
        private By _cartContainer = By.Id("cart_contents_container");
        private By _btnCheckout = By.Id("checkout");

        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitUntilCartPageIsLoaded()
        {
            WaitUntilElementVisible(_cartContainer);
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

        public void ClickOnCheckoutButton()
        {
            _driver.FindElement(_btnCheckout).Click();
        }
    }
}

