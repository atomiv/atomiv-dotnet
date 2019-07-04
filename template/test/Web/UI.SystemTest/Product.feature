Feature: Product
	In order to make orders, I need to be able to browse products

@sort
Scenario: Products are sorted by name (asc) by default
	Given I am on the products page
	Then I see the products sorted by name (asc)

@sort
Scenario: I can sort products by name (asc)
	Given I am on the products page
	When I select to sort the products by name (asc)
	Then I see the products sorted by name (asc)

@sort
Scenario: I can sort products by name (desc)
	Given I am on the products page
	When I select to sort the products by name (desc)
	Then I see the products sorted by name (desc)

@sort
Scenario: I can sort products by price (asc)
	Given I am on the products page
	When I select to sort the products by price (asc)
	Then I see the products sorted by price (asc)

@sort
Scenario: I can sort products by price (desc)
	Given I am on the products page
	When I select to sort the products by price (desc)
	Then I see the products sorted by price (desc)

@cart
Scenario: Initially, all products can be added
	Given I am on the products page
	Then It allows me to add all products

@cart
Scenario: I can add a product to the cart
	Given I am on the products page
	When I click to add a product to the cart
	Then that product has been added to the cart

@cart
Scenario: I can remove a product from the cart
	Given I am on the products page
	And I have added a product to the cart
	When I click to remove that product from the cart
	Then that product has been removed from the cart