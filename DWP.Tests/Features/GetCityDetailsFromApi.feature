Feature: GetCityDetailsFromApi
	In order to verify user details
	As an administrator
	I want to get a specific users for a given city name

@city
Scenario: Verify User Details For a Given User Through City API
	Given I send GET request to the City API with valid city name "Kundung"
	When I complete the request for city API
	Then API returns available users located in "Kundung"