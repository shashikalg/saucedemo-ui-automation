using System;
using System.Globalization;
using OpenQA.Selenium;
using saucedemo_ui_automation.Functions.Login;
using saucedemo_ui_automation.Models;
using saucedemo_ui_automation.Pages.Ordering;

namespace saucedemo_ui_automation.Functions.Products
{
    public class OrderFunctions : FunctionBase
    {
        ProductsPage productsPage;
        CartPage cartPage;
        CheckoutPage checkoutPage;
        CheckoutOverviewPage checkoutOverviewPage;
        OrderConfirmationPage orderConfirmationPage;

        public OrderFunctions(IWebDriver driver) : base(driver)
        {
            productsPage = new ProductsPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
            orderConfirmationPage = new OrderConfirmationPage(driver);
        }

        public Product AddProductToCart(String productName)
        {
            productsPage.GetProductCard(productName).ClickAddToCart();
            return productsPage.GetProductCard(productName).ToProduct();
        }

        public void NavigateToCart()
        {
            productsPage.GetCartBadgeModule().ClickOnCartBadge();
            cartPage.WaitUntilCartPageIsLoaded();
        }

        public void NavigateToCheckout()
        {
            cartPage.ClickOnCheckoutButton();
            checkoutPage.WaitTillCheckoutPageIsLoaded();
        }

        public void FillCheckoutInformationAndContinue(String firstName, String lastName, String zipCode)
        {
            checkoutPage.EnterFirstName(firstName);
            checkoutPage.EnterLastName(lastName);
            checkoutPage.EnterZipCode(zipCode);
            checkoutPage.ClickOnContinueButton();
        }

        public String CompleteTheOrder()
        {
            checkoutOverviewPage.ClickOnFinishButton();
            orderConfirmationPage.WaitUntilOrderConfirmationPageDisplayed();
            return orderConfirmationPage.GetOrderCompletionHeader();
        }

        public List<Product> GetAllProductsInCart()
        {
            return cartPage.GetProducts();
        }

        public List<Product> GetAllProductsInCheckoutOverview()
        {
            return checkoutOverviewPage.GetProducts();
        }

        public int GetProductsCountInCartBadge()
        {
            return productsPage.GetCartBadgeModule().GetNoOfProductsInCart();
        }
    }
}

