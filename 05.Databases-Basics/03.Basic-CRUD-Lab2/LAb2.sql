SELECT	FirstName + ' ' + LastName AS [Full Name],
		JobTitle,
		Salary
FROM	Employees

SELECT FirstName + ' ' + LastName AS 'Full Name'
FROM Employees

SELECT DISTINCT DepartmentId
FROM			Employees

SELECT DISTINCT DepartmentId, JobTitle
FROM			Employees

SELECT *
FROM	Employees
WHERE	DepartmentID = 1

SELECT *
FROM	Employees
WHERE	Salary >= 80000

SELECT *
FROM	Employees
WHERE	Salary >= 30000 AND Salary <= 80000

SELECT *
FROM	Employees
WHERE	Salary = 30000 OR Salary = 80000

SELECT *
FROM	Employees
WHERE	Salary BETWEEN 30000 AND 80000

SELECT *
FROM	Employees
WHERE	NOT (Salary BETWEEN 30000 AND 80000)

SELECT *
FROM	Employees
WHERE	DepartmentID = 1 OR DepartmentID = 2 OR DepartmentID = 3

SELECT *
FROM	Employees
WHERE	DepartmentID IN (1, 2, 3)

SELECT *
FROM	Employees
WHERE MiddleName IS NULL

SELECT *
FROM	Employees
ORDER BY Salary

SELECT *
FROM	Employees
ORDER BY Salary DESC

SELECT TOP (5) *
FROM Employees
ORDER BY Salary

CREATE VIEW v_EmployeesSalaryInfo AS
SELECT	FirstName + ' ' + LastName AS [Full Name],
		Salary
FROM	Employees

SELECT * FROM v_EmployeesSalaryInfo

INSERT INTO Projects ([Name], StartDate)
SELECT [Name], GETDATE()
FROM Departments

SELECT	FirstName, LastName, JobTitle
INTO	MyFiredEmployees
FROM	Employees

CREATE SEQUENCE sq_MySequence
		 AS INT
	 START WITH 1
   INCREMENT BY 1

SELECT NEXT VALUE FOR sq_MySequence

CREATE SEQUENCE sq_MySequence10
		 AS INT
	 START WITH 10
   INCREMENT BY -1
 
SELECT NEXT VALUE FOR sq_MySequence10

CREATE SEQUENCE sq_MySequence123
		 AS INT
	 START WITH 10
   INCREMENT BY 10
       MINVALUE 10
       MAXVALUE 50

SELECT NEXT VALUE FOR sq_MySequence123

CREATE SEQUENCE sq_MySequence1234
		 AS INT
	 START WITH 10
   INCREMENT BY 10
       MINVALUE 10
       MAXVALUE 50
	   CYCLE

SELECT NEXT VALUE FOR sq_MySequence1234

DELETE FROM Employees
WHERE EmployeeID = 1

SELECT * FROM Addresses
WHERE TownID = 1

DELETE FROM Towns
WHERE		TownID = 1

DELETE FROM Addresses
WHERE		TownID = 1

UPDATE	Addresses
SET		TownID = NULL
WHERE	TownID = 1

UPDATE	Addresses
SET		TownID = NULL, AddressText = NULL
WHERE	TownID = 1

DELETE FROM Towns

INSERT INTO Towns VALUES ('Plovdiv')

TRUNCATE TABLE Towns

UPDATE Employees 
SET Salary *= 1.10
WHERE DepartmentID = 3

UPDATE Projects
SET EndDate = GETDATE()
WHERE EndDate IS NULL

CREATE TABLE MyTable
(
	MyDate DATE,
	MyTime TIME,
	MyDateTime DATETIME
)

INSERT INTO MyTable (MyDate, MyTime, MyDateTime) VALUES
('01.01.2019', '20:41', '01.01.2019 12:45:33')


