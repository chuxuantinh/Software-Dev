CREATE DATABASE Minions

GO

USE Minions

GO

CREATE TABLE Minions (
	Id INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	Age INT NOT NULL
)

CREATE TABLE Towns (
	Id INT NOT NUll,
	[Name] NVARCHAR(50) NOT NULL
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId
PRIMARY KEY(Id)

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownId
FOREIGN KEY (TownId) REFERENCES Towns(Id)

GO

INSERT INTO Towns(Id, [Name]) VALUES 
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

ALTER TABLE Minions
DROP COLUMN Age
ALTER TABLE Minions
ADD Age INT

INSERT INTO Minions(Id, [Name], Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT [Id], [Name], [Age], [TownId] FROM Minions

ALTER TABLE Minions
DROP CONSTRAINT PK_Id

ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	CHECK(DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT NOT NULL
)

DROP TABLE Users

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Pesho', '123', NULL, NULL, 0),
('Gosho', '123', NULL, NULL, 0),
('Ivan', '123', NULL, NULL, 0),
('Test', '123', NULL, NULL, 1),
('Test123', '123', NULL, NULL, 1)

SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07AE10924E

ALTER TABLE Users
ADD CONSTRAINT PK_CompositeIdUsername
PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT PasswordLength
CHECK(LEN([Password]) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT UniqueUsername
UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT UsernameLength
CHECK(LEN(Username) >= 3)

INSERT INTO Users
(Username, [Password], ProfilePicture, IsDeleted)
VALUES
('Testttt2', '123', NULL, 1)

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50),
	LastName NVARCHAR(50) NOT NULL,
	Salary DECIMAL(8, 2) NOT NULL
)

INSERT INTO Employees
			(FirstName, MiddleName, LastName, Salary) 
VALUES
			('Pesho', NULL, 'Peshov', 2550.50),
			('Gosho', NULL, 'Goshov', 1650.35),
			('Ivan', NULL, 'Ivanov', 3150.45)

SELECT * FROM Employees
ORDER BY FirstName, LastName, Salary

SELECT * FROM Employees
ORDER BY Salary DESC

SELECT TOP(1) * FROM Employees
ORDER BY Salary DESC

SELECT TOP(1) * FROM Employees
WHERE Id = 2

SELECT TOP(1) * FROM (
	SELECT TOP(2) * FROM Employees
	ORDER BY Salary DESC) AS e
ORDER BY Salary

UPDATE Employees
SET Salary += 100

-- My solutions

USE Minions

TRUNCATE TABLE Minions

DROP TABLE Minions, Towns, Users

CREATE TABLE People (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	CHECK(DATALENGTH(Picture) <= 2097152),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	CHECK(Gender = 'm' OR Gender = 'f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People
			([Name], Picture, Height, [Weight], Gender, Birthdate, Biography)
VALUES
			('Pesho', NULL, 1.80, 88.59, 'm', '2000-01-01', NULL),
			('Gosho', NULL, 1.80, 88.59, 'm', '2000-01-01', NULL),
			('Ivan', NULL, 1.80, 88.59, 'm', '2000-01-01', NULL),
			('Ema', NULL, 1.80, 88.59, 'f', '2000-01-01', NULL),
			('Poly', NULL, 1.80, 88.59, 'f', '2000-01-01', NULL)

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors (
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Genres (
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

CREATE TABLE Movies (
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] TIME NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating DECIMAL(2, 1),
	Notes NVARCHAR(MAX)
)

ALTER TABLE Movies
ADD CONSTRAINT FK_MoviesDirectorId
FOREIGN KEY (DirectorId) REFERENCES Directors(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_MoviesGenreId
FOREIGN KEY (GenreId) REFERENCES Genres(Id)

ALTER TABLE Movies
ADD CONSTRAINT FK_MoviesCategoryId
FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

INSERT INTO Directors (DirectorName) VALUES
	('DN1'),
	('DN2'),
	('DN3'),
	('DN4'),
	('DN5')

INSERT INTO Genres (GenreName) VALUES
	('GN1'),
	('GN2'),
	('GN3'),
	('GN4'),
	('GN5')

INSERT INTO Categories (CategoryName) VALUES
	('CN1'),
	('CN2'),
	('CN3'),
	('CN4'),
	('CN5')

INSERT INTO Movies 
			(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId)
VALUES
			('T1', 1, 2000, '2:15:03', 1, 1),
			('T2', 2, 2000, '2:15:03', 2, 2),
			('T3', 3, 2000, '2:15:03', 3, 3),
			('T4', 4, 2000, '2:15:03', 4, 4),
			('T5', 5, 2000, '2:15:03', 5, 5)

CREATE DATABASE CarRental 

USE CarRental

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	DailyRate DECIMAL(4, 2) NOT NULL,
	WeeklyRate DECIMAL (4, 2) NOT NULL,
	MonthlyRate DECIMAL (4, 2) NOT NULL,
	WeekendRate DECIMAL (4, 2) NOT NULL
)

CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(30) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear INT NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture VARBINARY(MAX),
	Condition VARCHAR(50),
	Available VARCHAR(10) NOT NULL
)

ALTER TABLE Cars
ADD CONSTRAINT UniquePlateNumber
UNIQUE (PlateNumber)

ALTER TABLE Cars
ADD CONSTRAINT FK_CarCategoryId
FOREIGN KEY (CategoryId) REFERENCES Categories(Id)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(30) NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE Customers (
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(50) NOT NULL,
	FullName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL,
	City VARCHAR(50) NOT NULL,
	ZIPCode INT NOT NULL,
	Notes VARCHAR(MAX)
)

CREATE TABLE RentalOrders (
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel DECIMAL (3, 1) NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied VARCHAR(50) NOT NULL,
	TaxRate DECIMAL (4, 2) NOT NULL,
	OrderStatus VARCHAR(50),
	Notes VARCHAR(MAX)
)

ALTER TABLE RentalOrders
ADD CONSTRAINT FK_RentalOrdersEmployeeId
FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)

ALTER TABLE RentalOrders
ADD CONSTRAINT FK_RentalOrdersCustomerId
FOREIGN KEY (CustomerId) REFERENCES Customers(Id)

ALTER TABLE RentalOrders
ADD CONSTRAINT FK_RentalOrdersCarId
FOREIGN KEY (CarId) REFERENCES Cars(Id)

INSERT INTO Categories 
			(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES
			('CN1', 10.5, 10.5, 10.5, 10.5),
			('CN2', 10.5, 10.5, 10.5, 10.5),
			('CN3', 10.5, 10.5, 10.5, 10.5)

INSERT INTO Cars
			(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES
			('CA1234CA', 'Manufacturer', 'Model', 2000, 1, 4, NULL, 'Condition', 'Yes'),
			('CA2345CA', 'Manufacturer', 'Model', 2000, 2, 4, NULL, 'Condition', 'Yes'),
			('CA3456CA', 'Manufacturer', 'Model', 2000, 3, 4, NULL, 'Condition', 'Yes')

INSERT INTO Employees		
			(FirstName, LastName, Title)
VALUES
			('FN1', 'LN1', 'Title'),
			('FN2', 'LN2', 'Title'),
			('FN3', 'LN3', 'Title')


INSERT INTO Customers
			(DriverLicenceNumber, FullName, [Address], City, ZIPCode)
VALUES
			('DLN1', 'FN', 'Address', 'City', 1257),
			('DLN2', 'FN', 'Address', 'City', 1257),
			('DLN3', 'FN', 'Address', 'City', 1257)

INSERT INTO RentalOrders
			(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus)
VALUES
			(1, 1, 1, 10.3, 100, 103, 3, '2000-01-01', '2000-01-03', 3, 'RateApplied', 10.50, 'OrderStatus'),
			(1, 1, 1, 10.3, 100, 103, 3, '2000-01-01', '2000-01-03', 3, 'RateApplied', 10.50, 'OrderStatus'),
			(1, 1, 1, 10.3, 100, 103, 3, '2000-01-01', '2000-01-03', 3, 'RateApplied', 10.50, 'OrderStatus')

CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Title VARCHAR(50),
Notes VARCHAR(MAX)
)
 
INSERT INTO Employees
VALUES
('Velizar', 'Velikov', 'Receptionist', 'Nice customer'),
('Ivan', 'Ivanov', 'Concierge', 'Nice one'),
('Elisaveta', 'Bagriana', 'Cleaner', 'Poetesa')
 
CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AccountNumber BIGINT,
FirstName VARCHAR(50),
LastName VARCHAR(50),
PhoneNumber VARCHAR(15),
EmergencyName VARCHAR(150),
EmergencyNumber VARCHAR(15),
Notes VARCHAR(100)
)
 
INSERT INTO Customers
VALUES
(123456789, 'Ginka', 'Shikerova', '359888777888', 'Sistry mi', '7708315342', 'Kinky'),
(123480933, 'Chaika', 'Stavreva', '359888777888', 'Sistry mi', '7708315342', 'Lawer'),
(123454432, 'Mladen', 'Isaev', '359888777888', 'Sistry mi', '7708315342', 'Wants a call girl')
 
CREATE TABLE RoomStatus(
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomStatus BIT,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomStatus(RoomStatus, Notes)
VALUES
(1,'Refill the minibar'),
(2,'Check the towels'),
(3,'Move the bed for couple')
 
CREATE TABLE RoomTypes(
RoomType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO RoomTypes (RoomType, Notes)
VALUES
('Suite', 'Two beds'),
('Wedding suite', 'One king size bed'),
('Apartment', 'Up to 3 adults and 2 children')
 
CREATE TABLE BedTypes(
BedType VARCHAR(50) PRIMARY KEY,
Notes VARCHAR(MAX)
)
 
INSERT INTO BedTypes
VALUES
('Double', 'One adult and one child'),
('King size', 'Two adults'),
('Couch', 'One child')
 
CREATE TABLE Rooms (
RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
RoomType VARCHAR(50) FOREIGN KEY REFERENCES RoomTypes(RoomType),
BedType VARCHAR(50) FOREIGN KEY REFERENCES BedTypes(BedType),
Rate DECIMAL(6,2),
RoomStatus NVARCHAR(50),
Notes NVARCHAR(MAX)
)
 
INSERT INTO Rooms (Rate, Notes)
VALUES
(12,'Free'),
(15, 'Free'),
(23, 'Clean it')
 
CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE,
AccountNumber BIGINT,
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
AmountCharged DECIMAL(14,2),
TaxRate DECIMAL(8, 2),
TaxAmount DECIMAL(8, 2),
PaymentTotal DECIMAL(15, 2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Payments (EmployeeId, PaymentDate, AmountCharged, TaxRate)
VALUES
(1, '12/12/2018', 2000.40, 25.34),
(2, '12/12/2018', 1500.40, 43.59),
(3, '12/12/2018', 1000.40, 67.85)

USE Hotel

DROP TABLE Payments
 
CREATE TABLE Occupancies(
Id  INT PRIMARY KEY IDENTITY NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE,
AccountNumber BIGINT,
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(6,2),
PhoneCharge DECIMAL(6,2),
Notes VARCHAR(MAX)
)
 
INSERT INTO Occupancies (EmployeeId, RateApplied, Notes) VALUES
(1, 55.55, 'too'),
(2, 15.55, 'much'),
(3, 35.55, 'typing')

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses (
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(100) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees (
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL (8, 2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns ([Name])
VALUES
			('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')

INSERT INTO Departments ([Name])
VALUES
			('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')

INSERT INTO Employees 
			(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
VALUES
			('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
			('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
			('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
			('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

SELECT TOP (1000) [Name] FROM Towns
ORDER BY [Name]

SELECT TOP (1000) [Name] FROM Departments
ORDER BY [Name]

SELECT TOP (1000) [FirstName]
		,[LastName]
		,[LastName]
		,[JobTitle]
		,[Salary]
	FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary += 0.1 * Salary

SELECT TOP(5) [Salary] FROM Employees

USE Hotel

UPDATE Payments
SET TaxRate -= 0.03 * TaxRate

SELECT TOP (3) [TaxRate] FROM Payments

TRUNCATE TABLE Occupancies
