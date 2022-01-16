@api
Feature: Search Zippopotamus
	In order to auto-complete forms with location details
	As a consumer of the Zippopotam.us API
	I want to search for place names using a country code and zip code

Scenario Outline: Searching country locations by zip code
	Given I have the country code of <Country Code> and the zip code <Zip Code>
	When I search for locations using these codes
	Then I should see the place name <Place Name>

	Examples:
	| Country Code | Zip Code | Place Name    |
	| us           | 90210    | Beverly Hills |
	| us           | 22222    | Arlington     |
