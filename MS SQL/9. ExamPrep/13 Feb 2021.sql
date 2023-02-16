-- 1 DDL (Data Definition Language)

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL

)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus VARCHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL

)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)


-- 2 Insert

INSERT INTO Files ([Name], Size, ParentId, CommitId)
VALUES
	('Trade.idk', 2598.0, 1, 1),
	('menu.net', 9238.31, 2, 2),
	('Administrate.soshy', 1246.93, 3, 3),
	('Controller.php', 7353.15, 4, 4),
	('Find.java', 9957.86, 5, 5),
	('Controller.json', 14034.87, 3, 6),
	('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId)
VALUES
	('Critical Problem with HomeController.cs file', 'open', 1, 4),
	('Typo fix in Judge.html', 'open', 4, 3),
	('Implement documentation for UsersService.cs', 'closed', 8, 2),
	('Unreachable code in Index.cs', 'open', 9, 8)


-- 3 Update

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6


-- 4 Delete

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (
						SELECT Id	
						FROM Repositories 
						WHERE [Name] = 'Softuni-Teamwork'
					 )

DELETE FROM Issues
WHERE RepositoryId = (
						SELECT Id 
						FROM Repositories
						WHERE [Name] = 'Softuni-Teamwork'
					 )


-- 5 Commits 

SELECT 
	Id,
	[Message],
	RepositoryId,
	ContributorId
FROM 
	Commits
ORDER BY
	Id ASC,
	[Message] ASC,
	RepositoryId ASC,
	ContributorId ASC


-- 6 Front-End

SELECT 
	Id, 
	[Name], 
	Size
FROM 
	Files
WHERE 
	Size > 1000 
	AND [Name] LIKE '%html%'
ORDER BY 
	Size DESC, 
	Id ASC, 
	[Name] ASC


-- 7 Issue Assignment

SELECT 
	i.Id,
	CONCAT(u.Username, ' : ', i.[Title]) AS IssueAssignee
FROM 
	Issues AS i
JOIN
	Users AS u ON u.Id = i.AssigneeId
ORDER BY
	i.Id DESC,
	CONCAT(u.Username, ' : ', i.[Title]) ASC


-- 8 Single Files

SELECT 
	Id,
	[Name],
	CONCAT(Size, 'KB') AS Size
FROM 
	Files
WHERE Id NOT IN 
	(
		SELECT ParentId
		FROM Files
		WHERE ParentId IS NOT NULL
	)	
ORDER BY
	Id ASC,
	[Name] ASC,
	CONCAT(Size, 'KB') DESC


-- 9 Commits in Repositories

SELECT TOP (5)
	r.Id, 
	r.[Name], 
	COUNT(c.Id) AS Commits
FROM 
	Repositories AS r
LEFT JOIN 
	Commits AS c ON c.RepositoryId = r.Id
LEFT JOIN
	RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY
	r.Id, 
	r.[Name]
ORDER BY
	COUNT(c.Id) DESC,
	r.Id ASC,
	r.[Name] ASC


-- 10 Average Size

SELECT
	u.UserName, 
	AVG(f.Size) AS Size
FROM 
	Users AS u
JOIN
	Commits AS c ON c.ContributorId = u.Id
JOIN
	Files AS f ON f.CommitId = c.Id
GROUP BY
	u.Username
ORDER BY
	AVG(f.Size) DESC,
	u.Username


-- 11 All User Commits

CREATE FUNCTION udf_AllUserCommits
	(@username VARCHAR(30))
RETURNS INT AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(c.Id) FROM Users AS u
                                LEFT JOIN Commits AS c 
									ON c.ContributorId = u.Id
								WHERE u.Username = @username) 

	RETURN @count
END

--Test:
SELECT dbo.udf_AllUserCommits('UnderSinduxrein') --> 6

-- 12 Search for Files

CREATE PROCEDURE usp_SearchForFiles
	(@fileExtension VARCHAR(MAX)) AS
BEGIN
	SELECT 
		Id, 
		[Name], 
		CONCAT(Size, 'KB') AS [Size]
	FROM 
		Files
	WHERE 
		[Name] LIKE '%' + @fileExtension
	ORDER BY 
		Id ASC, 
		[Name] ASC, 
		CONCAT(Size, 'KB') DESC
END


--Test:
EXEC usp_SearchForFiles 'txt'