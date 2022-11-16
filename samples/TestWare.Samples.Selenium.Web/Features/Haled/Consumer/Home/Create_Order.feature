@WebDriver
Feature: Create Order

Scenario Outline: Select Test Kit
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
#	|  billing_last_name                 | Automation       |
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
##	When the user clicks on place order
##	Then the user verifies the order number
##	And the user should confirm the "<price>" displayed
#
#
	Then the admin enters default username
	And the admin enters default password 
	When the admin clicks login
	Then the admin clicks on "Orders"
	And the admin clicks on "<test_kit>" to view recently added product
	Then the admin clicks on generate code
	And the admin enters fedex shipping "<tracking_code>"
	When the admin click on assign tracking code
	And the admin selects shipping "<carrier>" 
	When the admin clicks on save shipping info
	Then the admin validate "<carrier>" on tracking number 


	Examples: 
	 | Example Description | test_kit       | price  | quantity |
	 | standard            | Women’s Health | 299.00 |     1    |



	