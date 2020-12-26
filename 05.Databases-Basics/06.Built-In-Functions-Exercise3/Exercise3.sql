USE SoftUni

SELECT	FirstName, LastName 
FROM	Employees
WHERE	FirstName LIKE 'SA%'

SELECT	FirstName, LastName
FROM	Employees
WHERE	LastName LIKE '%ei%'

SELECT	FirstName
FROM	Employees
WHERE	DepartmentID In (3, 10) AND CAST(DATEPART(YEAR, HireDate) AS INT) BETWEEN 1995 AND 2005


SELECT	FirstName
FROM	Employees
WHERE	DepartmentID = 3 OR DepartmentID = 10 AND CAST(DATEPART(YEAR, HireDate) AS INT) BETWEEN 1995 AND 2005

SELECT	FirstName, Lastname
FROM	Employees
WHERE	JobTitle NOT LIKE '%engineer%'

SELECT		FirstName, Salary, DENSE_RANK() OVER(PARTITION BY Salary ORDER BY FirstName) AS [Rank]
FROM		Employees
ORDER BY	Salary

SELECT [TownId], [Name] FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]

SELECT [TownId], [Name] FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

SELECT [TownId], [Name] FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

SELECT [TownId], [Name] FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'D', 'B')
ORDER BY [Name]

SELECT [TownId], [Name] FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

SELECT EmployeeId, FirstName, LastName, Salary, 
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

SELECT * FROM (SELECT EmployeeId, FirstName, LastName, Salary, 
DENSE_RANK() OVER(PARTITION BY Salary ORDER BY EmployeeId) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS temp
WHERE temp.[Rank] = 2
ORDER BY temp.[Salary] DESC

USE [Geography]

SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

SELECT p.PeakName, r.RiverName, LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
FROM Peaks AS p
INNER JOIN Rivers AS r ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY [Mix]

Use Diablo

SELECT [Name] AS [Game], 
CASE
	WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	ELSE 'Evening'
END AS [Part of the day],
CASE
	WHEN Duration <= 3 THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Game], [Duration], [Part of the day]

Use Diablo

SELECT [Username], [IpAddress] FROM Users
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]

USE SoftUni

SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT 
		FirstName,
		LastName
FROM Employees
WHERE CAST(DATEPART(YEAR, [HireDate]) AS INT) > 2000

SELECT * FROM V_EmployeesHiredAfter2000

SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5

USE [Geography]

SELECT CountryName, IsoCode 
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode

USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) IN (2011, 2012)
ORDER BY [Start], [Name]

SELECT Username, RIGHT([Email], LEN([EMAIL]) - CHARINDEX('@', [Email])) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

USE Orders

SELECT	ProductName, 
		OrderDate, 
		DATEADD(DAY, 3, OrderDate) AS [Pay Due], 
		DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

CREATE DATABASE People

USE People

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Birthdate DATETIME NOT NULL
)

INSERT INTO People([Name], Birthdate) VALUES
('Victor', '2000-12-07 00:00:00.000')

SELECT	[Name], 
		DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
		DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
		DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
		DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People