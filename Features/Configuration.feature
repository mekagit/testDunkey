Feature: Configuration
        Configuration file upload.

@smoke
Scenario: Configuration file upload.
	Given I launch the application with go to Configuration page
	When I set <size> value to max file size field
	And I set <filetypes> value to allowed file types
	And I click save
	Then I max value is <size> and allowed file type are <filetypes>

	Examples:
		| size | filetypes     |
		| 2048 | jpg, png, bmp |
