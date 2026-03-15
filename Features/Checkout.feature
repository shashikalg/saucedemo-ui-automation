Feature: Checkout

  As a customer
  I want to place an order for multiple products
  So that I can complete a purchase successfully

  Scenario: Place an order for multiple products
    Given I open the SauceDemo application
    And I log in as a standard user
    When I add the following products to the cart
      | ProductName           |
      | Sauce Labs Backpack   |
      | Sauce Labs Bike Light |
    And I navigate to the cart
    Then the cart should contain the selected products
    When I proceed to checkout
    And I enter checkout information
      | FirstName | LastName | PostalCode |
      | Anna      | Peterson | 1120       |
    Then the item total should match the selected products total
    When I complete the order
    Then I should see the order confirmation message "Thank you for your order!"

