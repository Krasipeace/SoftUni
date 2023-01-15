-- 1 All Diablo Characters
SELECT [Name] FROM Characters 
ORDER BY [Name] ASC


-- 2 Number of Users for Email Provider
SELECT RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider], 
	COUNT(Email) [Number Of Users]
FROM Users
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC


-- 3 All Users in Games
SELECT	
	Games.Name AS [Game], 
	GameTypes.Name AS [Game Type],
	Users.Username AS [Username],
	UsersGames.Level AS [Level],
	UsersGames.Cash AS [Cash],
	Characters.Name AS [Character]
FROM Games
RIGHT JOIN GameTypes ON Games.GameTypeId = GameTypes.Id
RIGHT JOIN UsersGames ON Games.Id = UsersGames.GameID
RIGHT JOIN Users ON UsersGames.UserId = Users.Id
RIGHT JOIN Characters ON Characters.Id = UsersGames.CharacterId
ORDER BY [Level] DESC, Username ASC, Game ASC


-- 4 Users in Games with Their Items
SELECT 
	U.Username, G.Name AS Game,
	COUNT(I.Name) AS [Item Count],
	SUM(I.Price) AS [Items Price]
FROM Users AS U
JOIN UsersGames AS UG ON UG.UserId = U.Id
JOIN Games AS G ON G.Id = UG.GameId
JOIN UserGameItems AS UGI ON UGI.UserGameId = UG.Id
JOIN Items AS I ON I.Id = UGI.ItemId
GROUP BY U.Username, G.Name
HAVING COUNT(I.Name) >= 10
ORDER BY [Item Count] DESC, [Items Price] DESC, Username ASC


-- 5 User in Games with Their Statistics


-- 6 All Items with Greater than Average Statistics
SELECT 
	I.Name, 
	I.Price, 
	I.MinLevel, 
	S.Strength, 
	S.Defence, 
	S.Speed, 
	S.Luck, 
	S.Mind
FROM Items AS I
JOIN [Statistics] S on S.Id = I.StatisticId
WHERE 
	S.Mind > (SELECT AVG(Mind) FROM [Statistics]) AND
    S.Luck > (SELECT AVG(Luck) FROM [Statistics]) AND
    S.Speed > (SELECT AVG(Speed) FROM [Statistics])
ORDER BY I.Name ASC 


-- 7 Display All Items about Forbidden Game Type
SELECT 
	I.Name AS [Item],
	I.Price,
	I.MinLevel,
	GT.Name AS [Forbidden Game Type]
FROM Items I
LEFT JOIN GameTypeForbiddenItems GTFI ON I.Id = GTFI.ItemId
LEFT JOIN GameTypes GT ON GTFI.GameTypeId = GT.Id
ORDER BY GT.Name DESC , I.Name ASC


-- 8 Buy Items for User in Game
