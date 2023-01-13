CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL,
	Password NVARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) 
		CHECK(LEN(ProfilePicture) >= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL
);

INSERT INTO Users
VALUES
	('Krasimir', 123456, NULL, '2022-05-29', 0),
	('Sofia', 234567, NULL,  '2022-05-29', 0),
	('Elin', 345678, NULL, '2022-05-09', 1),
	('Kristiana', 456789, NULL, '2022-02-19', 0),
	('Krum', 567890, NULL, '2022-01-14', 0);