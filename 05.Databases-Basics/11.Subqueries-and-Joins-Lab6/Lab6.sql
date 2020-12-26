USE SoftUni

SELECT * FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID 

SELECT * FROM Employees AS e
CROSS JOIN Departments AS d

SELECT * FROM Employees AS e
RIGHT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.EmployeeID IS NULL

SELECT * FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID > d.DepartmentID 

SELECT	TOP(50) e.FirstName,
		e.LastName,
		t.[Name] AS Town,
		a.AddressText
FROM Employees AS e
LEFT JOIN Addresses AS a
ON e.AddressID = a.AddressID
LEFT JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY FirstName, LastName

SELECT	e.EmployeeID,
		e.FirstName,
		e.LastName,
		d.[Name] AS DepartmentName
FROM Employees As e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

SELECT	e.EmployeeID,
		e.FirstName,
		e.LastName,
		d.[Name] AS DepartmentName
FROM Employees As e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID

SELECT	e.FirstName,
		e.LastName,
		e.HireDate,
		d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
AND d.[Name] IN ('Sales', 'Finance')
WHERE e.HireDate > '1999-01-01'
ORDER BY e.HireDate

SELECT	TOP(50) e.EmployeeID,
		CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
		CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
		d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

SELECT MIN(dt.AverageSalary) AS MinAverageSalary
FROM
(SELECT AVG(Salary) AS AverageSalary, DepartmentID FROM Employees
GROUP BY DepartmentID) AS dt

CREATE TABLE #Employees(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50),
	[Address] VARCHAR(50)
)

SELECT * FROM #Employees

DROP TABLE #Employees

CREATE TABLE ##Employees(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50),
	[Address] VARCHAR(50)
)

SELECT * FROM ##Employees