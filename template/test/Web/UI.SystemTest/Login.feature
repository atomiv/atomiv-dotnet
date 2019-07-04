Feature: Login
	In order to be able to use the application, I need to be able to login

@login_valid
Scenario: I can login with valid credentials
	Given I am on the login page
	And I have entered the username 'standard_user'
	And I have entered the password 'secret_sauce'
	When I press login
	Then I see the products page

@login_invalid
Scenario: I cannot login with missing username
	Given I am on the login page
	And I have entered the password 'secret_sauce'
	When I press login
	Then I see the error message 'Epic sadface: Username is required'

@login_invalid
Scenario: I cannot login with missing password
	Given I am on the login page
	And I have entered the username 'standard_user'
	When I press login
	Then I see the error message 'Epic sadface: Password is required'

@login_invalid
Scenario: I cannot login with invalid credentials
	Given I am on the login page
	And I have entered the username 'standard_user'
	And I have entered the password 'secret_sauce2'
	When I press login
	Then I see the error message 'Epic sadface: Username and password do not match any user in this service'

@login_invalid
Scenario: I cannot login if I have been locked out
	Given I am on the login page
	And I have entered the username 'locked_out_user'
	And I have entered the password 'secret_sauce'
	When I press login
	Then I see the error message 'Epic sadface: Sorry, this user has been locked out.'