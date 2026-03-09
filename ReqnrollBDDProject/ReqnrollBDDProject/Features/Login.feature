Feature: Reqnroll Login Feature
  As a user
  I want to login to Reqnroll
  So that I can access the application


  # Scenario Outline: Login with multiple users
  #   Given I open the Reqnroll login page
  #   When I login with "<username>" and "<password>"
  #   Then I should see "<result>"
  #
  #   Examples:
  #     | username                | password        | result  |
  #     | hospital@rovicare.com   | RoviPass@321    | success |
  #     | admin@rovicare.com      | SupeAdmin@132   | success |
  #     | hospital@rovicare.com   | WrongPass123    | failure |
  #     | wronguser@test.com      | RoviPass@321    | failure |
  #     |                         | RoviPass@321    | failure |
  #     | hospital@rovicare.com   |                 | failure |
  #     |                         |                 | failure |
  #     | 111111111111111111      | RoviPass@321    | failure |
  #  parallel execution of scenarios is not working with scenario outline, so I have to write individual scenarios for each test case

  Scenario: Valid hospital login
    Given I open the Reqnroll login page
    When I login with "hospital@rovicare.com" and "RoviPass@321"
    Then I should see "success"

  Scenario: Valid admin login
    Given I open the Reqnroll login page
    When I login with "admin@rovicare.com" and "SupeAdmin@132"
    Then I should see "success"

  Scenario: Invalid password
    Given I open the Reqnroll login page
    When I login with "hospital@rovicare.com" and "WrongPass123"
    Then I should see "failure"

  Scenario: Invalid username
    Given I open the Reqnroll login page
    When I login with "wronguser@test.com" and "RoviPass@321"
    Then I should see "failure"

  Scenario: Missing username
    Given I open the Reqnroll login page
    When I login with "" and "RoviPass@321"
    Then I should see "failure"

  Scenario: Missing password
    Given I open the Reqnroll login page
    When I login with "hospital@rovicare.com" and ""
    Then I should see "failure"

  Scenario: Both username and password missing
    Given I open the Reqnroll login page
    When I login with "" and ""
    Then I should see "failure"

  Scenario: Invalid username format
    Given I open the Reqnroll login page
    When I login with "111111111111111111" and "RoviPass@321"
    Then I should see "failure"