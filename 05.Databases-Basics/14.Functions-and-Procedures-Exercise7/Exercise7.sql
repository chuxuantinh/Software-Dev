USE SoftUni

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary > 35000
END

CREATE PROC usp_GetEmployeesSalaryAboveNumber(@minSalary DECIMAL(18, 4))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @minSalary
END

CREATE PROC usp_GetTownsStartingWith(@string VARCHAR(MAX))
AS
BEGIN
	SELECT t.[Name]
	FROM Towns AS t
	WHERE LEFT(t.[Name], LEN(@string)) = @string
END

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7) =
	CASE
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
	END
	RETURN @salaryLevel
END

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) FROM Employees

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(7)
	IF(@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF(@salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @salaryLevel = 'High'
	END
	RETURN @salaryLevel
END

CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(7))
AS
BEGIN
	SELECT e.Firstname, e.LastName
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END

EXEC dbo.usp_EmployeesBySalaryLevel 'High'

CREATE PROC usp_EmployeesBySalaryLevel1 @salaryLevel VARCHAR(7)
AS
BEGIN
	SELECT e.Firstname, e.LastName
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @counter INT = 1
	DECLARE @currentLetter CHAR
	WHILE(@counter <= LEN(@word))
	BEGIN
		SET @currentLetter = SUBSTRING(@word, @counter, 1)
		DECLARE @charIndex INT = CHARINDEX(@currentLetter, @setOfLetters)
		IF(@charIndex <= 0)
		BEGIN
			RETURN 0
		END
		SET @counter += 1
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (
		SELECT EmployeeID 
		FROM Employees
		WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID 
		FROM Employees
		WHERE DepartmentID = @departmentId)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

USE Bank

CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName )
	FROM AccountHolders
END

EXEC dbo.usp_GetHoldersFullName

CREATE PROC usp_GetHoldersWithBalanceHigherThan @minBalance MONEY
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @minBalance
	ORDER BY ah.FirstName, ah.LastName
END

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 1000

CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18, 4) 
AS
BEGIN
	RETURN @sum * POWER((1 + @yearlyInterestRate), @numberOfYears)
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

CREATE PROC usp_CalculateFutureValueForAccount(@accountId INT, @interestRate FLOAT)
AS
BEGIN
	SELECT a.Id, ah.FirstName, ah.LastName, a.Balance, dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5)
	FROM Accounts AS a
	JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId
END

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1

USE Diablo

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(MAX))
RETURNS @output TABLE (SumCash DECIMAL(18, 4))
AS
BEGIN
	INSERT INTO @output SELECT (SELECT SUM(Cash) AS [SumCash] FROM (SELECT *, ROW_NUMBER() OVER(ORDER BY Cash DESC) AS [RowNum] FROM UsersGames
	WHERE GameId IN (
	SELECT Id FROM Games
	WHERE [Name] = @gameName)) AS [RowNumTable]
	WHERE [RowNum] % 2 <> 0)
	RETURN
END

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

USE SoftUni

CREATE PROC usp_GetEmployeesFromTown @townName VARCHAR(MAX)
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	JOIN Addresses As a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @townName
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'