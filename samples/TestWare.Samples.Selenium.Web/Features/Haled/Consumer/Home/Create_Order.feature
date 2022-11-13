@WebDriver
Feature: Create Order

Scenario Outline: Select Test Kit
	Given the user clicks on health test and select "<test_kit>"
	And the user should see page title as "<test_kit>"
	And the user should see page subtitle as "<price>"
	When the user clicks on add to cart
	Then the user should see page title as "My Cart"
	And the user should see page subtitle as "Continue shopping"	
	And the user should see cart icon as "<quantity>"
	And the user should see page button as pay faster
	When the user clicks on proceed to checkout
	Then the user should see page title as "Checkout"
	And the user should see page button as pay faster
	And the user fills the billing details form
	|  locator_by_id                     | value            |
	|  billing_first_name                | Jesus            |
	|  billing_last_name                 | Automation       |
	|  select2-billing_country-container | United States    |
	|  billing_address_1                 | Kansas           |
	|  billing_city                      | Kansas           |
	|  select2-billing_state-container   | Louisiana        |
	|  billing_postcode                  | 66211            |
	|  billing_phone                     | (762) 716-2121   |
	|  billing_email                     | generate         |
	|  Field-numberInput                 | 4242424242424242 |
	|  Field-expiryInput                 | 03 / 42          |
	|  Field-cvcInput                    | 213              |
	And the user clicks on terms and conditions checkbox
	And the user clicks on testing consent checkbox
	And the user should see page subtitle as "<price>"
	When the user clicks on place order

	Examples: 
	 | Example Description | test_kit       | price  | quantity |
	 | standard            | Women’s Health | 299.00 |     1    |

