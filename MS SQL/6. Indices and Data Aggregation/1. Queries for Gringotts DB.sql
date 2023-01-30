-- 1 Record's Count
SELECT COUNT(Id) AS Count
FROM WizzardDeposits


-- 2 Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits


-- 3 Longest Magic Wand per Deposit Groups
SELECT 
	DepositGroup, 
	MAX(MagicWandSize) AS LongestMagicWand
FROM 
	WizzardDeposits
GROUP BY 
	DepositGroup


-- 4 *Smallest Deposit Group per Magic Wand Size
SELECT TOP (2)
	DepositGroup
FROM 
	WizzardDeposits
GROUP BY 
	DepositGroup
ORDER BY 
	AVG(MagicWandSize)


-- 5 Deposits Sum
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup


-- 6 Deposits Sum for Olivander Family
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM 
	WizzardDeposits
WHERE 
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup


-- 7 Deposits Filter
SELECT 
	DepositGroup,
	SUM(DepositAmount) AS TotalSum
FROM 
	WizzardDeposits
WHERE 
	MagicWandCreator = 'Ollivander family'
GROUP BY 
	DepositGroup
HAVING 
	SUM(DepositAmount) < 150000
ORDER BY	
	TotalSum DESC


-- 8 Deposit Charge
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
FROM 
	WizzardDeposits
GROUP BY 
	DepositGroup,
	MagicWandCreator
ORDER BY 
	MagicWandCreator ASC,
	DepositGroup ASC


-- 9 Age Groups
SELECT
	CASE	
		WHEN age <= 10 
			THEN '[0-10]'
		WHEN age <= 20 
			THEN '[11-20]'
		WHEN age <= 30 
			THEN '[21-30]'
		WHEN age <= 40 
			THEN '[31-40]'
		WHEN age <= 50 
			THEN '[41-50]'
		WHEN age <= 60 
			THEN '[51-60]'
		ELSE '[61+]'
	END AS AgeGroup,
	COUNT(*) AS WizardCount
FROM 
	WizzardDeposits
GROUP BY 
	CASE	
		WHEN age <= 10 
			THEN '[0-10]'
		WHEN age <= 20 
			THEN '[11-20]'
		WHEN age <= 30 
			THEN '[21-30]'
		WHEN age <= 40 
			THEN '[31-40]'
		WHEN age <= 50 
			THEN '[41-50]'
		WHEN age <= 60 
			THEN '[51-60]'
		ELSE '[61+]'
	END;
	

--10 First Letter
SELECT
	LEFT(FirstName, 1) AS FirstLetter
FROM 
	WizzardDeposits
WHERE
	DepositGroup = 'Troll Chest'
GROUP BY 
	LEFT(FirstName, 1)
ORDER BY 
	FirstLetter ASC


-- 11 Average Interest
SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS DepositInterest
FROM 
	WizzardDeposits
WHERE 
	DepositStartDate > '1985-01-01'
GROUP BY
	DepositGroup,
	IsDepositExpired
ORDER BY 
	DepositGroup DESC,
	IsDepositExpired ASC


-- 12 *Rich Wizard, Poor Wizard 
SELECT 
	SUM(rw.DepositAmount - pw.DepositAmount) AS SumDifference
FROM 
	WizzardDeposits AS rw,
	WizzardDeposits AS pw
WHERE
	pw.Id - rw.Id = 1;