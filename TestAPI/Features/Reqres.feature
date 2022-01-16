Feature: Reqres
	Example of api requests

Scenario: Get user
	Given I create a request to endpoint '/api/users?page=2' with 'GET' method
	When I send the request
	Then I should see status code '200'
	And I should get in response user with 'Michael' name 

Scenario: Add user
	Given I have next user
		| Name | Job |
		| Mike | QA  |
	Then user with 'Mike' name is created

Scenario: Updated exsisting user
	Given I have next user
		| Name | Job |
		| Nike | QA  |
	Then I save user id
	Given I update created user
		| Name | Job |
		| Nike | BA  |
	Then user with 'BA' job is updated