-- 1 DDL (Data Definition Language) 

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Municipality VARCHAR(50),
	Province VARCHAR(50)
)

CREATE TABLE Sites 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Establishment VARCHAR(15)
)

CREATE TABLE Tourists 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Age INT CHECK(Age >= 0 AND Age <= 120) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Reward VARCHAR(20)
)

CREATE TABLE SitesTourists 
(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
	PRIMARY KEY (TouristId, SiteID)
)

CREATE TABLE BonusPrizes 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes 
(
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
	PRIMARY KEY (TouristId, BonusPrizeId)
)


-- 2 Insert

INSERT INTO Tourists VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')



-- 3 Update 

UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL


-- 4 Delete

--SELECT * FROM BonusPrizes 
DELETE FROM 
	TouristsBonusPrizes
WHERE 
	BonusPrizeId = 5
DELETE FROM 
	BonusPrizes
WHERE 
	Id = 5


-- 5 Tourists

SELECT 
	[Name], Age, PhoneNumber, Nationality
FROM 
	Tourists
ORDER BY
	Nationality ASC, Age DESC, [Name] ASC


-- 6 Sites with Their Location and Category 

SELECT 
	s.[Name] AS [Site], 
	l.[Name] AS [Location], 
	s.Establishment, 
	c.[Name] AS [Category]
FROM 
	Sites AS s 
LEFT JOIN Locations AS l
	ON s.LocationId = l.Id
LEFT JOIN Categories AS c 
	ON s.CategoryId = c.Id
ORDER BY 
	c.[Name] DESC, l.[Name] ASC, s.[Name] ASC


-- 7 Count of sites in Sofia province

SELECT 
	l.Province, 
	l.Municipality, 
	l.[Name] AS [Location], 
	COUNT(s.Id) AS CountOfSites
FROM Sites AS s
JOIN Locations as l
	ON s.LocationId = l.Id
WHERE 
	l.Province = 'Sofia'
GROUP BY
	l.Province, l.Municipality, l.[Name]
ORDER BY
	COUNT(s.Id) DESC, 
	l.[Name] ASC


-- 8 Tourist Sites established BC

SELECT 
	s.[Name] AS [Site],
	l.[Name] AS [Location],
	l.Municipality,
	l.Province,
	s.Establishment
FROM Sites AS s
JOIN Locations AS l 
	ON s.LocationId = l.Id 
WHERE LEFT(l.[Name], 1) NOT IN ('B','M','D')
	AND RIGHT(s.Establishment, 2) = 'BC'
ORDER BY 
	s.[Name] ASC


-- 9 Tourists with their bonus prizes

SELECT
	t.[Name], 
	t.Age, 
	t.PhoneNumber, 
	t.Nationality,
	ISNULL(bp.[Name], '(no bonus prize)') AS [Reward]
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tb 
	ON t.Id = tb.TouristId
LEFT JOIN BonusPrizes AS bp
	ON tb.BonusPrizeId = bp.Id
ORDER BY 
	t.[Name] ASC


-- 10 Tourists visiting History and Archaeology sites

SELECT DISTINCT
	SUBSTRING(t.Name, CHARINDEX(' ', t.Name) + 1, LEN(t.Name)) 
		AS [LastName], 
	t.Nationality, 
	t.Age, 
	t.PhoneNumber
FROM Tourists AS t
JOIN 
	SitesTourists  AS st 
		ON t.Id = st.TouristId
JOIN 
	Sites AS s 
		ON st.SiteId = s.Id
JOIN 
	Categories AS c 
		ON s.CategoryId = c.Id
WHERE 
	c.[Name] = 'History and archaeology'
ORDER BY 
	[LastName] ASC


-- 11 Tourists Count on a Tourist Site

CREATE FUNCTION udf_GetTouristsCountOnATouristSite 
	(@Site VARCHAR(MAX)) 
RETURNS INT AS
BEGIN
	DECLARE @siteId INT = 
		(SELECT Id FROM Sites WHERE [Name] = @Site)
	DECLARE @count INT = 
		(SELECT COUNT(TouristId) FROM SitesTourists WHERE SiteId = @siteId)
RETURN @count
END

-- SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River') -- 7


-- 12 Annual Reward Lottery

CREATE PROC usp_AnnualRewardLottery
	(@TouristName VARCHAR(MAX)) AS 
BEGIN
	DECLARE @id INT = 
		(SELECT Id FROM Tourists WHERE Name = @TouristName)     
	DECLARE @count INT = 
		(SELECT COUNT(SiteId) FROM SitesTourists WHERE TouristId = @id)
	DECLARE @reward VARCHAR(20) = NULL

	IF (@count >= 100) 
		SET @reward = 'Gold badge'
	ELSE IF (@count >= 50) 
		SET @reward = 'Silver badge'
	ELSE IF (@count >= 25) 
		SET @reward = 'Bronze badge'

	IF (@reward IS NOT NULL)
		UPDATE Tourists
		SET Reward = @reward
		WHERE Id = @id

	SELECT Name, Reward FROM Tourists WHERE Id = @id 
END


-- Tests: 
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Brus Brown'