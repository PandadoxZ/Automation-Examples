@web
Feature: Search Duck Duck Go
	In order to find relevant web resources on the internet
	As a user of the web
	I want to search for keywords related to things that I am interested in

	Rule: Performing a search on Duck Duck Go searches the internet for relevant content

		Scenario Outline: Searching Duck Duck Go using a search phrase
			Given I am on the Duck Duck Go homepage
			When I search for "<Search Phrase>"
			Then I should see the search results page

			Examples:
			| Search Phrase                 |
			| "Dogs"                        |
			| "Co-operation"                |
			| "Convert stones to kilograms" |