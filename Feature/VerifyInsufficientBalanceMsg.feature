Feature: Verify Insufficient Balance Message
	As a web user I should not be able to send SMS with low balance

@mytag
Scenario: If user has low balance then system must display proper error message
	Given I am an authorized user of Routee.net
	And I perform POST action for Routee.net Send SMS API
	Then System must display proper error message i.e Insufficient Balance
	And System must display proper error code as 400001009