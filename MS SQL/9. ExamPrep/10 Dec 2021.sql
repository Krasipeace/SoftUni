-- 1 DDL (Data Definition Language)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE NOT NULL,
	Age TINYINT CHECK(Age >= 21 AND Age <= 62) NOT NULL,
	Rating FLOAT CHECK (Rating >= 0.0 AND Rating <= 10.0)
)

CREATE TABLE AircraftTypes
(
	Id INT PRIMARY KEY IDENTITY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT PRIMARY KEY IDENTITY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR (30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR NOT NULL,
	TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)

CREATE TABLE PilotsAircraft
(
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PilotId INT FOREIGN KEY REFERENCES Pilots (Id) NOT NULL,
	PRIMARY KEY(AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT PRIMARY KEY IDENTITY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations
(
	Id INT PRIMARY KEY IDENTITY,
	AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers NOT NULL,
	TicketPrice DECIMAL(18, 2) DEFAULT 15 NOT NULL
)

-- 2 Insert

INSERT INTO Passengers 
SELECT 
	CONCAT(FirstName, ' ', LastName) AS FullName,
	CONCAT(FirstName, LastName, '@gmail.com') AS Email
FROM Pilots 
WHERE Id >= 5 AND Id <= 15


-- 3 Update

UPDATE Aircraft
SET Condition = 'A'
WHERE 
	(Condition = 'B' OR Condition = 'C')
	AND (FlightHours IS NULL OR FlightHours <= 100)
	AND [Year] >= 2013


-- 4 Delete 

--> SELECT * FROM Passengers WHERE LEN(FullName) <= 10

--DELETE FROM Passengers
--WHERE LEN(FullName) <= 10


-- 5 Aircraft

SELECT Manufacturer, Model, FlightHours, Condition
FROM Aircraft
ORDER BY FlightHours DESC


-- 6 Pilots and Aircraft

--> SELECT * FROM Aircraft where FlightHours <= 304

SELECT 
	p.FirstName, 
	p.LastName, 
	a.Manufacturer, 
	a.Model, 
	a.FlightHours
FROM 
	Pilots AS p
JOIN 
	PilotsAircraft AS pa ON pa.PilotId = p.Id
JOIN 
	Aircraft AS a ON a.Id = pa.AircraftId
WHERE 
	FlightHours <= 304
ORDER BY
	FlightHours DESC,
	FirstName ASC


-- 7 Top 20 Flight Destinations

SELECT TOP (20) 
	fd.Id AS DestinationId,
	fd.[Start],
	p.FullName,
	a.AirportName,
	fd.TicketPrice
FROM 
	Airports AS a
JOIN 
	FlightDestinations AS fd ON a.Id = fd.AirportId
JOIN 
	Passengers AS p ON p.Id = fd.PassengerId
WHERE
	DAY(fd.[Start]) % 2 = 0
ORDER BY
	TicketPrice DESC,
	AirportName ASC


-- 8 Number of Flights for Each Aircraft 

SELECT 
	a.Id AS AircraftId,
	a.Manufacturer,
	a.FlightHours,
	COUNT(fd.AirportId) AS FlightDestinationsCount,
	ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
JOIN FlightDestinations AS fd 
	ON a.Id = fd.AircraftId
GROUP BY
	a.Id, a.Manufacturer, a.FlightHours
HAVING 
	COUNT(fd.AirportId) >= 2
ORDER BY 
	COUNT(fd.AirportId) DESC,
	a.Id ASC

	
-- 9 Regular Passengers

SELECT 
	p.FullName, 
	COUNT(a.Id) AS CountOfAircraft,
	ROUND(SUM(fd.TicketPrice), 2) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd 
	ON fd.PassengerId = p.Id
JOIN Aircraft AS a 
	ON a.Id = fd.AircraftId
WHERE 
	SUBSTRING(p.FullName, 2, 1) = 'a'
GROUP BY
	p.Id, p.FullName
HAVING 
	COUNT(a.Id) > 1
ORDER BY
	p.FullName ASC


-- 10 Full info for flight destinations

SELECT 
	a.AirportName,
	fd.[Start] AS DayTIme,
	fd.TicketPrice,
	p.FullName,
	ai.Manufacturer,
	ai.Model
FROM Airports AS a
JOIN FlightDestinations AS fd 
	ON a.Id = fd.AirportId
JOIN Passengers AS p
	ON p.Id = fd.PassengerId
JOIN Aircraft as ai
	ON ai.Id = fd.AircraftId
WHERE
	CAST(fd.[Start] AS TIME) 
		BETWEEN '06:00' AND '20:00'
	AND fd.TicketPrice > 2500
ORDER BY 
	ai.Model ASC


-- 11 Find all destinations by email address

CREATE FUNCTION udf_FlightDestinationsByEmail
	(@email VARCHAR(MAX))
RETURNS INT AS
BEGIN
	DECLARE @destinationCount INT;
	SET @destinationCount = 
	(
		SELECT COUNT(fd.Id)
		FROM Passengers AS p
		JOIN FlightDestinations AS fd 
			ON fd.PassengerId = p.Id
		WHERE p.Email = @email
		GROUP BY p.Id
	)
	IF @destinationCount IS NULL
		SET @destinationCount = 0
	RETURN @destinationCount
END


--> Tests: 
SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com') --> 1
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com') --> 3
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com') --> 0


-- 12 Full info for airports

CREATE PROC usp_SearchByAirportName
	(@airportName VARCHAR(70)) AS
BEGIN
	SELECT
		a.AirportName,
		p.FullName,
		CASE 
			WHEN fd.TicketPrice <= 400 
				THEN 'Low' 
			WHEN fd.TicketPrice <= 1500 
				THEN 'Medium' 
			ELSE 'High' 
		END AS LevelOfTicketPrice,
		ai.Manufacturer,
		ai.Condition,
		[at].TypeName
	FROM Airports AS a
	JOIN FlightDestinations AS fd 
		ON fd.AirportId = a.Id
	JOIN Passengers AS p 
		ON p.Id = fd.PassengerId
	JOIN Aircraft AS ai 
		ON ai.Id = fd.AircraftId
	JOIN AircraftTypes AS [at]
		ON [at].Id = ai.TypeId
	WHERE 
		a.AirportName = @airportName
	ORDER BY
		ai.Manufacturer ASC,
		p.FullName ASC
END

--> Test:
EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'