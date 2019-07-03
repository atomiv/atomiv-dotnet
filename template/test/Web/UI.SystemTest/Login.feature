Feature: Login
	In order to be able to use the application, I need to be able to login

@login_valid
Scenario: Successful login with valid credentials
	Given I am on the login page
	And I have entered username 'standard_user' and password 'secret_sauce'
	When I press login
	Then I see the inventory page

@login_invalid
Scenario: Failed login with missing username
	Given I am on the login page
	And I have entered username 'standard_user' and password 'secret_sauce'
	When I press login
	Then I see the inventory page
