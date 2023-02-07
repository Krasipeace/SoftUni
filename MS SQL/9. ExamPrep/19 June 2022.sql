-- 1 DDL (Data Definition Language)

CREATE TABLE Owners
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	Address VARCHAR(50)
)

CREATE TABLE AnimalTypes
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages
(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages
(
	CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments
(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)


-- 2 Insert

INSERT INTO Volunteers VALUES

	('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
	('Dimitur Stoev', '0877564223', NULL, 42, 4),
	('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
	('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
	('Boryana Mileva', '0888112233', NULL, 31, 5)


INSERT INTO Animals VALUES

	('Giraffe', '2018-09-21', 21, 1),
	('Harpy Eagle', '2015-04-17', 15, 3),
	('Hamadryas Baboon', '2017-11-02', NULL, 1),
	('Tuatara', '2021-06-30', 2, 4)


-- 3 Update

--SELECT * FROM Owners
--SELECT * FROM Animals

UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL


-- 4 Delete

--SELECT * FROM VolunteersDepartments

--DELETE FROM Volunteers
--WHERE DepartmentId = 2

--DELETE FROM VolunteersDepartments
--WHERE Id = 2


-- 5 Volunteers

SELECT 
	[Name], PhoneNumber, [Address], AnimalId, DepartmentId
FROM Volunteers
ORDER BY
	[Name] ASC,
	AnimalId ASC, 
	DepartmentId ASC


-- 6 Animals Data

SELECT
	a.[Name], 
	at.AnimalType, 
	FORMAT(a.BirthDate, 'dd.MM.yyyy') AS BirthDate
FROM Animals AS a
INNER JOIN AnimalTypes AS at
	ON at.Id = a.AnimalTypeId
ORDER BY 
	a.[Name] ASC


-- 7 Owners and Their Animals

SELECT TOP(5) 
	o.[Name] AS [Owner],
	COUNT(a.Id) AS CountOfAnimals
FROM Owners AS o
INNER JOIN Animals AS a
	ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY 
	CountOfAnimals DESC, 
	[Owner] ASC


-- 8 Owners, Animals and cages

SELECT 
	CONCAT(o.[Name],'-',a.[Name]) AS OwnersAnimals,
	o.PhoneNumber,
	ac.CageId
FROM Owners AS o
INNER JOIN Animals AS a
	ON a.OwnerId = o.Id
INNER JOIN AnimalTypes AS [at]
	ON at.Id = a.AnimalTypeId
INNER JOIN AnimalsCages AS ac
	ON ac.AnimalId = a.Id
WHERE [at].AnimalType = 'Mammals'
ORDER BY
	o.[Name] ASC,
	a.[Name] DESC


-- 9 Volunteers in Sofia

SELECT 
	v.[Name],
	v.PhoneNumber,
	SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 1, LEN(v.[Address])) AS [Address]
FROM Volunteers AS v
INNER JOIN VolunteersDepartments AS vd
	ON vd.Id = v.DepartmentId
WHERE vd.DepartmentName = 'Education program assistant' 
	AND v.[Address] LIKE '%Sofia%'
ORDER BY
	v.[Name] ASC


-- 10 Animals for adoption

SELECT
	a.[Name],
	DATEPART(YEAR, a.BirthDate) AS BirthYear,
	[at].AnimalType
FROM Animals AS a
INNER JOIN AnimalTypes AS [at] 
	ON [at].Id = a.AnimalTypeId
WHERE a.OwnerId IS NULL
	AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 
	AND [at].AnimalType <> 'Birds'
ORDER BY
	a.[Name] ASC


-- 11 All volunteers in a department

CREATE FUNCTION udf_GetVolunteersCountFromADepartment 
	(@VolunteersDepartment VARCHAR(MAX))
RETURNS INT AS
BEGIN

	DECLARE @departmentId INT;
	SET @departmentId = (
		SELECT Id
		FROM VolunteersDepartments
		WHERE DepartmentName = @VolunteersDepartment
	);

	DECLARE @count INT;
	SET @count = (
		SELECT COUNT(*) 
		FROM Volunteers
		WHERE DepartmentId = @departmentId
	);

RETURN @count

END

-- Tests:
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events') --> 5
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement') --> 4
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant') --> 6


-- 12 Animals with owner or not

CREATE PROC usp_AnimalsWithOwnersOrNot
	(@AnimalName VARCHAR(MAX)) AS
BEGIN
	
	SELECT 
		a.[Name],
		ISNULL(o.[Name], 'For adoption') AS OwnersName
	FROM Animals AS a
	LEFT JOIN Owners AS o
		ON o.Id = a.OwnerId
	WHERE 
		a.[Name] = @AnimalName

END

-- Tests:

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
--> Pumpkinseed Sunfish   Kamelia Yancheva
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
--> Hippo        For adoption
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
--> Brown bear   Gergana Mancheva