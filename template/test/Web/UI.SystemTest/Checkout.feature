Feature: Checkout
	I can checkout my selected orders

@positive
Scenario: Successfully purchasing multiple products
	Given I am logged with username 'standard_user' and password 'secret_sauce'
	And I see that the product 'Sauce Labs Backpack' has the price $29.99
	And I see that the product 'Sauce Labs Fleece Jacket' has the price $49.99
	And I see that the product 'Sauce Labs Onesie' has the price $7.99
	And I have added the product 'Sauce Labs Backpack' to the cart
	And I have added the product 'Sauce Labs Fleece Jacket' to the cart
	And I have added the product 'Sauce Labs Onesie' to the cart
	And I have clicked on the cart
	And I have clicked on checkout on the cart
	And I have entered the first name 'John'
	And I have entered the last name 'Smith'
	And I have entered the zip code '2000'
	And I have clicked on continue on the information
	And I see the card number 'SauceCard #31337'
	And I see the shipping information 'FREE PONY EXPRESS DELIVERY!'
	And I see the subtotal $87.97
	When I click on the Finish button on the overview
	Then I am on the order confirmation page
	And I see the confirmation header 'THANK YOU FOR YOUR ORDER'
	And I see the confirmation text 'Your order has been dispatched, and will arrive just as fast as the pony can get there!'

@positive
Scenario: Successfully purchasing a single product
	Given I am logged with username 'standard_user' and password 'secret_sauce'
	And I see that the product 'Sauce Labs Onesie' has the price $7.99
	And I have added the product 'Sauce Labs Onesie' to the cart
	And I have clicked on the cart
	And I have clicked on checkout on the cart
	And I have entered the first name 'John'
	And I have entered the last name 'Smith'
	And I have entered the zip code '2000'
	And I have clicked on continue on the information
	And I see the card number 'SauceCard #31337'
	And I see the shipping information 'FREE PONY EXPRESS DELIVERY!'
	And I see the subtotal $7.99
	When I click on the Finish button on the overview
	Then I am on the order confirmation page
	And I see the confirmation header 'THANK YOU FOR YOUR ORDER'
	And I see the confirmation text 'Your order has been dispatched, and will arrive just as fast as the pony can get there!'

@negative
Scenario: I cannot checkout if I did not input my first name
	Given I am logged with username 'standard_user' and password 'secret_sauce'
	And I have added the product 'Sauce Labs Backpack' to the cart
	And I have added the product 'Sauce Labs Fleece Jacket' to the cart
	And I have added the product 'Sauce Labs Onesie' to the cart
	And I have clicked on the cart
	And I have clicked on checkout on the cart
	When I click on continue on the information
	Then I see the error message for checkout information 'Error: First Name is required'

@negative
Scenario: I cannot checkout if I did not input my last name
	Given I am logged with username 'standard_user' and password 'secret_sauce'
	And I have added the product 'Sauce Labs Backpack' to the cart
	And I have added the product 'Sauce Labs Fleece Jacket' to the cart
	And I have added the product 'Sauce Labs Onesie' to the cart
	And I have clicked on the cart
	And I have clicked on checkout on the cart
	And I have entered the first name 'John'
	When I click on continue on the information
	Then I see the error message for checkout information 'Error: Last Name is required'

@negative
Scenario: I cannot checkout if I did not input my zip code
	Given I am logged with username 'standard_user' and password 'secret_sauce'
	And I have added the product 'Sauce Labs Backpack' to the cart
	And I have added the product 'Sauce Labs Fleece Jacket' to the cart
	And I have added the product 'Sauce Labs Onesie' to the cart
	And I have clicked on the cart
	And I have clicked on checkout on the cart
	And I have entered the first name 'John'
	And I have entered the last name 'Smith'
	When I click on continue on the information
	Then I see the error message for checkout information 'Error: Postal Code is required'