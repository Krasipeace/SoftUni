-- 1 Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
	(@result int = 1) AS
SELECT 
	FirstName, 
	LastName
FROM 
	Employees
WHERE 
   Salary > 35000

GO
EXEC usp_GetEmployeesSalaryAbove35000


-- 2 Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber
	(@number DECIMAL(18,4)) AS
SELECT 
	FirstName, 
	LastName
FROM 
	Employees
WHERE 
	Salary >= @number

GO
EXEC usp_GetEmployeesSalaryAboveNumber


-- 3 Town Names Starting With 
CREATE PROC usp_GetTownsStartingWith
	(@startsWith VARCHAR(100)) AS
	SELECT 
		[Name] AS Town
	FROM 
		Towns
	WHERE
		SUBSTRING([Name], 1,LEN(@startsWith)) = @startsWith

GO
EXEC usp_GetTownsStartingWith c


-- 4 Employees from Town 
CREATE PROC usp_GetEmployeesFromTown
	(@townName VARCHAR(100)) AS
SELECT
	e.FirstName AS [First Name],
	e.LastName AS [Last Name]
FROM 
	Employees AS e
JOIN
	Addresses AS a ON e.AddressID = a.AddressID
JOIN 
	Towns AS t ON a.TownID = t.TownID
WHERE 
	t.Name = @townName

GO
EXEC usp_GetEmployeesFromTown Calgary


-- 5 Salary Level Function 
CREATE FUNCTION ufn_GetSalaryLevel
	(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10) AS
BEGIN
	RETURN CASE
		WHEN 
			@salary < 30000 
				THEN 'Low'
		WHEN 
			@salary <= 50000 
				THEN 'Average'
		ELSE
			'High'
	END
END

GO
EXEC ufn_GetSalaryLevel 


-- 6 Employees by Salary Level 
CREATE PROC usp_EmployeesBySalaryLevel
	(@salaryLevel VARCHAR(7)) AS 
SELECT
	FirstName,
	LastName
FROM 
	Employees
WHERE 
	dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel

GO
EXEC usp_EmployeesBySalaryLevel Average 


-- 7 Define Function
CREATE FUNCTION ufn_IsWordComprised
	(@setOfLetters VARCHAR(30), 
	 @word VARCHAR(30))
RETURNS BIT AS
BEGIN
     DECLARE @index INT = 1
     DECLARE @length INT = LEN(@word)
     DECLARE @letter CHAR(1)

     WHILE (@index <= @length)
     BEGIN
          SET @letter = SUBSTRING(@word, @index, 1)
          IF (CHARINDEX(@letter, @setOfLetters) > 0)
             SET @index = @index + 1
          ELSE
             RETURN 0
     END
     RETURN 1
END 

GO
EXEC ufn_IsWordComprised dsada,DAS


-- 8 *Delete Employees and Departments 
CREATE PROC usp_DeleteEmployeesFromDepartment 
	(@departmentId INT) AS
DECLARE @empIDsToBeDeleted TABLE
	(Id int)

INSERT INTO 
	@empIDsToBeDeleted
SELECT 
	e.EmployeeID
FROM 
	Employees AS e
WHERE 
	e.DepartmentID = @departmentId

ALTER TABLE 
	Departments
ALTER COLUMN 
	ManagerID int NULL

DELETE FROM 
	EmployeesProjects
WHERE 
	EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Employees
SET ManagerID = NULL
WHERE 
	ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

UPDATE Departments
SET ManagerID = NULL
WHERE 
	ManagerID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Employees
WHERE 
	EmployeeID IN (SELECT Id FROM @empIDsToBeDeleted)

DELETE FROM Departments
WHERE 
	DepartmentID = @departmentId 

SELECT COUNT(*) AS [Employees Count] 
FROM 
	Employees AS e
JOIN 
	Departments AS d
ON 
	d.DepartmentID = e.DepartmentID
WHERE 
	e.DepartmentID = @departmentId

GO
--EXEC usp_DeleteEmployeesFromDepartment 