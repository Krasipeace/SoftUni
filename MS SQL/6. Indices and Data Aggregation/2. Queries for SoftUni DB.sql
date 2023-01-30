-- 1 Departments Total Salaries
SELECT
	DepartmentID,
	SUM(Salary) AS TotalSalary
FROM 
	Employees
GROUP BY 
	DepartmentID
ORDER BY 
	DepartmentID ASC


-- 2 Employees Minimum Salaries
SELECT
	DepartmentID,
	MIN(Salary) AS MinimumSalary
FROM 
	Employees
WHERE 
	DepartmentID IN (2, 5, 7)
GROUP BY 
	DepartmentID


-- 3 Employees Average Salaries 
SELECT * INTO AverageSalaries
FROM 
	Employees AS e
WHERE
	e.Salary > 30000

DELETE FROM 
	AverageSalaries
WHERE 
	ManagerID = 42

UPDATE 
	AverageSalaries
SET 
	Salary = Salary + 5000
WHERE 
	DepartmentID = 1
	
SELECT 
	a.DepartmentID, AVG(a.Salary)
FROM 
	AverageSalaries AS a
GROUP BY 
	a.DepartmentId


-- 4 Employees Maximum Salaries
SELECT 
	DepartmentID,
	MAX(Salary) AS MaxSalary
FROM 
	Employees
GROUP BY
	DepartmentID
HAVING NOT
	MAX(Salary) BETWEEN 30000 AND 70000
ORDER BY
	DepartmentID


-- 5 Employees Count Salaries
SELECT 
	COUNT(Salary)
FROM 
	Employees
WHERE 
	ManagerID IS NULL
