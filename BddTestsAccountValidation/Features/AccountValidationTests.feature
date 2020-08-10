Feature: AccountValidationTests

Iban account validation

@tag1
Scenario: ValidAustrianAccountTest
	Given country: Austria for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: ValidDanishAccountTest
	Given country: Denmark for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: ValidFinnishAccountTest
	Given country: Finland for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: ValidGermanAccountTest
	Given country: Germany for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: ValidNorwegianAccountTest
	Given country: Norway for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: ValidSwissAccountTest
	Given country: Switzerland for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: ValidSwedishAccountTest
	Given country: Sweden for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode | ActionCode | Type | ErrorCode | Message | FieldReference |
	| Success    | null       | null | null      | null    | null           |
	When request was sended
	Then the status code should be OK
	Then response body should be equivqlent to expected Success object

Scenario: InvalidAccountTest
	Given invalid bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode     | ActionCode               | Type          | ErrorCode | Message                                      | FieldReference |
	| InvalidAccount | AskConsumerToReEnterData | BusinessError | 400.005   | A string value exceeds maximum length of 34. | bankAccount    |
	When request was sended
	Then the status code should be BadRequest
	Then response body should be equivqlent to expected InvalidAccount object

Scenario: UnsupportedCountryTest
	Given country: OtherCountry for bank account
	Given JWT token Q7DaxRnFls6IpwSW1SQ2FaTFOf7UdReAFNoKY68L
	Given expected response object:
	| ResultCode     | ActionCode               | Type          | ErrorCode | Message                       | FieldReference |
	| InvalidAccount | AskConsumerToReEnterData | BusinessError | 400.005   | This country is not supported | bankAccount    |
	When request was sended
	Then the status code should be BadRequest
	Then response body should be equivqlent to expected InvalidAccount object

Scenario: InvalidAuthorizationTest
	Given country: Sweden for bank account
	Given JWT token fdsg
	Given expected response object:
	| ResultCode              | ActionCode | Type | ErrorCode | Message                                         | FieldReference |
	| InvalidAuthentification | null       | null | null      | Authorization has been denied for this request. | null           |
	When request was sended
	Then the status code should be Unauthorized
	Then response body should be equivqlent to expected InvalidAuthentification object

Scenario: InvalidAuthorizationEmptyTokenTest
	Given country: Sweden for bank account
	Given empty JWT token
	Given expected response object:
	| ResultCode              | ActionCode | Type | ErrorCode | Message                                         | FieldReference |
	| InvalidAuthentification | null       | null | null      | Authorization has been denied for this request. | null           |
	When request was sended
	Then the status code should be Unauthorized
	Then response body should be equivqlent to expected InvalidAuthentification object