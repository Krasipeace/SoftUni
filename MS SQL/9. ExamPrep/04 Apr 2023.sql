CREATE DATABASE Accounting

USE Accounting

-- 1. DDL

-- Countries

CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	StreetName NVARCHAR(20) NOT NULL,
	StreetNumber INT,
	PostCode INT NOT NULL,
	City VARCHAR(25) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(25) NOT NULL,
	NumberVAT NVARCHAR(15) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(10)
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(35) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	VendorId INT FOREIGN KEY REFERENCES Vendors(Id)
)

CREATE TABLE Invoices
(
	Id INT PRIMARY KEY IDENTITY,
	Number INT UNIQUE NOT NULL,
	IssueDate DATETIME2 NOT NULL,
	DueDate DATETIME2 NOT NULL,
	Amount DECIMAL(18, 2) NOT NULL,
	Currency VARCHAR(5) NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(Id)
)

CREATE TABLE ProductsClients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	ClientId INT FOREIGN KEY REFERENCES Clients(Id),
	PRIMARY KEY(ProductId, ClientId)
)

-- 2. Insert

INSERT INTO Products ([Name], Price, CategoryId, VendorId)
	VALUES
		('SCANIA Oil Filter XD01', 78.69, 1, 1),
		('MAN Air Filter XD01', 97.38, 1, 5),
		('DAF Light Bulb 05FG87', 55.00, 2, 13),
		('ADR Shoes 47-47.5', 49.85, 3, 5),
		('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
	VALUES
		(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN', 3),
		(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR', 13),
		(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD', 19)

-- 3. Update

UPDATE Invoices
SET DueDate = '2023-04-01'
WHERE IssueDate BETWEEN '2022-11-01' AND '2022-11-30' 

UPDATE Clients
SET AddressId = 3
WHERE [Name] LIKE '%CO%'

-- 4. Delete

DELETE FROM ProductsClients 
WHERE ClientId = 11

DELETE FROM Invoices 
WHERE ClientId = 11

DELETE FROM Clients 
WHERE NumberVAT LIKE 'IT%'

-- 5. Invoices by Amount and Date

SELECT 
	Number, 
	Currency
FROM 
	Invoices
ORDER BY 
	Amount DESC, 
	DueDate ASC

-- 6. Products by Category

SELECT 
	p.Id,
	p.[Name],
	p.Price,
	c.[Name] AS CategoryName
FROM 
	Products AS p
JOIN 
	Categories AS c ON c.Id = p.CategoryId
WHERE
	c.[Name] = 'ADR' OR c.[Name] = 'Others'
ORDER BY
	p.Price DESC

-- 7. Clients without Products

SELECT
	c.Id,
	c.[Name] AS Client,
	CONCAT
	(
		a.StreetName, ' ', 
		a.StreetNumber, ', ', 
		a.City, ', ',
		a.PostCode, ', ', 
		cs.[Name]
	) AS [Address]
FROM
	Clients AS c
JOIN
	Addresses AS a ON a.Id = c.AddressId
JOIN 
	Countries AS cs ON cs.Id = a.CountryId
LEFT JOIN 
	ProductsClients AS pc ON pc.ClientId = c.Id
WHERE
	pc.ProductId IS NULL
ORDER BY
	c.[Name] ASC

-- 8. First 7 Invoices

SELECT TOP(7)
	i.Number,
	i.Amount,
	c.[Name] AS Client
FROM
	Invoices AS i
JOIN
	Clients AS c ON c.Id = i.ClientId
WHERE
	IssueDate < '2023-01-01' AND 
		(i.Currency = 'EUR' OR 
			(i.Amount > 500.00 AND c.NumberVAT LIKE 'DE%'))
ORDER BY
	i.Number ASC,
	i.Amount DESC

-- 9 Clients with VAT

SELECT
	c.[Name] AS Client,
	MAX(p.Price) AS [Price],
	c.NumberVAT AS [VAT Number]
FROM
	Clients AS c
JOIN
	ProductsClients AS pc ON pc.ClientId = c.Id
JOIN
	Products AS p ON p.Id = pc.ProductId
WHERE
	c.[Name] NOT LIKE '%KG'
GROUP BY
	c.[Name],
	c.NumberVAT
ORDER BY
	Price DESC

-- 10 Clients by Price

SELECT
	c.[Name] AS Client,
	FLOOR(AVG(p.Price)) AS [Average Price]
FROM
	Clients AS c
JOIN
	ProductsClients AS pc ON pc.ClientId = c.Id
JOIN
	Products AS p ON p.Id = pc.ProductId
JOIN
	Vendors AS v ON v.Id = p.VendorId
WHERE
	v.NumberVAT LIKE '%FR%'
GROUP BY
	c.[Name]
ORDER BY
	AVG(p.Price) ASC,
	c.[Name] DESC

-- 11 Products with Clients

CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(MAX))
RETURNS INT AS
BEGIN
	DECLARE @result INT =
	(
		SELECT
			COUNT(pc.ClientId)
		FROM 
			Products AS p
		INNER JOIN 
			ProductsClients AS pc ON pc.ProductId = p.Id
		WHERE 
			p.[Name] = @name
	)
	RETURN @result
END

-- Test:
-- SELECT dbo.udf_ProductWithClients('DAF FILTER HU12103X') -- 3

-- 12 Search for Vendors from a specific country

CREATE PROCEDURE usp_SearchByCountry(@country VARCHAR(MAX)) AS
SELECT
	v.[Name] AS Vendor,
	v.NumberVAT AS VAT,
	CONCAT(a.StreetName, ' ', a.StreetNumber) AS [Street Info],
	CONCAT(a.City, ' ', a.PostCode) AS [City Info]
FROM 
	Vendors AS v
JOIN
	Addresses AS a ON a.Id = v.AddressId
JOIN
	Countries AS c ON c.Id = a.CountryId
WHERE 
	c.[Name] = @country
ORDER BY
	v.[Name] ASC,
	a.City ASC

-- Test:
-- EXEC usp_SearchByCountry 'France' 