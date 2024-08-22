CREATE DATABASE ShoesApplicationDatabase
GO

USE ShoesApplicationDatabase

-- 01 Create Tables (DDL)
CREATE TABLE Users 
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE Brands 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Sizes 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EU DECIMAL(5,2) NOT NULL,
    US DECIMAL(5,2) NOT NULL,
    UK DECIMAL(5,2) NOT NULL,
    CM DECIMAL(5,2) NOT NULL,
    [IN] DECIMAL(5,2) NOT NULL
)

CREATE TABLE Shoes 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Model NVARCHAR(30) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    BrandId INT NOT NULL FOREIGN KEY REFERENCES Brands(Id)
)

CREATE TABLE Orders 
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ShoeId INT NOT NULL FOREIGN KEY REFERENCES Shoes(Id),
    SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
    UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE ShoesSizes 
(
    ShoeId INT NOT NULL FOREIGN KEY REFERENCES Shoes(Id),
    SizeId INT NOT NULL FOREIGN KEY REFERENCES Sizes(Id),
    PRIMARY KEY (ShoeId, SizeId)
)

-- 02 Insert

INSERT INTO Brands ([Name])
VALUES ('Timberland'), ('Birkenstock');

INSERT INTO Shoes (Model, Price, BrandId)
VALUES
    ('Reaxion Pro', 150.00, 12),
    ('Laurel Cort Lace-Up', 160.00, 12),
    ('Perkins Row Sandal', 170.00, 12),
    ('Arizona', 80.00, 13),
    ('Ben Mid Dip', 85.00, 13),
    ('Gizeh', 90.00, 13)

INSERT INTO ShoesSizes (ShoeId, SizeId)
VALUES
    (70, 1), (73, 1),
    (70, 2), (73, 3),
    (70, 3), (73, 5),
    (71, 2), (74, 2),
    (71, 3), (74, 4),
    (71, 4), (74, 6),
    (72, 4), (75, 1),
    (72, 5), (75, 2),
    (72, 6), (75, 3)

INSERT INTO Orders (ShoeId, SizeId, UserId)
VALUES
    (70, 2, 15),
    (71, 3, 17),
    (72, 6, 18),
    (73, 5, 4),
    (74, 4, 7),
    (75, 1, 11)

-- 03 Update

UPDATE Shoes
SET Price = Price * 1.15
WHERE BrandId = (
		SELECT Id 
		FROM Brands 
		WHERE [Name] = 'Nike'
	)

-- 04 Delete

DELETE FROM 
	Orders 
WHERE 
	ShoeId = (
		SELECT Id 
		FROM Shoes 
		WHERE Model = 'Joyride Run Flyknit'
	)

DELETE FROM 
	ShoesSizes 
WHERE 
	ShoeId = (
		SELECT Id 
		FROM Shoes 
		WHERE Model = 'Joyride Run Flyknit'
	)

DELETE FROM 
	Shoes 
WHERE 
	Model = 'Joyride Run Flyknit'

-- 05 Orders by price of the shoe

SELECT 
    s.Model AS ShoeModel,
    s.Price
FROM 
    Orders AS o
INNER JOIN 
    Shoes AS s ON o.ShoeId = s.Id
ORDER BY 
    s.Price DESC, 
    s.Model ASC

-- 06 Shoes with their brand

SELECT 
    b.[Name] AS BrandName,
    s.Model AS ShoeModel
FROM 
    Shoes AS s
INNER JOIN 
    Brands AS b ON s.BrandId = b.Id
ORDER BY 
    b.[Name] ASC, 
    s.Model ASC

-- 07 Top 10 users by total money spent

SELECT 
    TOP 10 WITH TIES UserId,
    FullName,
    SUM(s.Price) AS TotalSpent
FROM 
    Orders AS o
INNER JOIN 
    Shoes AS s ON o.ShoeId = s.Id
INNER JOIN 
    Users AS u ON o.UserId = u.Id
