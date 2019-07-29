Feature: Customer
	As a salesperson, I need to be able to be able to manage the customer list

@positive
Scenario: I can create a new customer
	Given I am on the Create Customer page
	And I have inputted the first name 'John'
	And I have inputted the last name 'Smith'
	When I click on 'Create'
	Then I am on the Customer List page
	And I can see the newly created customer
	And I can see it has the same details as the ones I had inputted