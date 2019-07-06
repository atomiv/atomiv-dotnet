#language: sr-Cyrl

Функционалност: Логовање

@логовање_валидно
Сценарио: Могу да се логујем са валидним креденцијалима
	Given налазим се на страници за логовање
	And I have entered the username 'standard_user'
	And I have entered the password 'secret_sauce'
	When I press login
	Then I see the products page