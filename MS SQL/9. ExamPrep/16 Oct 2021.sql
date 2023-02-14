-- 1 DDL (Data Definition Language)

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT NOT NULL CHECK ([Length] >= 10 AND [Length] <= 25),
	RingRange DECIMAL(18,2) NOT NULL CHECK (RingRange >= 1.5 AND RingRange <= 7.5)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar MONEY NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20)
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id),
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id),
	PRIMARY KEY(ClientId, CigarId)
)


-- 2 Insert 

INSERT INTO Cigars
(CigarName,	BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL)
VALUES
('COHIBA ROBUSTO',	9,	1,	5,	15.50,	'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',	9,	1,	10,	410.00,	'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',	14,	5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',	14,	4, 15,	32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',	2,	3,	8,	85.21,	'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP)
VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')


-- 3 Update 
UPDATE Cigars
SET PriceForSingleCigar = PriceForSingleCigar * 1.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL


-- 4 Delete
DELETE FROM Clients
WHERE AddressId IN 
(
	SELECT Id FROM Addresses
	WHERE SUBSTRING(Country, 1, 1) = 'C'
)

DELETE FROM Addresses
WHERE SUBSTRING(Country, 1, 1) = 'C'


-- 5 Cigars by Price

SELECT CigarName, PriceForSingleCigar, ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC


-- 6 Cigars by  Taste

SELECT 
	c.Id, 
	c.CigarName, 
	c.PriceForSingleCigar, 
	t.TasteType, 
	t.TasteStrength
FROM Cigars AS c
JOIN 
	Tastes AS t ON t.Id = c.TastId
WHERE 
	T.TasteType IN ('Earthy', 'Woody')
ORDER BY c.PriceForSingleCigar DESC


-- 7 Clients without Cigars

SELECT 
	Id, 
	CONCAT(FirstName, ' ', LastName) AS ClientName, 
	Email
FROM 
	Clients 
WHERE
	(
		SELECT TOP (1) (1)
		FROM ClientsCigars
		WHERE ClientId = Id
	) IS NULL
ORDER BY ClientName ASC


-- 8 First 5 Cigars

SELECT TOP (5)
	c.CigarName,
	c.PriceForSingleCigar,
	c.ImageURL
FROM
	Cigars AS c
JOIN 
	Sizes AS s ON s.Id = c.SizeId
WHERE
	s.[Length] >= 12
	AND 
		(PriceForSingleCigar > 50 
			OR c.CigarName Like '%ci%')
	AND 
		s.RingRange > 2.55
ORDER BY
	c.CigarName ASC,
	c.PriceForSingleCigar DESC


-- 9 Clients with ZIP Codes

SELECT
	CONCAT(FirstName, ' ', LastName) AS FullName,
	a.Country,
	a.ZIP,
	CONCAT('$', MAX(ci.PriceForSingleCigar)) AS CigarPrice
FROM 
	Clients AS c
JOIN 
	Addresses AS a ON a.Id = c.AddressId
JOIN
	ClientsCigars AS cc ON c.Id = cc.ClientId
JOIN 
	Cigars AS ci ON ci.Id = cc.CigarId
WHERE 
	ISNUMERIC(a.ZIP) = 1
GROUP BY
	CONCAT(FirstName, ' ', LastName),
	a.Country,
	a.ZIP
ORDER BY 
	CONCAT(FirstName, ' ', LastName) ASC


-- 10 Cigars by Size

SELECT 
	c.LastName,
	CEILING(AVG(s.[Length])) AS CigarLength,
	CEILING(AVG(s.RingRange)) AS CigarRingRange
FROM
	Clients AS c
JOIN
	ClientsCigars AS cc ON cc.ClientId = c.Id
JOIN
	Cigars AS ci ON ci.Id = cc.CigarId
JOIN 
	Sizes AS s ON s.Id = ci.SizeId
GROUP BY
	c.LastName
ORDER BY 
	AVG(s.[Length]) DESC


-- 11 Client with Cigars

CREATE FUNCTION udf_ClientWithCigars
	(@name NVARCHAR(MAX)) 
RETURNS INT AS
BEGIN
	RETURN 
		(SELECT
		COUNT(*)
		FROM ClientsCigars
		WHERE ClientId IN 
			(SELECT Id
			FROM Clients
			WHERE FirstName = @name))
END


--> Test:
SELECT dbo.udf_ClientWithCigars('Betty') --> 5


-- 12 Search for Cigar with Specific taste

CREATE PROC usp_SearchByTaste
	(@taste VARCHAR(MAX)) AS
BEGIN
	SELECT 
		CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.[Length], ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM 
		Cigars as c
	JOIN 
		Sizes AS s ON s.Id = c.SizeId
	JOIN 
		Brands AS b ON b.Id = c.BrandId
	JOIN 
		Tastes AS t ON t.Id = c.TastId
	WHERE
		TasteType = @taste
	ORDER BY
		CigarLength ASC,
		CigarRingRange DESC
END

-- Test:
EXEC usp_SearchByTaste 'Woody'