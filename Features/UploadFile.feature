Feature: UploadFile
	Upload file with different types and size. View uploaded file in the table.

@smoke
Scenario Outline: Upload file
	Given I launch the application
	And I set <fileSizeDefault> file max value
	And I set <fileTypesDefault> allowed file types
	When I set <filename> value to user name
	When I upload file with name <filename>
	Then Uploaded file displayed in table with <filename> user

	Examples:
		| filename | fileSizeDefault | fileTypesDefault   |
		| jpeg.jpg | 2048            | jpg, png, bmp, pdf |
		| pdf.pdf  | 2048            | jpg, png, bmp, pdf |
		| png.png  | 2048            | jpg, png, bmp, pdf |
		| bmp.bmp  | 2048            | jpg, png, bmp, pdf |

@smoke
Scenario Outline: Upload the same file twice
	Given I launch the application
	And I set 2048 file max value
	And I set jpg, png, bmp, pdf allowed file types
	When I set firstfile value to user name
	When I upload file with name jpeg.jpg
	When I set secondfile value to user name
	When I upload file with name jpeg.jpg
	Then Uploaded file displayed in table with secondfile user

@Regression
Scenario: Upload file with invalid format.
	Given I launch the application
	And I set jpg allowed file types
	When I set InvalidFormat value to user name
	And I upload file with name png.png
	Then I see only jpg format allowed error

@Regression
Scenario: Upload file with invalid size.
	Given I launch the application
	And I set jpg allowed file types
	And I set 2048 file max value
	When I set InvalidSize value to user name
	And I upload file with name jpeg-big_size.jpg
	Then I see Max allowed file 2048 size error