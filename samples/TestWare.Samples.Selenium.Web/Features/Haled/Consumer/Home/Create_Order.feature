@WebDriver
Feature: Create Order

Scenario Outline: Generate an order
#	Given the user clicks on health test and select "<test_kit>"
#	And the user should see page title as "<test_kit>"
#	And the user should confirm the "<price>" displayed
#	When the user clicks on add to cart
#	Then the user should see page title as "My Cart"
#	And the user should see page subtitle as "Continue shopping"	
#	And the user should see cart icon as "<quantity>"
#	And the user should see page button as pay faster
#	When the user clicks on proceed to checkout
#	Then the user should see page title as "Checkout"
#	And the user should see page button as pay faster
#	And the user should confirm the "<price>" displayed
#	And the user fills the billing details form
#	|  locator_by_id                     | value            |
#	|  billing_first_name                | Jesus            |
#	|  billing_last_name                 | Test       |
#	|  select2-billing_country-container | United States    |
#	|  billing_address_1                 | Kansas           |
#	|  billing_city                      | Kansas           |
#	|  select2-billing_state-container   | Louisiana        |
#	|  billing_postcode                  | 66211            |
#	|  billing_phone                     | (762) 716-2121   |
#	|  billing_email                     | generate         |
#	|  Field-numberInput                 | 4242424242424242 |
#	|  Field-expiryInput                 | 03 / 42          |
#	|  Field-cvcInput                    | 213              |
#	And the user clicks on terms and conditions checkbox
#	And the user clicks on testing consent checkbox
#	When the user clicks on place order
#	Then the user verifies the order number
#	And the user should confirm the "<price>" displayed
#
#	#Generate Tracking Code
#	Then the admin enters default username
#	And the admin enters default password 
#	When the admin clicks login
#	Then the admin clicks on "Orders"
#	And the admin selects the order
#	| key       | value         |
#	| name      | Jesus         |
#	| last name | Test          |
#	| status    | Order Placed  |
#	Then the admin clicks on generate code
#	And the admin enters fedex shipping "<tracking_code>"
#	When the admin click on assign tracking code
#	And the admin selects shipping "<carrier>" 
#	And the admin enters tracking "<tracking_code>"
#	When the admin clicks on save shipping info

	#Assing user password (workaround: I dont' have access to see the temporal password)
	Then the admin saves consumer tracking code
	Then the admin click on "Consumer" icon
	#And the admin registers personal email and go to "Consumer" and search by email
	#When the admin clicks search
	#Then the admin verifies that the email address corresponds
	#And the admin clicks on edit
	#And the admin modifies new password fields
	#| password        | confirm password |
	#| NoExcuses@12345 | NoExcuses@12345  |
	#And the admin saves email and password
	#When the admin clicks on save changes
	#Then the admin verifies popup ""


	#User: 
	#Then the user enters tracking code assign by admin
	#And the user selects I am the test taker 18 years and over
	#And the user clicks on register kit
	#Then the user enters credentials given by admin
	#When the user clicks on Login
	#Then the user fill the form


	Examples: 
	 | Example Description | test_kit       | price  | quantity | tracking_code          | carrier |
	 | standard            | Women’s Health | 299.00 | 1        | 9114999999999999999999 | Fedex   |



	