GROUP BY 
    o.UserId, 
	u.FullName
ORDER BY 
    SUM(s.Price) DESC, 
    FullName ASC

-- 08 Average price of orders

SELECT 
    u.Username,
    u.Email,
    CAST(AVG(s.Price) AS DECIMAL(10,2)) AS AvgPrice
FROM 
    Orders AS o
INNER JOIN 
    Shoes AS s ON o.ShoeId = s.Id
INNER JOIN 
    Users AS u ON o.UserId = u.Id
GROUP BY 
    u.Username,
	u.Email
HAVING 
    COUNT(*) > 2
ORDER BY 
    AvgPrice DESC

-- 09 Running shoes

SELECT 
    s.Model, 
    COUNT(DISTINCT ss.SizeId) AS CountOfSizes, 
    b.[Name] AS BrandName
FROM 
    Shoes AS s
INNER JOIN 
    ShoesSizes AS ss ON s.Id = ss.ShoeId
INNER JOIN 
    Brands AS b ON s.BrandId = b.Id
WHERE 
    b.[Name] = 'Nike' AND s.Model LIKE '%Run%'
GROUP BY 
    s.Model, 
	b.[Name]
HAVING 
    COUNT(DISTINCT ss.SizeId) > 5
ORDER BY 
    s.Model DESC

-- 10 Phone including digits 345

SELECT 
    u.FullName,
    u.PhoneNumber,
    s.Price AS OrderPrice,
    s.Id AS ShoeId,
    b.Id AS BrandId,
    FORMAT(si.EU, '0.00') + 'EU/' + 
    FORMAT(si.US, '0.00') + 'US/' + 
    FORMAT(si.UK, '0.00') + 'UK' AS ShoeSize
FROM 
    Orders AS o
INNER JOIN 
    Users AS u ON o.UserId = u.Id
INNER JOIN 
    Shoes AS s ON o.ShoeId = s.Id
INNER JOIN 
    Brands AS b ON s.BrandId = b.Id
INNER JOIN 
    Sizes AS si ON o.SizeId = si.Id
WHERE 
    u.PhoneNumber LIKE '%345%'
ORDER BY 
    s.Model ASC

-- 11 Find all orders by email address

CREATE FUNCTION udf_OrdersByEmail(@email NVARCHAR(100))
RETURNS INT AS
BEGIN
    DECLARE @count INT

    SELECT 
        @count = COUNT(*)
    FROM 
        Orders AS o
    INNER JOIN 
        Users AS u ON o.UserId = u.Id
    WHERE 
        u.Email = @email;

    RETURN @count
END

	-- Tests
		SELECT dbo.udf_OrdersByEmail('sstewart@example.com')
		SELECT dbo.udf_OrdersByEmail('ohernandez@example.com')
		SELECT dbo.udf_OrdersByEmail('nonexistent@example.com')

-- 12 Shoe details by size

CREATE PROCEDURE usp_SearchByShoeSize
    @shoeSize DECIMAL(5,2)
AS
BEGIN
    SELECT 
        s.Model AS ModelName,
        u.FullName AS UserFullName,
        CASE 
            WHEN s.Price < 100 THEN 'Low'
            WHEN s.Price BETWEEN 100 AND 200 THEN 'Medium'
            ELSE 'High'
        END AS PriceLevel,
        b.[Name] AS BrandName,
        si.EU AS SizeEU
    FROM 
        Orders AS o
    INNER JOIN 
        Shoes AS s ON o.ShoeId = s.Id
    INNER JOIN 
        Users AS u ON o.UserId = u.Id
    INNER JOIN 
        Brands AS b ON s.BrandId = b.Id
    INNER JOIN 
        Sizes AS si ON o.SizeId = si.Id
    WHERE 
        si.EU = @shoeSize
    ORDER BY 
        b.[Name] ASC, 
        u.FullName ASC
END

	-- Tests:
		EXEC usp_SearchByShoeSize 40.00