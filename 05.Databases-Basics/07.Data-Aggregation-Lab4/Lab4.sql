USE SoftUni

SELECT *
FROM Employees
WHERE DepartmentID = 1

SELECT e.DepartmentID
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID, SUM(e.Salary)
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID, MAX(e.Salary)
FROM Employees e
GROUP BY e.DepartmentID

SELECT DepartmentId
FROM Employees

SELECT DISTINCT DepartmentId
FROM Employees

SELECT e.DepartmentID, SUM(e.Salary) AS Salary
FROM Employees e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

SELECT e.DepartmentID, SUM(e.Salary) AS Salary
FROM Employees e
GROUP BY e.DepartmentID
ORDER BY Salary

SELECT e.DepartmentID, COUNT(e.DepartmentID) AS Employees
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.FirstName, e.LastName, d.[Name]
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID

SELECT *
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID

SELECT *
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], d.[Name] AS Department, a.AddressText
FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
ON e.AddressID = a.AddressID

SELECT DepartmentID, MIN(e.Salary) AS MinSalary
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID, MAX(e.Salary) AS MaxSalary
FROM Employees e
GROUP BY e.DepartmentID

SELECT DepartmentID, AVG(e.Salary) AS AvgSalary
FROM Employees e
GROUP BY e.DepartmentID

SELECT DepartmentID, SUM(e.Salary) AS TotalSalary
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID, COUNT(*) AS Employees
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID, COUNT(e.DepartmentID) AS Employees
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID,
	STRING_AGG(e.FirstName + ' ' + e.LastName, ', ') AS Employees
FROM Employees e
GROUP BY e.DepartmentID

SELECT e.DepartmentID,
	SUM(e.Salary) AS TotalSalary,
	STRING_AGG(e.Salary, ', ') AS Salaries
FROM Employees e
GROUP BY e.DepartmentID
HAVING SUM(e.Salary) > 200000

SELECT e.DepartmentID,
	SUM(e.Salary) AS TotalSalary,
	STRING_AGG(e.Salary, ', ') AS Salaries
FROM Employees e
WHERE e.Salary > 10000
GROUP BY e.DepartmentID
