-- 1. Create Database

CREATE DATABASE [MINIONS]

-- 2. Create Table

CREATE TABLE [Minions]
(
	[Id] INT PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	[Age] INT,
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

-- 3. Alter Minions Table

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns](Id)

-- 4. Insert records in both tables

INSERT INTO [Towns]
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna');

INSERT INTO [Minions]
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Stewart', NULL, 2);

-- 5. Truncate table Minions

TRUNCATE TABLE [Minions]

-- 6. Drop All tables

DROP DATABASE [Minions]