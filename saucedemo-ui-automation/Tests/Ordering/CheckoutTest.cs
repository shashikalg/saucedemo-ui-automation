using saucedemo_ui_automation.Common;
using saucedemo_ui_automation.Functions.Login;
using saucedemo_ui_automation.Functions.Products;
using saucedemo_ui_automation.Helpers;
using saucedemo_ui_automation.Models;
using saucedemo_ui_automation.Tests;

namespace SauceDemoUIAutomation.Tests.Ordering
{

    public class CheckoutTest : TestBase
    {
        LoginFunctions loginFunctions;
        OrderFunctions orderFunctions;
        List<Product> productsToAdd;
        UserCredential testUser;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            loginFunctions = new LoginFunctions(_driver);
            orderFunctions = new OrderFunctions(_driver);

            productsToAdd = TestDataHelper.LoadListFromJson<Product>(TestDataPaths.Products);
            testUser = TestDataHelper.LoadListFromJson<UserCredential>(TestDataPaths.Users)[0];
        }

        [SetUp]
        public void Setup()
        {
            loginFunctions.NavigateTo("https://www.saucedemo.com/");
            loginFunctions.LogInWithValidUser(testUser.Username, testUser.Password);

        }

        [Test]
        public void VerifyUserCanPlaceOrderForMultipleProducts()
        {
            int actualProductCount;

            // Add the first product to Cart
            Product addedProduct1 = orderFunctions.AddProductToCart(productsToAdd[0].Name);
            actualProductCount = orderFunctions.GetProductsCountInCartBadge();
            Assert.Multiple(() =>
            {
                Assert.That(actualProductCount, Is.EqualTo(1));
                Assert.That(addedProduct1.Price, Is.EqualTo(productsToAdd[0].Price));
            });

            // Add the second product to Cart
            Product addedProduct2 = orderFunctions.AddProductToCart(productsToAdd[1].Name);
            actualProductCount = orderFunctions.GetProductsCountInCartBadge();
            Assert.Multiple(() =>
            {
                Assert.That(actualProductCount, Is.EqualTo(2));
                Assert.That(addedProduct2.Price, Is.EqualTo(productsToAdd[1].Price));
            });

            //Navigate to Cart and verify the added products
            orderFunctions.NavigateToCart();
            List<Product> productsInCart = orderFunctions.GetAllProductsInCart();

            Assert.That(productsInCart.Count, Is.EqualTo(productsToAdd.Count));
            Assert.That(ProductHelper.AreProductsEqual(productsToAdd, productsInCart), Is.True);

            //Navigate to Checkout, fill customer info and continue to checkout overview
            orderFunctions.NavigateToCheckout();
            orderFunctions.FillCheckoutInformationAndContinue("Anna", "Peterson", "1120");

            //Verify the products and confirm the order
            List<Product> productsInCheckoutOverview = orderFunctions.GetAllProductsInCheckoutOverview();
            Assert.That(productsInCheckoutOverview.Count, Is.EqualTo(productsToAdd.Count));
            Assert.That(ProductHelper.AreProductsEqual(productsToAdd, productsInCart), Is.True);

            String successHeader = orderFunctions.CompleteTheOrder();
            Assert.That(successHeader, Is.EqualTo("Thank you for your order!"));
        }
    }

}