-- 1 ddl

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(100) NOT NULL,
	StreetNumber INT NOT NULL,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(50),
	ZIP INT NOT NULL
)

CREATE TABLE Publishers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) UNIQUE NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id),
	Website NVARCHAR(40), 
	Phone NVARCHAR(20)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Creators
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(30) NOT NULL
)

CREATE TABLE PlayersRanges
(
	Id INT PRIMARY KEY IDENTITY,
	PlayersMin INT NOT NULL,
	PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	YearPublished INT NOT NULL,
	Rating DECIMAL(18, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	PublisherId INT FOREIGN KEY REFERENCES Publishers(Id) NOT NULL,
	PlayersRangeId INT FOREIGN KEY REFERENCES PlayersRanges(Id) NOT NULL
)

CREATE TABLE CreatorsBoardgames
(
	CreatorId INT FOREIGN KEY REFERENCES Creators(Id),
	BoardgameId INT FOREIGN KEY REFERENCES Boardgames(Id),
	PRIMARY KEY (CreatorId, BoardgameId)
)


-- 2 Insert

INSERT INTO Boardgames ([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId)
VALUES

	('Deep Blue', 2019, 5.67, 1, 15, 7),
	('Paris', 2016, 9.78, 7, 1, 5),
	('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
	('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
	('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers ([Name], AddressId, Website, Phone) 
VALUES

	('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
	('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
	('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


-- 3 uPDATE

UPDATE PlayersRanges 
SET PlayersMax = PlayersMax + 1
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames
SET [Name] = [Name] + 'V2'
WHERE YearPublished >= 2020

-- 4 delete
--(0/4)

-- 5 Boardgames by Year of Publication

SELECT [Name], Rating
FROM Boardgames
ORDER BY YearPublished ASC, [Name] DESC


-- 6 Boardgames by Category

SELECT 
	b.Id, 
	b.[Name], 
	b.YearPublished, 
	c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE c.[Name] = 'Wargames' OR c.[Name] = 'Strategy Games'
ORDER BY YearPublished DESC


-- 7 Creators without Boardgames

SELECT 
	c.Id, 
	CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
	c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
LEFT JOIN Boardgames AS b ON b.Id = cb.CreatorId
WHERE b.[Name] IS NULL
ORDER BY CONCAT(c.FirstName, ' ', c.LastName) ASC


-- 8 First 5 Boardgames

SELECT TOP (5)
	b.[Name],
	b.Rating,
	c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE ((b.Rating > 7.00 AND b.[Name] LIKE '%a%')
	OR (b.Rating > 7.50 AND (pr.PlayersMax = 5 AND pr.PlayersMin = 2)))
ORDER BY b.[Name] ASC, Rating DESC


-- 9 Creators with Emails

SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	c.Email,
	MAX(b.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON c.Id = cb.CreatorId
JOIN Boardgames AS b ON cb.BoardgameId = b.Id
WHERE 
	c.Email LIKE '%.com'
GROUP BY 
	CONCAT(c.FirstName, ' ', c.LastName), 
	c.Email
ORDER BY CONCAT(c.FirstName, ' ', c.LastName) ASC


-- 10 Creators by Rating

SELECT 
	c.LastName,
	CEILING(AVG(b.Rating)) AS AverageRating,
	p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE 
	p.[Name] = 'Stonemaier Games'
GROUP BY 
	c.LastName, 
	p.[Name]
ORDER BY AVG(b.Rating) DESC

-- 11 Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames
	(@name NVARCHAR(30)) 
RETURNS INT AS
BEGIN
	RETURN 
	(
		SELECT COUNT(*)
		FROM Creators AS c
		JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
		WHERE c.FirstName = @name
	)
END

--TEST: 
SELECT dbo.udf_CreatorWithBoardgames('Bruno') --> 13


--12 Search for Boardgame with Specific Category

CREATE PROC usp_SearchByCategory 
	(@category VARCHAR(MAX)) AS
SELECT 
	b.[Name],
	b.YearPublished,
	b.Rating,
	c.[Name] AS CategoryName,
	p.[Name] AS PublisherName,
	CONCAT(pr.PlayersMin, ' people') AS MinPlayers,
	CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN Publishers AS p ON p.Id = b.PublisherId
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE c.[Name] = @category
ORDER BY 
	p.[Name] ASC,
	b.YearPublished DESC

--TEST:
EXEC usp_SearchByCategory 'Wargames'
