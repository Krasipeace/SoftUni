CREATE TABLE People
(	
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(150) NOT NULL,
	Picture VARBINARY(MAX),
	Height FLOAT(2),
	Weight FLOAT(2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
);

INSERT INTO People
VALUES
	('Krasimir', NULL, 1.78, 95, 'M', '1987-05-29 09:30:59', NULL),
	('Sofia', NULL, 1.65, 65, 'F', '1999-05-29 09:30:59', NULL),
	('Elin', NULL, 1.88, 90, 'M', '1991-05-09 09:30:59', NULL),
	('Kristiana', NULL, 1.67, 66, 'F', '1984-02-19 09:30:59', NULL),
	('Krum', NULL, 1.98, 80, 'M', '1987-01-14 09:30:59', NULL);