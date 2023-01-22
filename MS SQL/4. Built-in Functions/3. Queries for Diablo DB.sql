-- 1 Games from 2011 and 2012 year
SELECT TOP (50)
	[Name], 
	FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY 
	[Start] ASC, 
	[Name] ASC


-- 2 User e-mail providers
SELECT 
	Username, 
	SUBSTRING
		(
			Email, 
			CHARINDEX('@', Email) + 1,
			LEN(Email)
		) 
	AS [Email Provider]
FROM Users
ORDER BY 
	[Email Provider] ASC, 
	Username ASC


-- 3 Get users with IP address like pattern
SELECT Username, IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username ASC


-- 4 Show all games with duration and part of the day
SELECT 
	g.Name AS [Game],
	CASE 
		WHEN DATEPART(HOUR, g.START) 
			Between 0 and 11 THEN 'Morning'
		WHEN DATEPART(HOUR, g.START) 
			Between 12 and 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, g.START) 
			Between 18 and 23 THEN 'Evening'
		END AS [Part of the Day],
	CASE
		WHEN g.Duration <= 3 
			THEN 'Extra Short'
		WHEN g.Duration Between 4 AND 6 
			THEN 'Short'
		WHEN g.Duration > 6 
			THEN 'Long'
		WHEN g.Duration IS NULL 
			THEN 'Extra Long'
	END AS [Duration]
FROM Games AS g
ORDER BY 
	[Game] ASC, 
	[Duration] ASC, 
	[Part of the Day] ASC