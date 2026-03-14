using System;
using OpenQA.Selenium;
using saucedemo_ui_automation.Pages.common;
using saucedemo_ui_automation.Pages.Products;

namespace saucedemo_ui_automation.Pages.Ordering
{
	public class ProductsPage : BasePage
	{

		private readonly By _productsContainer = By.Id("inventory_container");
		private String _rootProductXpath = "//*[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item']";

		public ProductsPage(IWebDriver driver) : base(driver)
		{
		}

		public void waitUntilProductsPageIsLoaded()
		{
			WaitUntilElementVisible(_productsContainer);
		}

        public ProductCardModule GetProductCard(string productName)
        {
            IWebElement root = _driver.FindElement(By.XPath(_rootProductXpath.Replace("{productName}", productName)));
            return new ProductCardModule(_driver, root);
        }

		public CartBadgeModule GetCartBadgeModule()
		{
			return new CartBadgeModule(_driver);
		}
    }
}

