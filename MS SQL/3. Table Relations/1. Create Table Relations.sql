-- 1 One-To-One Relationship
CREATE TABLE Persons
(
    PersonID INT IDENTITY NOT NULL,
    FirstName NVARCHAR NOT NULL,
    Salary MONEY,
    PassportID INT NOT NULL,
	PRIMARY KEY (PersonID)
);
CREATE TABLE Passports
(
    PassportID INT IDENTITY NOT NULL,
    PassportNumber NVARCHAR NOT NULL,
    PRIMARY KEY (PassportID)
);

ALTER TABLE Persons 
ADD FOREIGN KEY (PassportID) 
REFERENCES Passports(PassportId)


-- 2 One-To-Many Relationship
CREATE TABLE Models
(
    ModelID INT IDENTITY NOT NULL,
    [Name] NVARCHAR NOT NULL,
    ManufacturerID INT,
	PRIMARY KEY (ModelID)
);

CREATE TABLE Manufacturers
(
    ManufacturerID INT IDENTITY NOT NULL,
    [Name] NVARCHAR NOT NULL,
	EstablishedOn DATETIME2 NOT NULL,
    PRIMARY KEY (ManufacturerID)
);

ALTER TABLE Models 
ADD FOREIGN KEY (ManufacturerID) 
REFERENCES Manufacturers(ManufacturerID)


-- 3 Many-To-Many Relationship 
CREATE TABLE Students
(
	StudentID INT IDENTITY NOT NULL,
	[Name] NVARCHAR NOT NULL,
	PRIMARY KEY (StudentID)
);

CREATE TABLE Exams
(
	ExamID INT IDENTITY NOT NULL,
	[Name] NVARCHAR NOT NULL,
	PRIMARY KEY (ExamID)
);

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
);

ALTER TABLE StudentsExams 
ADD FOREIGN KEY (StudentID)
REFERENCES Students

ALTER TABLE StudentsExams 
ADD FOREIGN KEY (ExamID)
REFERENCES Exams

ALTER TABLE StudentsExams 
ADD PRIMARY KEY (StudentID, ExamID)


-- 4 Self-Referencing 
CREATE TABLE Teachers
(
	TeacherID INT NOT NULL,
	[Name] NVARCHAR NOT NULL,
	ManagerID INT,
	PRIMARY KEY (TeacherID),
	FOREIGN KEY (ManagerID) 
	REFERENCES Teachers(TeacherID)
);