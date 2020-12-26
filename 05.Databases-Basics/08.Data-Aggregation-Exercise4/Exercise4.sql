USE Gringotts

SELECT MAX(MagicWandSize)
AS LongestMagicWand
FROM WizzardDeposits

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

SELECT DepositGroup FROM (SELECT TOP(2) DepositGroup, AVG(MagicWandSize) AS [AvgSize]
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY [AvgSize]) AS AvgSizeTable

SELECT
CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END AS [AgeGroup],
COUNT(*) AS [WizardCount] 
FROM WizzardDeposits
GROUP BY CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	ELSE '[61+]'
END

SELECT SUM([Difference]) AS [SumDifference] FROM (SELECT	FirstName AS [Host Wizard],
		DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
		LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
		DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
FROM WizzardDeposits) AS DiffTable

USE SoftUni

SELECT DISTINCT DepartmentID, Salary AS [ThirdHighestSalary] FROM (SELECT DepartmentID, Salary, DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranking]
FROM Employees) AS [RankTable]
WHERE [Ranking] = 3

SELECT DepartmentID, Salary AS [ThirdHighestSalary] FROM (SELECT DepartmentID, Salary, DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranking]
FROM Employees GROUP BY DepartmentID, Salary) AS [RankTable]
WHERE [Ranking] = 3

SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS e1
WHERE Salary > (
				SELECT AVG(Salary) AS [AvgSalary]
				FROM Employees AS e2
				WHERE e2.DepartmentID = e1.DepartmentID
				GROUP BY DepartmentID
)
ORDER BY e1.DepartmentID

SELECT * INTO NewEmployeesTable FROM Employees
WHERE Salary > 30000

DELETE FROM NewEmployeesTable
WHERE ManagerID = 42

UPDATE NewEmployeesTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS [AverageSalary]
FROM NewEmployeesTable
GROUP BY DepartmentID

USE Gringotts

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup

SELECT DepositGroup, SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

SELECT LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY LEFT(FirstName, 1)

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

USE SoftUni

SELECT DepartmentID, SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

SELECT DepartmentID, MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

SELECT DepartmentID, MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

SELECT COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL