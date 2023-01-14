-- 1 Find All the Information About Departments
SELECT DepartmentID, [Name], ManagerID
FROM Departments


-- 2 Find all Department Names 
SELECT [Name]
FROM Departments


-- 3 Find Salary of Each Employee
SELECT FirstName, LastName, Salary
FROM Employees


-- 4 Find Full Name of Each Employee 
SELECT FirstName, MiddleName, LastName
FROM Employees


-- 5 Find Email Address of Each Employee 
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
FROM Employees


-- 6 Find All Different Employee’s Salaries
SELECT DISTINCT Salary 
FROM Employees 
ORDER BY Salary ASC


-- 7 Find All Information About Employees
SELECT * FROM Employees 
WHERE JobTitle = 'Sales Representative'
ORDER BY EmployeeID 


-- 8 Find Names of All Employees by Salary in Range
SELECT FirstName, LastName, JobTitle
FROM Employees
WHERE Salary >= 20000 AND Salary <= 30000


-- 9 Find Names of All Employees
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)


-- 10 Find All Employees Without Manager
SELECT FirstName, LastName
FROM Employees
WHERE ManagerID IS NULL


-- 11 Find All Employees with Salary More Than
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary > 50000 
ORDER BY Salary DESC


-- 12 Find 5 Best Paid Employees
SELECT TOP (5) FirstName, LastName
FROM Employees
ORDER BY Salary DESC


-- 13 Find All Employees Except Marketing 
SELECT FirstName, LastName
FROM Employees
WHERE NOT DepartmentID = 4


-- 14 Sort Employees Table 
SELECT * FROM Employees
ORDER BY Salary DESC, FirstName ASC, LastName DESC, MiddleName ASC


-- 15 Create View Employees with Salaries
CREATE VIEW V_EmployeesSalaries AS
	SELECT FirstName, LastName, Salary
	FROM Employees
SELECT * FROM V_EmployeesSalaries


-- 16 Create View Employees with Job Titles 
CREATE VIEW V_EmployeeNameJobTitle AS 
	SELECT CONCAT (FirstName ,' ',MiddleName, ' ',LastName )  AS [Full Name], JobTitle
	FROM Employees
SELECT * FROM V_EmployeeNameJobTitle


-- 17 Distinct Job Titles
SELECT DISTINCT JobTitle
FROM Employees


-- 18 Find First 10 Started Projects
SELECT TOP(10) * FROM Projects
ORDER BY StartDate ASC, [Name]


-- 19 Last 7 Hired Employees 
SELECT TOP(7) FirstName, LastName, HireDate
FROM Employees
ORDER BY HireDate DESC


-- 20 Increase Salaries
-- SELECT * FROM Departments
UPDATE Employees
SET Salary += Salary * 0.12  
WHERE DepartmentID IN (1, 2, 4, 11)
SELECT Salary 
FROM Employees