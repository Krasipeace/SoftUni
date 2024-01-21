-- 0. Init 

CREATE DATABASE RailwaysDb

USE RailwaysDb

GO

-- 1. DDL

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Trains
(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id),
	ArrivalTownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE TrainsRailwayStations
(
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
	RailwayStationId INT NOT NULL FOREIGN KEY REFERENCES RailwayStations(Id),
	PRIMARY KEY(TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords
(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATETIME2 NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id)
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(18, 2) NOT NULL,
	DateOfDeparture DATETIME2 NOT NULL,
	DateOfArrival DATETIME2 NOT NULL,
	TrainId INT NOT NULL FOREIGN KEY REFERENCES Trains(Id),
	PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
)

-- 2. Insert

INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
	VALUES
		('07:00', '19:00', 1, 3),
		('08:30', '20:30', 5, 6),
		('09:00', '21:00', 4, 8),
		('06:45', '03:55', 27, 7),
		('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations(TrainId, RailwayStationId)
	VALUES
		(36, 1), (36, 4), (36, 31), (36, 57), (36, 7), (37, 13), (37, 54),
		(37, 60), (37, 16), (38, 10), (38, 50), (38, 52), (38, 22), (39, 68),
		(39, 3), (39, 31), (39, 19), (40, 41), (40, 7), (40, 52), (40, 13)

INSERT INTO Tickets(Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
	VALUES
		(90.00, '2023-12-01', '2023-12-01', 36, 1),
		(115.00, '2023-08-02', '2023-08-02', 37, 2),
		(160.00, '2023-08-03', '2023-08-03', 38, 3),
		(255.00, '2023-09-01', '2023-09-02', 39, 21),
		(95.00, '2023-09-02', '2023-09-03', 40, 22)

-- 3. Update

UPDATE Tickets 
SET 
	DateOfDeparture = DATEADD(WEEK, 1, DateOfDeparture), 
	DateOfArrival = DATEADD(WEEK, 1, DateOfArrival)
WHERE 
	DATEPART(month, DateOfDeparture) > 10

-- 4. Delete

CREATE TABLE #TempDataForDelete (Id INT)

INSERT INTO #TempDataForDelete
SELECT Id 
FROM Trains 
WHERE DepartureTownId = 3

DELETE FROM Tickets 
WHERE TrainId IN(
	SELECT Id 
	FROM #TempDataForDelete
	)

DELETE FROM MaintenanceRecords 
WHERE TrainId IN(
	SELECT Id 
	FROM #TempDataForDelete
	)

DELETE FROM TrainsRailwayStations 
WHERE TrainId IN(
	SELECT Id 
	FROM #TempDataForDelete
	)

DELETE FROM Trains 
WHERE Id IN(
	SELECT Id 
	FROM #TempDataForDelete
	)

DROP TABLE #TempDataForDelete

-- 5. Tickets by Price and Date Departure

SELECT 
	DateOfDeparture, 
	Price AS TicketPrice
FROM 
	Tickets
ORDER BY
	TicketPrice ASC,
	DateOfDeparture DESC

-- 6. Passengers with their Tickets

SELECT
	p.[Name] AS PassengerName,
	t.Price AS TickerPrice,
	t.DateOfDeparture,
	t.TrainId AS TrainID
FROM 
	Tickets AS t
JOIN 
	Passengers AS p ON p.Id = t.PassengerId
ORDER BY
	TickerPrice DESC,
	PassengerName ASC

-- 7. Railway stations without passing trains

SELECT 
	t.[Name] AS Town,
	rs.[Name] AS RailwayStation
FROM
    RailwayStations AS rs
LEFT JOIN 
	TrainsRailwayStations AS trs ON trs.RailwayStationId = rs.Id
INNER JOIN 
	Towns AS t ON t.Id = rs.TownId
WHERE 
    trs.TrainId IS NULL
ORDER BY 
    t.[Name] ASC,
	rs.[Name] ASC

-- 8. First 3 trains between 8:00 and 8:59

SELECT TOP 3
	t.Id AS TrainId,
	t.HourOfDeparture,
	tp.Price AS TicketPrice,
	d.[Name] AS Destination
FROM 
	Trains AS t
JOIN
	Tickets AS tp ON tp.TrainId = t.Id
JOIN
	Towns AS d ON d.Id = t.ArrivalTownId
WHERE
	t.HourOfDeparture LIKE '08:%' AND tp.Price > 50.00
ORDER BY
	TicketPrice ASC

-- 9. Count of passengers paid more than average with arrival towns

SELECT 
    t.[Name] AS TownName,
    COUNT(DISTINCT p.Id) AS PassengerCount
FROM 
    Tickets AS ti
INNER JOIN 
    Passengers AS p ON p.Id = ti.PassengerId
INNER JOIN 
    Trains AS tr ON tr.Id = ti.TrainId
INNER JOIN 
    Towns AS t ON t.Id = tr.ArrivalTownId
WHERE 
    ti.Price > 76.99
GROUP BY 
    t.[Name]
ORDER BY 
    t.[Name] ASC

-- 10. Maintenance inspection with town

SELECT 
	t.Id AS TrainId,
	dt.[Name] AS DepartureTown,
	mr.Details AS Details
FROM 
	Trains AS t
INNER JOIN
	MaintenanceRecords AS mr ON mr.TrainId = t.Id
INNER JOIN
	Towns AS dt ON dt.Id = t.DepartureTownId
WHERE 
	mr.Details LIKE '%inspection%'
ORDER BY
	TrainId ASC

-- 11. Towns with trains

CREATE FUNCTION udf_TownsWithTrains(@townName VARCHAR(30))
RETURNS INT AS
BEGIN
	DECLARE 
		@count INT
	SELECT
		@count = COUNT(DISTINCT t.Id)
	FROM 
		Trains AS t
	INNER JOIN Towns AS [to] ON [to].Id = t.ArrivalTownId 
		OR [to].Id = t.DepartureTownId 
	WHERE
		[to].[Name] = @townName
	RETURN @count
END

	-- Test:
		SELECT dbo.udf_TownsWithTrains('Paris')

-- 12. Search passenger travelling to specific town

CREATE PROCEDURE usp_SearchByTown @townName VARCHAR(30)
AS
BEGIN
    SELECT 
        p.[Name] AS PassengerName,
        ti.DateOfDeparture,
        tr.HourOfDeparture
    FROM 
        Tickets AS ti
    INNER JOIN 
        Passengers AS p ON p.Id = ti.PassengerId
    INNER JOIN 
        Trains AS tr ON tr.Id = ti.TrainId
    INNER JOIN 
        Towns AS t ON t.Id = tr.ArrivalTownId
    WHERE 
        t.[Name] = @townName
    ORDER BY 
        ti.DateOfDeparture DESC,
        p.[Name] ASC
END

	-- Test:
		EXEC usp_SearchByTown 'Berlin'