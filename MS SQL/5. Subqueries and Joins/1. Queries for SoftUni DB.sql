-- 1 Employee Address
SELECT TOP (5)
	e.EmployeeID AS [EmployeeId], 
	e.JobTitle, 
	e.AddressID AS [AddressId], 
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
ORDER BY AddressID ASC


-- 2 Addresses with Towns
SELECT TOP (50)
	FirstName,
	LastName,
	[Name] AS Town,
	AddressText
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
ORDER BY FirstName ASC, LastName ASC


-- 3 Sales Employee
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE [Name] LIKE 'Sales'
ORDER BY EmployeeID ASC


-- 4 Employee Departments
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID ASC


-- 5 Employees without Project
SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY EmployeeID ASC


-- 6 Employees Hired After
SELECT 
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS DeptName 
FROM Employees AS e
JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
WHERE 
	e.HireDate > '1999-01-01 23:59:59' 
	AND d.[Name] IN ('Sales','Finance')
ORDER BY HireDate ASC


-- 7 Employees With Project
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS [ProjectName]
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE 
	p.StartDate > '2002-08-13'
	AND p.EndDate IS NULL
ORDER BY EmployeeID ASC


-- 8 Employee 24
SELECT
	e.EmployeeID,
	e.FirstName,
	CASE 
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24


-- 9 Employee Manager 
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS ManagerName
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID ASC


-- 10 Employees Summary
SELECT TOP (50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID ASC


-- 11 Min Average Salary
SELECT MIN(s.AvgSalary)
FROM 
	(
		SELECT AVG(Salary) AS AvgSalary
		FROM Employees
		GROUP BY DepartmentID
	) AS s










