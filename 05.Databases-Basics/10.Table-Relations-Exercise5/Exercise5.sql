CREATE DATABASE TableRelations

USE TableRelations

CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams(
	ExamID INT PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_CompositeStudentIDExamID
	PRIMARY KEY(StudentID, ExamID)
)

INSERT INTO Students([Name]) VALUES
('Mila'), ('Toni'), ('Ron')

INSERT INTO Exams(ExamID, [Name]) VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

CREATE DATABASE University

USE University

CREATE TABLE Majors(
	MajorID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	StudentNumber NVARCHAR(15) NOT NULL,
	StudentName NVARCHAR(60) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID) NOT NULL
)

CREATE TABLE Payments(
	PaymentID INT PRIMARY KEY,
	PaymentDate SMALLDATETIME NOT NULL,
	PaymentAmount DECIMAL(10, 2) NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY,
	SubjectName NVARCHAR(30) NOT NULL
)

CREATE TABLE Agenda(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID  INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_CompositeSudentIDSubjectID
	PRIMARY KEY (StudentID, SubjectID)
)

USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY Elevation DESC

USE SoftUni

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName], 
		e.JobTitle,
		CASE
			WHEN e2.FirstName IS NULL THEN 'No manager'
			ELSE CONCAT(e2.FirstName, ' ', e2.LastName)
		END AS [ManagerName],
		CASE
			WHEN e2.JobTitle IS NULL THEN 'No manager job title'
			ELSE e2.JobTitle
		END AS [ManagerJobTitle]
FROM Employees AS e
LEFT OUTER JOIN Employees AS e2
ON e.ManagerID = e2.EmployeeID
ORDER BY e.EmployeeID

USE TableRelations

CREATE TABLE Persons(
	PersonID INT NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	PassportID INT UNIQUE NOT NULL
)

CREATE TABLE Passports(
	PassportID INT PRIMARY KEY,
	PassportNumber VARCHAR(30) NOT NULL
)

INSERT INTO Persons(PersonID, FirstName, Salary, PassportID) VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

INSERT INTO Passports (PassportID, PassportNumber) VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

ALTER TABLE Persons
ADD CONSTRAINT PK_Id
PRIMARY KEY(PersonID)

ALTER TABLE Persons
ADD CONSTRAINT FK_PersonsPassport
FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)

CREATE TABLE Manufacturers(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
	ModelID INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn) VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

INSERT INTO Models(ModelID, [Name], ManufacturerID) VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID, [Name], ManagerID) VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

CREATE DATABASE OnlineStore

USE OnlineStore

CREATE TABLE Cities(
	CityID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Birtdate DATE NOT NULL,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID) NOT NULL
)

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
	ItemID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
	CONSTRAINT PK_CompositeOrderIDItemID
	PRIMARY KEY(OrderID, ItemID)
)