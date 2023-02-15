-- 1 DDL (Data Definition Language)

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK (Age >= 14 AND Age <= 110),
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT CHECK (Age >= 18 AND Age <= 110),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(20) NOT NULL,
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	StatusId INT FOREIGN KEY REFERENCES [Status](Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)


-- 2 Insert 

INSERT INTO Employees 
(FirstName, LastName, Birthdate, DepartmentId)
VALUES 

	('Marlo', 'O''Malley', '1958-9-21', '1'),
	('Niki', 'Stanaghan', '1969-11-26', '4'),
	('Ayrton', 'Senna', '1960-03-21', '9'),
	('Ronnie', 'Peterson', '1944-02-14', '9'),
	('Giovanna', 'Amati', '1959-07-20', '5')

INSERT INTO Reports 
(CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES

	('1', '1', '2017-04-13', '', 'Stuck Road on Str.133', '6', '2'),
	('6', '3', '2015-09-05', '2015-12-06', 'Charity trail running', '3', '5'),
	('14', '2', '2015-09-07', '', 'Falling bricks on Str.58', '5', '2'),
	('4', '3', '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', '1', '1')


-- 3 Update

UPDATE 
	Reports
SET 
	CloseDate = GETDATE()
WHERE 
	CloseDate IS NULL


-- 4 Delete

DELETE FROM Reports
WHERE [StatusId] = 4

DELETE FROM [Status]
WHERE Id = 4


-- 5 Unassigned Reports

SELECT 
	[Description], 
	FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate
FROM 
	Reports AS r
WHERE 
	EmployeeId IS NULL
ORDER BY 
	r.OpenDate ASC,
	[Description] ASC


-- 6 Reports and Categories

SELECT 
	r.[Description], 
	c.[Name] AS CategoryName
FROM 
	Reports AS r
JOIN	
	Categories AS c ON c.Id = r.CategoryId
ORDER BY
	r.[Description] ASC,
	c.[Name] ASC


-- 7 Most Reported Category

SELECT TOP (5) 
	c.[Name] AS CategoryName,
	COUNT(r.CategoryId) AS ReportsNumber
FROM 
	Categories AS c
JOIN 
	Reports AS r ON r.CategoryId = c.Id
GROUP BY 
	c.[Name]
ORDER BY 
	COUNT(r.CategoryId) DESC,
	c.[Name] ASC
	

-- 8 Birthday Report

SELECT 
	u.Username,
	c.[Name] AS CategoryName
FROM 
	Users AS u
JOIN
	Reports AS r ON r.UserId = u.Id
JOIN
	Categories AS c ON c.Id = r.CategoryId
WHERE
	DAY(u.Birthdate) = DAY(r.OpenDate)
ORDER BY
	u.Username ASC,
	c.[Name] ASC


-- 9 Users per Employee

SELECT 
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	COUNT (DISTINCT r.UserId) AS UsersCount
FROM 
	Employees AS e
LEFT JOIN 
	Reports AS r ON r.EmployeeId = e.Id
GROUP BY
	CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY
	COUNT (DISTINCT r.UserId) DESC,
	CONCAT(e.FirstName, ' ', e.LastName) ASC


-- 10 Full Info

SELECT
	IIF (
			e.FirstName IS NULL AND e.LastName IS NULL, 
			'None', 
			e.FirstName + ' ' + e.LastName
		) AS Employee,
	IIF (
			d.[Name] IS NULL,
			'None', 
			d.[Name] 
		) AS Department,
	c.[Name] AS Category,
	r.[Description],
	FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	s.[Label] AS [Status],
	u.[Name] AS [User]
FROM 
	Reports AS r
JOIN
	Users AS u ON u.Id = r.UserId
JOIN 
	[Status] AS s ON s.Id = r.StatusId
JOIN
	Categories AS c ON c.Id = r.CategoryId
JOIN 
	Departments AS d ON d.Id = c.DepartmentId
JOIN
	Employees AS e ON e.Id = r.EmployeeId
ORDER BY
	e.FirstName DESC,
	e.LastName DESC,
	d.[Name] ASC,
	c.[Name] ASC,
	r.[Description] ASC,
	FORMAT(r.OpenDate, 'dd.MM.yyyy') ASC,
	s.[Label] ASC,
	u.[Name] ASC


-- 11 Hours to Complete

CREATE FUNCTION udf_HoursToComplete
	(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT AS
BEGIN
	IF (@StartDate IS NULL OR @EndDate IS NULL) RETURN 0
	DECLARE @TotalHours INT = DATEDIFF(Hour, @StartDate, @EndDate)
	RETURN @TotalHours
END

--> Test: 
SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
FROM Reports


-- 12 Assign Employee

CREATE PROC usp_AssignEmployeeToReport
	(@EmployeeId INT, @ReportId INT) AS
BEGIN
	DECLARE @emplDepId INT = (
								SELECT DepartmentId
								FROM Employees
								WHERE Id = @EmployeeId
							 )
	DECLARE @repDepId INT = (
								SELECT c.DepartmentId
								FROM Reports AS r
								JOIN Categories AS c ON c.Id = r.CategoryId
								WHERE r.Id = @ReportId
							)
	IF (@emplDepId <> @repDepId) THROW 66666, 'Employee doesn''t belong to the appropriate department!', 1
	ELSE 
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
END

--> Tests:
EXEC usp_AssignEmployeeToReport 30, 1 --> Employee doesn't belong to the appropriate department!
EXEC usp_AssignEmployeeToReport 17, 2 --> (1 row affected)