-- 1 Find Names of all employees by first name
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'


-- 2 Find names of all employees by last name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'


-- 3 Find first names of all employees
SELECT FirstName
FROM Employees
WHERE 
	(DepartmentID = 3 OR DepartmentID = 10) AND
	(YEAR(HireDate) BETWEEN 1995 AND 2005)


-- 4 Find all employees except engineers
SELECT FirstName, LastName
FROM Employees
WHERE NOT JobTitle LIKE '%engineer%'


-- 5 Find towns with name length
SELECT [Name]
FROM Towns
WHERE LEN(Name) BETWEEN 5 AND 6
ORDER BY [Name] ASC


-- 6 Find towns startng with
SELECT TownID, [Name]
FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name] ASC


-- 7 Find towns not starting with 
SELECT TownID, [Name]
FROM Towns
WHERE NOT [Name] LIKE '[RBD]%'
ORDER BY [Name] ASC


-- 8 Create view employees hired after 2000 year
CREATE VIEW [V_EmployeesHiredAfter2000] AS 
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000


-- 9 Length of last name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5


-- 10 Rank employees by salary
SELECT 
	EmployeeID, 
	FirstName, 
	LastName, 
	Salary, 
	DENSE_RANK() OVER   
		(
			PARTITION BY Salary 
			ORDER BY EmployeeID ASC
		) 
		AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC


-- 11 Find all employees with rank 2
SELECT *
FROM 
	(
		SELECT 
			EmployeeID,
			FirstName,
			LastName,
			Salary,
			DENSE_RANK() OVER 
				(
					PARTITION BY Salary 
					ORDER BY EmployeeID ASC
				) 
				AS Rank
       FROM Employees
       WHERE Salary BETWEEN 10000 AND 50000
	) 
	AS RankedTable
WHERE Rank = 2
ORDER BY Salary DESC