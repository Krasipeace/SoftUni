CREATE DATABASE CarRental;

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY, 
	CategoryName NVARCHAR(50), 
	DailyRate MONEY NOT NULL, 
	WeeklyRate MONEY NOT NULL, 
	MonthlyRate MONEY NOT NULL, 
	WeekendRate MONEY NOT NULL
)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber NVARCHAR(10) NOT NULL, 
	Manufacturer NVARCHAR(100) NOT NULL, 
	Model NVARCHAR(20) NOT NULL, 
	CarYear INT NOT NULL, 
	CategoryId INT NOT NULL FOREIGN KEY (CategoryId) REFERENCES Categories(Id), 
	Doors INT, 
	Picture VARBINARY(MAX), 
	Condition NVARCHAR(20), 
	Available NVARCHAR(5) NOT NULL
)

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
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber NVARCHAR(10) NOT NULL, 
	FullName NVARCHAR(60) NOT NULL, 
	Address NVARCHAR(100), 
	City NVARCHAR(30) NOT NULL, 
	ZIPCode NVARCHAR(7), 
	Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT NOT NULL FOREIGN KEY (EmployeeId) REFERENCES Employees(Id), 
	CustomerId INT NOT NULL FOREIGN KEY (CustomerId) REFERENCES Customers(Id), 
	CarId INT NOT NULL FOREIGN KEY (CarId) REFERENCES Cars(Id), 
	TankLevel REAL, 
	KilometrageStart NVARCHAR(7) NOT NULL, 
	KilometrageEnd NVARCHAR(7) NOT NULL, 
	TotalKilometrage NVARCHAR(7) NOT NULL, 
	StartDate DATETIME2, 
	EndDate DATETIME2, 
	TotalDays INT, 
	RateApplied MONEY, 
	TaxRate MONEY, 
	OrderStatus NVARCHAR(5), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories
VALUES
	('Economic', 9.99, 49.99, 139.99, 13.37),
    ('Business', 19.99, 99.99, 399.99, 56.66),
    ('Luxury', 49.99, 399.99, 999.99, 73.31);

INSERT INTO Cars
VALUES
	('4356', 'Opel', 'Astra', '2013', 1, 4, NULL, NULL, 1),
    ('1337', 'BMW', 'i7', '2022', 2, 2, NULL, NULL, 0),
    ('7777', 'Porche', '911', '2022', 3, 2, NULL, NULL, 1);

INSERT INTO Employees
VALUES 
	('Dimitrichko', 'Dimitrichkov', 'Cat1', NULL),
    ('Stamat', 'Stamatov', 'Cat2', NULL),
    ('Jorj', 'Gangchev', 'Cat3', NULL);

INSERT INTO Customers
VALUES
    ('1234567891', 'gdpr1', 'GDPR PRIVACY', 'Sofia', '1000', NULL),
    ('1234567892', 'gdpr2', 'GDPR PRIVACY', 'Plovdiv', '4000', NULL),
    ('1234567893', 'gdpr3', 'GDPR PRIVACY', 'Stara Zagora', '6000', NULL);

INSERT INTO RentalOrders
VALUES
    (1, 1, 1, 0.25, 100000, 200000, 100000, NULL, NULL, NULL, NULL, NULL, 0, NULL),
    (2, 2, 2, 0.50, 50000, 100000, 50000, NULL, NULL, NULL, NULL, NULL, 0, NULL),
    (3, 3, 3, 0.99, 1000, 2000, 1000, NULL, NULL, NULL, NULL, NULL, 0, NULL);