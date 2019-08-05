Feature: Customer
	As a salesperson, I need to be able to be able to manage the customer list

@ignore
@positive
Scenario: I can see the customer list
	Given I am on the Customer Index page
	Then I can see the list of customers

@ignore
@positive
Scenario: I can create a new customer
	Given I am on the Create Customer page
	And I have inputted the first name 'John'
	And I have inputted the last name 'Smith'
	When I click on the Create button
	Then I am on the Customer List page
	And I can see the newly created customer
	And I can see it has the same details as the ones I had inputted