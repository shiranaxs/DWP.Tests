Feature: GetUserDetailsFromApi
	In order to verify user details
	As an administrator
	I want to get a specific user for a given user ID

@user
Scenario Outline: Verify User API Status Code and Description
	Given I send GET request to the API with valid user id <userid>
	When I complete the request
	Then I receive status code <statuscode> and status description <statusdescription>
	Examples: 
	| userid | statuscode | statusdescription |
	| "2"    | 200        | "OK"              |
	| "xyz"  | 404        | "NOT FOUND"       |

	@user
	Scenario: Verify Content Type of User API
	Given I send GET request to the API with valid user id "2"
	When I complete the request
	Then I receive "application/json" as content type

	@user
	Scenario: Verify User Details For a Given User Through User API
	Given I send GET request to the API with valid user id "2"
	When I complete the request
	Then I read user first name as "Bendix" and last name as "Halgarth"