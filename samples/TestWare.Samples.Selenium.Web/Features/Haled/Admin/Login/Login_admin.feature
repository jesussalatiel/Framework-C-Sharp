@WebDriver
Feature: Login as Administrator

Scenario Outline: Login 
	Given the admin enters username '<username>'
	And the admin enters password '<password>'
	When the admin clicks submit
	Then the admin can login

	Examples: 
	 | Example Description | username      | password     |
	 | standard            | mhladmin@yopmail.com | Done@12345 |

