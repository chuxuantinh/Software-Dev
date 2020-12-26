USE SoftUni

CREATE FUNCTION udf_ProcessText(@text NVARCHAR)
RETURNS NVARCHAR
AS
BEGIN
	RETURN @text + ' some text'
END

SELECT dbo.udf_ProcessText(e.FirstName)
FROM Employees e

CREATE FUNCTION udf_GetSalaryLevel(@salary DECIMAL)
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel NVARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @salaryLevel = 'Low'
	END
	ELSE IF (@salary <= 50000)
	BEGIN
		SET @salaryLevel = 'Average'
	END
	ELSE 
	BEGIN
		SET @salaryLevel = 'High'
	END
	RETURN @salaryLevel
END

SELECT FirstName, LastName, dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel
FROM Employees

CREATE OR ALTER PROC usp_OldestEmployees
AS
SELECT *
FROM Employees
ORDER BY HireDate DESC

EXEC dbo.usp_OldestEmployees

CREATE OR ALTER PROC usp_OldestEmployees(@totalEmployees INT)
AS
SELECT TOP (@totalEmployees) *
FROM Employees
ORDER BY HireDate DESC

EXEC dbo.usp_OldestEmployees 10

CREATE OR ALTER PROC usp_OldestEmployees(
	@totalEmployees INT, @maxSalary INT = 1000000)
AS
SELECT TOP (@totalEmployees) *
FROM Employees
WHERE Salary < @maxSalary
ORDER BY HireDate DESC

EXEC dbo.usp_OldestEmployees 10, 50000

EXEC dbo.usp_OldestEmployees @totalEmployees = 50, @maxSalary = 50000

CREATE OR ALTER PROC usp_OldestEmployees(
	@totalEmployees INT, @maxSalary INT = 1000000, @result INT OUTPUT)
AS
SET @result = 1000

DECLARE @someAnswer INT
EXEC dbo.usp_OldestEmployees @totalEmployees = 50, @maxSalary = 50000, @someAnswer OUTPUT

IF (@@ERROR > 0)
BEGIN
	SELECT ERROR_MESSAGE()
END

CREATE OR ALTER PROC usp_InsertProject(@employeeId INT, @projectId INT)
AS
BEGIN
	DECLARE @totalProjects INT
	SET @totalProjects = (SELECT COUNT(*) 
	FROM EmployeesProjects ep
	WHERE ep.EmployeeID = @employeeId)
	IF (@totalProjects > 3)
	BEGIN
		THROW 50001, 'Employees cannot have more than 3 projects', 1
	END
	INSERT INTO EmployeesProjects
	VALUES (@employeeId, @projectId)
END

EXEC usp_InsertProject 1, 3