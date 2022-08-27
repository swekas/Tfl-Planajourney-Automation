Feature: Plan A Journey

Scenario: Verify valid journey
	Given I am on the Tfl website
	When I enter journey from "London Bridge City Pier"
	And  I enter journey to "Railpen, Liverpool Street, London, UK"
	Then I click on Plan my journey button
	And I verify the Valid journey is planned

Scenario: Verify Invalid journey
	Given I am on the Tfl website
	When I enter journey from "Milton Keynes, UK"
	And I enter journey to "Cambridge, UK"
	Then I click on Plan my journey button
	Then I verify the invalid journey message

Scenario: Verify Plan journey without entering locations
	Given I am on the Tfl website
	When I enter journey from ""
	And I enter journey to ""
	Then I click on Plan my journey button
	And I verify field validation messages


Scenario: Verify journey plan based on arrival time
	Given I am on the Tfl website
	When I enter journey from "London Bridge City Pier"
	And I enter journey to "Railpen, Liverpool Street, London, UK"
	When I click on change time
	And I click arrival time
	Then I select arrival time "02:30"
	Then I click on Plan my journey button
	And I verify the journey plan based on arrival time "02:30"

Scenario: Verify edit journey button 
	Given I am on the Tfl website
	When I enter journey from "London Bridge City Pier"
	And I enter journey to "Railpen, Liverpool Street, London, UK"
	Then I click on Plan my journey button
	And I click on edit journey on journey results page 
	When I clear and enter another journey to "Cambridge, UK"
	And I click on update journey 
	Then I verify if journey to location is updated to "Cambridge, UK"
