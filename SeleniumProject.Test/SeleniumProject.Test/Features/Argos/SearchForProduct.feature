Feature: SearchForProduct
	

Scenario: Search for books on argos website
	Given I am on the Argos home page
	When I search for item 'books'
	Then the list of booked available are displayed 
