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