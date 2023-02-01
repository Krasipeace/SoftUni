-- 1 Find Full Name
CREATE PROC usp_GetHoldersFullName AS
SELECT 
	CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM 
	AccountHolders
	
GO
EXEC usp_GetHoldersFullName


--  2 People with Balance Higher Than 
CREATE PROC usp_GetHoldersWithBalanceHigherThan 
	(@number DECIMAL (18,2)) AS
BEGIN
	SELECT
		ah.FirstName,
		ah.LastName
	FROM 
		AccountHolders AS ah
	JOIN 
		Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY
		a.AccountHolderId,
		ah.FirstName,
		ah.LastName
	HAVING
		SUM(a.Balance) > @number
	ORDER BY 
		FirstName ASC,
		LastName ASC
END

GO
EXEC usp_GetHoldersWithBalanceHigherThan 1234.56


-- 3 Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue
	(@sum MONEY, 
	 @rate FLOAT,
	 @years INT)
RETURNS DECIMAL(20,4) AS
BEGIN
	DECLARE 
		@result DECIMAL(20,4) = @sum * POWER(1 + @rate, @years)
	RETURN @result;
END

GO 
SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)


-- 4 Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount
	(@accountId INT, 
	 @rate FLOAT) AS
BEGIN
	SELECT 
		ah.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @rate, 5) 
			AS [Balance in 5 years]
	FROM 
		AccountHolders AS ah
	JOIN 
		Accounts AS a ON a.Id = ah.Id 
	WHERE 
		a.Id = @accountId
END

GO
EXEC usp_CalculateFutureValueForAccount 1, 0.1
