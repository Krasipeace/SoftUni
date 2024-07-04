CREATE DATABASE LibraryDB
GO

USE LibraryDb

-- 1 DDL

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Contacts
(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200),
	Website NVARCHAR(50)
)

CREATE TABLE Authors
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Libraries
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Books
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL,
	AuthorId INT FOREIGN KEY REFERENCES Authors(Id) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
)

CREATE TABLE LibrariesBooks
(
	LibraryId INT FOREIGN KEY REFERENCES Libraries(Id) NOT NULL,
	BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
	PRIMARY KEY(LibraryId, BookId)
)

-- 2 Insert

SET IDENTITY_INSERT Contacts ON

INSERT INTO Contacts (Id, [Email], [PhoneNumber], [PostAddress], [Website]) 
	VALUES
		(21, NULL, NULL, NULL, NULL),
		(22, NULL, NULL, NULL, NULL),
		(23, 'stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
		(24, 'suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

SET IDENTITY_INSERT Contacts OFF
SET IDENTITY_INSERT Authors ON

INSERT INTO Authors (Id, [Name], [ContactId]) 
	VALUES
		(16, 'George Orwell', 21),
		(17, 'Aldous Huxley', 22),
		(18, 'Stephen King', 23),
		(19, 'Suzanne Collins', 24)

SET IDENTITY_INSERT Authors OFF
SET IDENTITY_INSERT Books ON

INSERT INTO Books (Id, [Title], [YearPublished], [ISBN], [AuthorId], [GenreId]) 
	VALUES
		(36, '1984', 1949, '9780451524935', 16, 2),
		(37, 'Animal Farm', 1945, '9780451526342', 16, 2),
		(38, 'Brave New World', 1932, '9780060850524', 17, 2),
		(39, 'The Doors of Perception', 1954, '9780060850531', 17, 2),
		(40, 'The Shining', 1977, '9780307743657', 18, 9),
		(41, 'It', 1986, '9781501142970', 18, 9),
		(42, 'The Hunger Games', 2008, '9780439023481', 19, 7),
		(43, 'Catching Fire', 2009, '9780439023498', 19, 7),
		(44, 'Mockingjay', 2010, '9780439023511', 19, 7)

SET IDENTITY_INSERT Books OFF

INSERT INTO LibrariesBooks (LibraryId, BookId) 
	VALUES
		(1, 36),
		(1, 37),
		(2, 38),
		(2, 39),
		(3, 40),
		(3, 41),
		(4, 42),
		(4, 43),
		(5, 44)

-- 3 Update

UPDATE 
	Contacts
SET 
	Website = LOWER('www.' + REPLACE(a.Name, ' ', '') + '.com')
FROM 
	Contacts AS c
JOIN 
	Authors AS a ON c.Id = a.ContactId
WHERE 
	c.Website IS NULL

-- 4 Delete

DELETE 
	lb
FROM 
	LibrariesBooks AS lb
JOIN 
	Books AS b ON lb.BookId = b.Id
WHERE 
	b.AuthorId = 1

DELETE FROM 
	Books
WHERE 
	AuthorId = 1

DELETE FROM 
	Authors
WHERE 
	Id = 1

-- 5 Chronological order

SELECT 
	Title, 
	ISBN,
	YearPublished
FROM 
	Books
ORDER BY
	YearPublished DESC,
	Title ASC

-- 6 Books by genre

SELECT 
	b.Id,
	b.Title,
	b.ISBN,
	g.[Name] AS [Genre]
FROM 
	Books AS b
JOIN
	Genres AS g ON g.Id = b.GenreId
WHERE
	g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY
	[Genre] ASC,
	b.Title ASC
	
-- 7 Missing Genre

SELECT 
    l.[Name],
    c.Email
FROM 
	Libraries AS l
JOIN 
	Contacts AS c ON c.Id = l.ContactId
WHERE 
	l.Id NOT IN (
		SELECT 
			lb.LibraryId
		FROM 
			LibrariesBooks AS lb
		JOIN 
			Books AS b ON b.Id = lb.BookId
		WHERE 
			b.GenreId = (
				SELECT 
					Id 
				FROM 
					Genres 
				WHERE 
					[Name] = 'Mystery'
			)
	)
ORDER BY 
	l.[Name]

-- 8 First 3 Books

SELECT TOP (3)
    b.Title,
    b.YearPublished AS [Year],
    g.[Name] AS Genre
FROM
    Books AS b
JOIN
    Genres AS g 
		ON g.Id = b.GenreId
WHERE
    (b.YearPublished > 2000 AND b.Title LIKE '%a%')
    OR
    (b.YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%')
ORDER BY
    b.Title ASC,
    [Year] DESC

-- 9 Authors from UK

SELECT 
    a.[Name],
    c.Email,
    c.PostAddress
FROM 
	Authors AS a
JOIN 
	Contacts AS c 
		ON c.Id = a.ContactId
WHERE 
	c.PostAddress LIKE '%UK%'
ORDER BY 
	a.[Name]

-- 10 Fictions in Denver

SELECT 
	a.[Name] AS 'Author', 
	b.Title, 
	l.[Name] AS 'Library', 
	c.PostAddress AS 'Library Address'
FROM 
	Books AS b
JOIN 
	Authors AS a 
		ON a.Id = b.AuthorId
JOIN 
	LibrariesBooks AS lb 
		ON lb.BookId = b.Id
JOIN 
	Libraries l 
		ON l.Id = lb.LibraryId
JOIN 
	Contacts AS c 
		ON c.Id = l.ContactId
WHERE 
	b.GenreId = (
		SELECT 
			Id 
		FROM 
			Genres 
		WHERE 
			[Name] = 'Fiction')
				AND 
					c.PostAddress 
				LIKE 
					'%Denver%'
GROUP BY 
	a.[Name], 
	b.Title, 
	l.[Name], 
	c.PostAddress
ORDER BY 
	b.Title

-- 11 Authors with books

CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT AS
BEGIN
	DECLARE @countBooks INT

	SELECT 
		@countBooks = COUNT(lb.BookId)
	FROM 
		Authors AS a
	JOIN 
		Books AS b 
			ON b.AuthorId = a.Id
	JOIN 
		LibrariesBooks AS lb 
			ON lb.BookId = b.Id
	WHERE 
		a.[Name] = @name;

	RETURN @countBooks;
END

-- Test
SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling') AS [Output] -- 3

-- 12 Search by genre

CREATE PROCEDURE usp_SearchByGenre
    @genreName NVARCHAR(30)
AS
BEGIN
    SELECT 
        b.Title,
        b.YearPublished AS [Year],
        b.ISBN,
        a.[Name] AS Author,
        g.[Name] AS Genre
    FROM 
        Books b
    JOIN 
        Authors AS a 
			ON a.Id = b.AuthorId
    JOIN 
        Genres AS g 
			ON g.Id = b.GenreId
    WHERE 
        g.[Name] = @genreName
    ORDER BY 
        b.Title ASC
END

-- Test
EXEC usp_SearchByGenre 'Fantasy' -- 6 records