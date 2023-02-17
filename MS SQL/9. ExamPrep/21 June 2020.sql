-- 1 DDL

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18, 2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id)
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK (BookDate < ArrivalDate),
	CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT NOT NULL FOREIGN KEY REFERENCES Cities(Id),
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	TripId INT NOT NULL FOREIGN KEY REFERENCES Trips(Id),
	Luggage INT NOT NULL CHECK (Luggage > 0),
	PRIMARY KEY (AccountId, TripId)
)


-- 2 Insert

INSERT INTO Accounts (FirstName, MiddleName, LastName, CityId, BirthDate, Email)
VALUES

	('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
	('Gosho', NULL, 'Petrov',  11, '1978-05-16', 'g_petrov@gmail.com'),
	('Ivan', 'Petrovich', 'Pavlov',  59, '1849-09-26', 'i_pavlov@softuni.bg'),
	('Friedrich', 'Wilhelm', 'Nietzsche',  2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES

	(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
	(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
	(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
	(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
	(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)


-- 3 Update

UPDATE Rooms
SET Price = Price + (0.14 * Price)
WHERE HotelId IN (5, 7 ,9)


-- 4 Delete

DELETE FROM AccountsTrips 
WHERE AccountId = 47

DELETE FROM Accounts
WHERE Id = 47


-- 5 EEE-Mails

SELECT
	a.FirstName,
	a.LastName,
	FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	c.[Name] AS Hometown,
	a.Email
FROM 
	Accounts AS a
JOIN 
	Cities AS c ON c.Id = a.CityId
WHERE
	Email LIKE 'e%'
ORDER BY
	c.[Name] ASC


-- 6 City Statistics

SELECT 
	c.[Name] AS City,
	COUNT(h.Id) AS Hotels
FROM 
	Cities AS c
JOIN 
	Hotels AS h ON h.CityId = c.Id
GROUP BY 
	c.[Name]
ORDER BY
	COUNT(h.Id) DESC,
	c.[Name] ASC


-- 7 Longest and Shortest Trips

SELECT 
	a.Id AS AccountId,
	CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
	MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
	MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM 
	Accounts AS a
JOIN 
	AccountsTrips AS acct ON acct.AccountId = a.Id
JOIN 
	Trips AS t ON t.Id = acct.TripId
WHERE 
	a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY
	a.Id,
	CONCAT(a.FirstName, ' ', a.LastName)
ORDER BY
	LongestTrip DESC,
	ShortestTrip ASC


-- 8 Metropolis

SELECT TOP (10)
	c.Id,
	c.[Name] AS City,
	c.CountryCode AS Country,
	COUNT(a.Id) AS Accounts
FROM
	Cities AS c
JOIN 
	Accounts AS a ON a.CityId = c.Id
GROUP BY
	c.Id,
	c.[Name],
	c.CountryCode
ORDER BY
	COUNT(a.Id) DESC


-- 9 Romantic Getaways

SELECT 
	a.Id, 
	a.Email, 
	c.[Name],
	COUNT(t.Id) AS Trips 
FROM 
	Accounts AS a 
JOIN 
	AccountsTrips AS acct ON a.Id = acct.AccountId
JOIN 
	Trips AS t ON acct.TripId = t.Id
JOIN 
	Rooms AS r ON t.RoomId = r.Id
JOIN 
	Hotels AS h ON r.HotelId = h.Id
JOIN 
	Cities AS c ON h.CityId = c.Id
WHERE 
	a.CityId = c.Id
GROUP BY 
	a.Id, 
	a.Email, 
	c.[Name]
ORDER BY 
	COUNT(t.Id) DESC, 
	a.Id ASC


-- 10 GDPR Violation

SELECT 
	t.Id,
    CASE
		WHEN a.MiddleName IS NULL 
			THEN CONCAT(a.FirstName, ' ', a.LastName)
		WHEN a.MiddleName IS NOT NULL 
			THEN CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName)
		END AS [Full Name],
	c.[Name] AS [From],
	c2.[Name] AS [To],
	CASE
		WHEN t.CancelDate IS NOT NULL 
			THEN 'Canceled'
		WHEN t.CancelDate IS NULL 
			THEN CAST(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate) AS VARCHAR) + ' days'
	END AS [Duration]
FROM 
	Trips AS t
JOIN 
	AccountsTrips AS att ON t.Id = att.TripId
JOIN 
	Accounts AS a ON att.AccountId = a.Id
JOIN 
	Cities AS c ON a.CityId = c.Id
JOIN 
	Rooms AS r ON t.RoomId = r.Id
JOIN 
	Hotels AS h ON r.HotelId = h.Id
JOIN 
	Cities AS c2 ON h.CityId = c2.Id
ORDER BY 
	[Full Name] ASC, 
	t.Id ASC


-- 11 Available Room

CREATE FUNCTION udf_GetAvailableRoom 
	(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(255) AS
BEGIN
DECLARE @result VARCHAR(255) = 
(
	SELECT 'Room ' 
		+ CAST(temp.RoomId AS VARCHAR) 
		+ ': ' 
		+ temp.RoomType 
		+ ' (' + CAST(temp.Beds AS VARCHAR) 
		+ ' beds) - $' + CAST(temp.TotalPrice AS VARCHAR)
	FROM
	(
		SELECT TOP (1) 
			r.Id AS RoomId, 
			r.[Type] AS RoomType,
			r.Beds AS Beds,
			(r.Price + h.BaseRate) * @People AS TotalPrice
		FROM Rooms AS r
		JOIN Trips AS t ON r.Id = t.RoomId
		JOIN Hotels AS h ON r.HotelId = h.Id
		WHERE         
			HotelId = @HotelId 
			AND Beds >= @People
			AND r.Id NOT IN
				(
					SELECT 
						RoomId 
					FROM 
						Trips
					WHERE @Date 
						BETWEEN ArrivalDate AND ReturnDate 
						AND CancelDate IS NULL
				)
    ORDER BY TotalPrice DESC) AS temp
	)

RETURN ISNULL(@result, 'No rooms available')
END

-- Test: 
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
--> Room 211: First Class (5 beds) - $202.80
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)
--> No rooms available


-- 12 Switch Room

CREATE PROCEDURE usp_SwitchRoom
	(@TripId INT, @TargetRoomId INT) AS
BEGIN

	DECLARE @roomHotelId INT = 
	(
	    SELECT h.Id 
		FROM Hotels AS h
	    JOIN Rooms AS r 
			ON h.Id = r.HotelId
	    WHERE r.Id = @TargetRoomId
	)

	DECLARE @tripHotelId INT =
	(
	    SELECT h.Id 
		FROM Hotels AS h
	    JOIN Rooms AS r 
			ON h.Id = r.HotelId
	    JOIN Trips AS t 
			ON r.Id = t.RoomId
	    WHERE t.Id = @TripId
	)

	DECLARE @people INT = 
	(
	    SELECT COUNT(*) 
		FROM Accounts AS a
	    JOIN AccountsTrips AS at 
			ON a.Id = at.AccountId
	    JOIN Trips AS t 
			ON at.TripId = t.Id
	    WHERE t.Id = @TripId
	)

	IF (@roomHotelId <> @tripHotelId) 
		THROW 50001, 'Target room is in another hotel!', 1

	IF ((SELECT Beds FROM Rooms WHERE Id = @TargetRoomId) < @people) 
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE 
		Trips
	SET 
		RoomId = @TargetRoomId
	WHERE 
		Id = @TripId
END

-- Tests:
EXEC usp_SwitchRoom 10, 11 --> 11
SELECT RoomId FROM Trips WHERE Id = 10  --> 11

EXEC usp_SwitchRoom 10, 7 --> Target room is in another hotel!
EXEC usp_SwitchRoom 10, 8 --> Not enough beds in target room!