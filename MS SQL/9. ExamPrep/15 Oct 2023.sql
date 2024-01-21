-- 0. DB INIT
CREATE DATABASE TouristAgency

USE TouristAgency

GO

-- 1. DDL

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	BedCount INT NOT NULL CHECK (BedCount BETWEEN 1 AND 10)
)

CREATE TABLE Destinations
(
	Id Int PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
)

CREATE TABLE Tourists
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Bookings
(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL CHECK (AdultsCount BETWEEN 1 AND 10),
	ChildrenCount INT NOT NULL CHECK (ChildrenCount BETWEEN 0 AND 9),
	TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
)

CREATE TABLE HotelsRooms
(
	HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
	RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id),
	PRIMARY KEY(HotelId, RoomId)
)

-- 2. Insert

INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
	VALUES
		('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
		('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
		('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
		('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
		('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
	VALUES
		('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
		('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
		('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
		('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
		('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

-- 3. Update

UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE DepartureDate BETWEEN '2023-12-1' AND '2023-12-31'

UPDATE Tourists
SET Email = NULL
WHERE [Name] LIKE '%MA%'

-- 4. Delete

ALTER TABLE Bookings
ADD CONSTRAINT foreignkeys
FOREIGN KEY (TouristId) REFERENCES Tourists(Id)
ON DELETE CASCADE

BEGIN TRANSACTION

DELETE FROM Tourists
WHERE [Name] LIKE '%Smith%'

COMMIT

-- 5. Bookings by Price of Room and Arrival Date

SELECT 
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
	AdultsCount, 
	ChildrenCount
FROM 
	Bookings AS b
JOIN 
	Rooms AS r ON r.Id = b.RoomId
ORDER BY 
	r.Price DESC, 
	b.ArrivalDate ASC

-- 6. Hotels by Count of Bookings

SELECT 
	h.Id, 
	h.[Name]
FROM 
	Hotels AS h
INNER JOIN 
	HotelsRooms AS hr ON hr.HotelId = h.Id
INNER JOIN 
	Rooms AS r ON r.Id = hr.RoomId
INNER JOIN 
	Bookings AS b ON b.HotelId = h.Id
		AND r.[Type] = 'VIP Apartment'
GROUP BY 
	h.Id, 
	h.[Name]
ORDER BY 
	COUNT(*) DESC

-- 7. Tourists without Bookings

SELECT 
	t.Id,
	t.[Name],
	t.PhoneNumber
FROM 
	Tourists AS t
LEFT JOIN 
	Bookings AS b ON b.TouristId = t.Id
WHERE
	b.TouristId IS NULL
ORDER BY
	t.[Name] ASC

-- 8. First 10 Bookings

SELECT TOP 10
	h.[Name] AS HotelName,
	d.[Name] AS DestinationName,
	c.[Name] AS CountryName
FROM 
	Bookings AS b
JOIN 
	Tourists AS t ON t.Id = b.TouristId
JOIN 
	Hotels AS h ON h.Id = b.HotelId
JOIN 
	Destinations AS d ON d.Id = h.DestinationId
JOIN 
	Countries AS c ON c.Id = d.CountryId
WHERE
	b.HotelId % 2 = 1 AND b.ArrivalDate < '2023-12-31'
ORDER BY
	c.[Name] ASC,
	b.ArrivalDate ASC

-- 9. Tourists booked in Hotels

SELECT
	h.[Name] AS HotelName,
	r.Price AS RoomPrice
FROM 
	Tourists AS t
JOIN 
	Bookings AS b ON b.TouristId = t.Id
JOIN 
	Hotels AS h ON h.Id = b.HotelId
JOIN 
	Rooms AS r ON r.Id = b.RoomId
WHERE
	RIGHT(t.[Name], 2) != 'EZ'
ORDER BY
	r.Price DESC

-- 10. Hotels Revenue

SELECT 
	h.[Name] AS HotelName,
	SUM(r.Price * DATEDIFF(day, b.ArrivalDate, b.DepartureDate)) AS HotelRevenue
FROM 
	Bookings AS b
JOIN 
	Hotels AS h ON h.Id = b.HotelId
JOIN 
	Rooms AS r ON r.Id = b.RoomId
GROUP BY
	h.[Name]
ORDER BY
	HotelRevenue DESC

-- 11. Rooms with Tourists

CREATE FUNCTION udf_RoomsWithTourists(@roomName VARCHAR(40))
RETURNS INT 
AS
	BEGIN
		DECLARE @totalNumberTourists INT
		
		SELECT
			@totalNumberTourists = SUM(AdultsCount + ChildrenCount)
		FROM
			Bookings AS b
		JOIN
			Rooms AS r ON r.Id = b.RoomId
		WHERE
			r.[Type] = @roomName

		RETURN @totalNumberTourists
	END

	--Test:
		SELECT 
			dbo.udf_RoomsWithTourists('Double Room') 

-- 12. Search for Tourists from a Specific Country

CREATE PROCEDURE usp_SearchByCountry(@countryName NVARCHAR(50))
AS
	BEGIN
		DECLARE @CountryId INT

		SELECT
			@CountryId = Id
		FROM 
			Countries
		WHERE
			[Name] = @countryName

		SELECT
			t.[Name],
			t.[PhoneNumber],
			t.Email,
			COUNT(b.Id) AS CountOfBookings
		FROM 
			Tourists as t
		INNER JOIN 
			Bookings as b ON b.TouristId = t.Id
		WHERE
			t.CountryId = @CountryId
		GROUP BY
			t.[Name],
			t.PhoneNumber,
			t.Email
		ORDER BY
			t.[Name] ASC,
			CountOfBookings DESC
	END

	-- Test:
		EXEC dbo.usp_SearchByCountry 'Greece'