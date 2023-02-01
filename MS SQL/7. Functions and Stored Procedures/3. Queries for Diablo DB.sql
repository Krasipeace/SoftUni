-- 1 *Cash in User Games Odd Rows 
CREATE FUNCTION 
	ufn_CashInUsersGames(@gameName NVARCHAR(100))
RETURNS TABLE AS 
RETURN SELECT
(
	SELECT SUM(c.Cash) AS [SumCash] FROM
	(
		SELECT 
			g.Name,
			ug.Cash,
			ROW_NUMBER() OVER
			(
				PARTITION BY 
					g.Name 
				ORDER BY 
					ug.Cash DESC
			) AS RowNumber
		FROM 
			UsersGames ug
		INNER JOIN 
			Games g ON ug.GameId = g.Id
		WHERE 
			g.Name = @gameName
	) AS c
	WHERE 
		RowNumber % 2 <> 0
) As [SumCash]

GO
SELECT * FROM ufn_CashInUsersGames('Lavender');