Feature: GetAllUsersfromApi
	In order to verify all user details
	As an administrator
	I want to get all users from API
@allusers
Scenario: Verify that API returns all user using count
	Given I send GET request to get all users
	When I complete the request for all users
	Then Api returns "1000" users