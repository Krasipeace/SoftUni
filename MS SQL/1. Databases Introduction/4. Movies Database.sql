CREATE DATABASE Movies;

CREATE TABLE Directors
(
	Id INT PRIMARY KEY iDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(150) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2,
	[Length] INT,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors 
VALUES
	('Arthur Penn' , NULL),
	('Ridley Scott' , NULL),
	('Martin Scorsese' , NULL),
	('Clint Eastwood' , NULL),
	('David Fincher' , NULL);

INSERT INTO Genres
VALUES
	('Thriller' , NULL),
	('Sci-Fi' , NULL),
	('Action' , NULL),
	('Western' , NULL),
	('Drama' , NULL);

INSERT INTO Categories
VALUES
	('cat1', NULL),
    ('cat2', NULL),
    ('cat3', NULL),
    ('cat4', NULL),
    ('cat5', NULL);

INSERT INTO Movies
VALUES
	('The Left-Handed Gun', 1, NULL, NULL, 1, 1, 8, 'notes'),
    ('Blade Runner',        2, NULL, NULL, 2, 2, 7, 'notes'),
    ('Taxi Driver',         3, NULL, NULL, 3, 3, 8, 'notes'),
    ('High Plains Drifter', 4, NULL, NULL, 4, 4, 9, 'notes'),
    ('The Social Network',  5, NULL, NULL, 5, 5, 6, 'notes');