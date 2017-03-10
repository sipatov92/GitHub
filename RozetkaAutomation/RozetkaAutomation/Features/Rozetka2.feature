Feature: Rozetka2
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: SetSearchField
	Given I have entered <name> into the search field
	When  I press Search Button
	Then  Item with link <name> is displayed on the page
	Examples: 
	| name              |
	| Samsung Galaxy S7 |
	| Atatatat          |