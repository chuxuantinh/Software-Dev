USE SoftUni

CREATE OR ALTER PROC usp_AddProjectToEmployee (@emplyeeId INT, @projectId INT)
AS
BEGIN TRANSACTION
	INSERT INTO EmployeesProjects
	VALUES (@emplyeeId, @projectId)

	DECLARE @projectForEmployee INT 
	SET @projectForEmployee = (
		SELECT COUNT(*) FROM EmployeesProjects
		WHERE EmployeeID = @emplyeeId
	)

	IF(@projectForEmployee > 5)
	BEGIN
		ROLLBACK
		RAISERROR('Too many projects for Employee', 16, 1)
		RETURN
	END

COMMIT

GO

EXEC usp_AddProjectToEmployee 1, 1

CREATE OR ALTER TRIGGER tr_NoEmptyTownNames ON Towns FOR UPDATE
AS
BEGIN
	IF(EXISTS(
		SELECT * FROM inserted
		WHERE [Name] IS NULL OR LEN([Name]) < 2))
	BEGIN
		ROLLBACK
		RAISERROR('Town names must have at least 2 symbols', 16, 1)
		RETURN
	END
END

UPDATE Towns SET [Name] = 'A'
WHERE TownID = 1

CREATE OR ALTER TRIGGER tr_SetUpdatedOnDate ON Employees FOR UPDATE
AS
BEGIN
	UPDATE e SET UpdatedOn = GETDATE()
	FROM Employees e JOIN inserted i ON i.EmployeeID = e.EmployeeID
END

UPDATE Employees SET FirstName = 'Ivan'
WHERE EmployeeID = 1 