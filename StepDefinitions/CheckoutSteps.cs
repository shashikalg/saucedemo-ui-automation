using System.Linq;
using NUnit.Framework;
using Reqnroll;
using saucedemo_ui_automation.Common;
using saucedemo_ui_automation.Constants;
using saucedemo_ui_automation.Functions.Login;
using saucedemo_ui_automation.Functions.Products;
using saucedemo_ui_automation.Helpers;
using saucedemo_ui_automation.Models;

namespace saucedemo_ui_automation.StepDefinitions
{
    [Binding]
    public class CheckoutSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly List<Product> _selectedProducts = new();
        private string _successHeader = string.Empty;

        public CheckoutSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        private LoginFunctions LoginFunctions =>
            _scenarioContext.Get<LoginFunctions>("LoginFunctions");

        private OrderFunctions OrderFunctions =>
            _scenarioContext.Get<OrderFunctions>("OrderFunctions");

        [Given("I open the SauceDemo application")]
        public void GivenIOpenTheSauceDemoApplication()
        {
            LoginFunctions.NavigateTo(FrameworkConfig.BaseUrl);
        }

        [Given("I log in as a standard user")]
        public void GivenILogInAsAStandardUser()
        {
            List<UserCredential> users =
                TestDataHelper.LoadListFromJson<UserCredential>(TestDataPaths.Users);

            UserCredential standardUser =
                users.First(u => u.Username == "standard_user");

            LoginFunctions.LogInWithValidUser(
                standardUser.Username!,
                standardUser.Password!);
        }

        [When("I add the following products to the cart")]
        public void WhenIAddTheFollowingProductsToTheCart(Table table)
        {
            foreach (var row in table.Rows)
            {
                string productName = row["ProductName"];

                Product addedProduct =
                    OrderFunctions.AddProductToCart(productName);

                _selectedProducts.Add(addedProduct);
            }
        }

        [When("I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            OrderFunctions.NavigateToCart();
        }

        [Then("the cart should contain the selected products")]
        public void ThenTheCartShouldContainTheSelectedProducts()
        {
            List<Product> productsInCart =
                OrderFunctions.GetAllProductsInCart();

            Assert.That(
                ProductHelper.AreProductsEqual(_selectedProducts, productsInCart),
                Is.True,
                "Products in cart do not match selected products.");
        }

        [When("I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            OrderFunctions.NavigateToCheckout();
        }

        [When("I enter checkout information")]
        public void WhenIEnterCheckoutInformation(Table table)
        {
            var row = table.Rows[0];

            OrderFunctions.FillCheckoutInformationAndContinue(
                row["FirstName"],
                row["LastName"],
                row["PostalCode"]);
        }

        [When("I complete the order")]
        public void WhenICompleteTheOrder()
        {
            _successHeader = OrderFunctions.CompleteTheOrder();
        }

        [Then(@"I should see the order confirmation message ""(.*)""")]
        public void ThenIShouldSeeTheOrderConfirmationMessage(string expectedMessage)
        {
            Assert.That(_successHeader, Is.EqualTo(expectedMessage));
        }
    }
}
