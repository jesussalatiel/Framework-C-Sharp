@WebDriver
Feature: Create Order

Scenario Outline: Generate an order
	Given the user clicks on health test and select "<test_kit>"
	And the user should see page title as "<test_kit>"
	And the user should confirm the "<price>" displayed
	When the user clicks on add to cart
	Then the user should see page title as "My Cart"
	And the user should see page subtitle as "Continue shopping"	
	And the user should see cart icon as "<quantity>"
	And the user should see page button as pay faster
	When the user clicks on proceed to checkout
	Then the user should see page title as "Checkout"
	And the user should see page button as pay faster
	And the user should confirm the "<price>" displayed
	And the user fills the billing details form
	|  locator_by_id                     | value            |
	|  billing_first_name                | <name>           |
	|  billing_last_name                 | <last_name>      |
	|  select2-billing_country-container | United States    |
	|  billing_address_1                 | 4866 Ridge Road  |
	|  billing_city                      | 322 W Sutherland St|
	|  select2-billing_state-container   | Louisiana        |
	|  billing_postcode                  | 66211            |
	|  billing_phone                     | 6207474147       |
	|  billing_email                     | <email>         |
	|  Field-numberInput                 | 4242424242424242 |
	|  Field-expiryInput                 | 03 / 42          |
	|  Field-cvcInput                    | 213              |
	And the user clicks on terms and conditions checkbox
	And the user clicks on testing consent checkbox
	When the user clicks on place order
	Then the user verifies the order number
	And the user should confirm the "<price>" displayed

   #Generate Tracking Code - Order Placed - Pending Delivery - Delivered
	Then the admin enters default username
	And the admin enters default password 
	When the admin clicks login
	Then the admin clicks on "Orders"
	And the admin selects the order
	| key       | value         |
	| name      | <name>        |
	| last name | <last_name>   |
	| status    | Order Placed  |
	Then the admin clicks on generate code
	And the admin enters fedex shipping "<tracking_code>"
	When the admin click on assign tracking code
	And the admin selects shipping "<carrier>" 
	And the admin enters tracking "<tracking_code>"
	When the admin clicks on save shipping info

	#Assing user password (workaround: I dont' have access to see the temporal password)
	Then the admin saves consumer tracking code
	Then the admin clicks on "Consumer" icon
	And the admin saves the email
	When the admin clicks on close
	Then the admin clicks on "Consumers"
	And the admin searches by saved email
    When the admin clicks search
	And the admin clicks on edit
	And the admin modifies new password fields
	| key        | value |
	| password | NoExcuses@12345  |
	| password_confirmation | NoExcuses@12345  |
	And the admin saves email and password
	When the admin clicks on save changes
	Then the admin verifies popup "Consumer updated successfully."


	#User register the test kit and select a schedulle
	Then the user log into the system
	And the user clicks on register test kit
	Then the user accepts terms of service and privacy policy
	And the user click on complete registration
	#Then the user log into the system
	And the user clicks on my health tests
	And the user searches test kit id
	

	Examples: 
	 | Example Description | test_kit       | name  | last_name      | email | price  | quantity | tracking_code          | carrier |
	 | standard            | Women’s Health | Robert | Lindemann | generate | 299.00 | 1        | 9114999999999999999999 | Fedex   |



	