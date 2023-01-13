CREATE DATABASE Hotel;

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(20) NOT NULL, 
	LastName NVARCHAR(20) NOT NULL, 
	Title NVARCHAR(10) NOT NULL, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Customers 
(
	AccountNumber INT PRIMARY KEY, 
	FirstName NVARCHAR(20) NOT NULL, 
	LastName NVARCHAR(20) NOT NULL,
	PhoneNumber NVARCHAR(15) NOT NULL, 
	EmergencyName NVARCHAR(20), 
	EmergencyNumber NVARCHAR(15), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus 
(
	RoomStatus VARCHAR(10) NOT NULL PRIMARY KEY, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RoomTypes 
(
	RoomType VARCHAR(10) NOT NULL PRIMARY KEY, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE BedTypes 
(
	BedType VARCHAR(10) NOT NULL PRIMARY KEY, 
	Notes NVARCHAR(MAX)
)

CREATE TABLE Rooms
(
    RoomNumber TINYINT NOT NULL PRIMARY KEY,
    RoomType VARCHAR(10) NOT NULL FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
    BedType VARCHAR(10) NOT NULL FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
    Rate DECIMAL(15,2) NOT NULL,
    RoomStatus VARCHAR(10) NOT NULL FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus),
    Notes VARCHAR(MAX)
)

CREATE TABLE Payments
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT NOT NULL FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    PaymentDate DATETIME2 DEFAULT GETDATE(),
    AccountNumber INT,
    FirstDateOccupied DATETIME2,
    LastDateOccupied DATETIME2,
    TotalDays TINYINT,
    AmountCharged MONEY,
    TaxRate MONEY,
    TaxAmount MONEY,
    PaymentTotal MONEY,
    Notes VARCHAR(MAX)
)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL FOREIGN KEY (Id) REFERENCES Employees(Id), 
	DateOccupied DATETIME2, 
	AccountNumber INT,
	RoomNumber TINYINT NOT NULL FOREIGN KEY (RoomNumber) REFERENCES Rooms(RoomNumber), 
	RateApplied MONEY, 
	PhoneCharge SMALLMONEY, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
VALUES
    ('f1', 'l1', 't1', null),
    ('f2', 'l2', 't2', null),
    ('f3', 'l3', 't3', null);

INSERT INTO Customers
VALUES
    ('43214', 'fn1', 'ln1', 08752512, NULL, NULL, NULL),
    ('43124', 'fn2', 'ln2', 08793524, NULL, NULL, NULL),
    ('14324', 'fn3', 'ln3', 08812354, NULL, NULL, NULL);

INSERT INTO RoomStatus
VALUES
    ('Free', NULL),
    ('Reserved', NULL),
	('Taken', NULL);

INSERT INTO RoomTypes
VALUES
    ('Single', NULL),
    ('Double', NULL),
	('Luxury', NULL);

INSERT INTO BedTypes
VALUES
    ('Normal', NULL),
    ('Chamber', NULL),
    ('Luxury', NULL);

INSERT INTO Rooms
VALUES
    (7, 'Single', 'Normal', 5, 'Free', NULL),
    (17, 'Double', 'Chamber', 10, 'Reserved', NULL),
    (22, 'Luxury', 'Luxury', 15, 'Taken', NULL);

INSERT INTO Payments
VALUES
    (1, NULL, 55555555, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
    (2, NULL, 33333333, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
    (3, NULL, 11111111, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber)
VALUES
    (1, NULL, 7),
    (2, NULL, 17),
    (3, NULL, 22);