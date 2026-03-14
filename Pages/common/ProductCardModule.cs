using System;
using OpenQA.Selenium;
using saucedemo_ui_automation.Models;

namespace saucedemo_ui_automation.Pages.Products
{
	public class ProductCardModule:BasePage
	{
        private readonly IWebElement _root;

        private By _lblPrice = By.XPath(".//*[@data-test='inventory-item-price']");
		private By _btnAddToCard = By.XPath(".//button[text()='Add to cart']");
        private By _btnRemove = By.XPath(".//button[text()='Remove']");
        private By _lblDescription = By.XPath(".//*[@data-test='inventory-item-desc']");
        private By _lblProductname = By.XPath(".//*[@data-test='inventory-item-name']");

        public ProductCardModule(IWebDriver driver, IWebElement rootElement):base(driver)
		{
            _root = rootElement;
		}

        public String GetProductPrice()
		{
			return _root.FindElement(_lblPrice).Text;
		}

        public String GetProductDescription()
        {
            return _root.FindElement(_lblDescription).Text;
        }

        public String GetProductName()
        {
            return _root.FindElement(_lblProductname).Text;
        }

        public Product ToProduct()
        {
            return new Product
            {
                Name = GetProductName(),
                Description = GetProductDescription(),
                Price = decimal.Parse(GetProductPrice().Replace("$", "").Trim())
            };
        }

        public void ClickAddToCart()
		{
            _root.FindElement(_btnAddToCard).Click();
        }

        public void ClickRemove()
        {
            _root.FindElement(_btnRemove).Click();
        }
    }
}

