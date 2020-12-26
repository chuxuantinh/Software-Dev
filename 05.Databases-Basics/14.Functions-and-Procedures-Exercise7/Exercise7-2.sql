USE Bank

CREATE PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(20, 4))
AS
BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId

	IF(@MoneyAmount <= 0)
	BEGIN
		ROLLBACK
		RETURN
	END
	
COMMIT

EXEC dbo.usp_DepositMoney 1, 10

CREATE PROC usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(20, 4)) 
AS
BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId

	IF(SELECT Balance 
		FROM Accounts
		WHERE Id = @AccountId) < 0
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(20, 4)) 
AS
BEGIN TRANSACTION
	EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
	EXEC dbo.usp_WithdrawMoney @SenderId, @Amount

	IF(@SenderId = @ReceiverId)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum DECIMAL(18, 4),
	NewSum DECIMAL(18, 4)
)

CREATE TRIGGER tr_logBalanceChanges ON Accounts FOR UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum) 
	SELECT inserted.Id, deleted.Balance, inserted.Balance
	FROM inserted, deleted
END

CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	[Subject] VARCHAR(100) NOT NULL,
	Body VARCHAR(MAX) NOT NULL
)

CREATE TRIGGER tr_EmailNotification ON Logs FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT inserted.AccountId,
	CONCAT('Balance change for account: ', inserted.AccountId),
	CONCAT('On ', GETDATE(), ' your balance was changed from ', inserted.OldSum, ' to ', inserted.NewSum)
	FROM inserted
END

USE Diablo

CREATE OR ALTER TRIGGER tr_UserGameItems_LevelRestriction ON UserGameItems FOR UPDATE -- or INSERT?
AS
BEGIN
	INSERT INTO UserGameItems
	SELECT i.ItemId, i.UserGameId
	FROM inserted AS i
	
	IF((SELECT [Level]
       FROM UsersGames
       WHERE Id = (SELECT UserGameId
					FROM inserted)) < (SELECT MinLevel
										FROM Items
										WHERE Id = (SELECT ItemId
													FROM inserted)))
	BEGIN
		ROLLBACK
		RAISERROR('Your current level is not enough', 16, 1)
		RETURN
	END
END

UPDATE ug
  SET  ug.Cash += 50000
FROM UsersGames AS ug
     JOIN Users AS u ON u.Id = ug.UserId
     JOIN Games AS g ON g.Id = ug.GameId
WHERE u.Username IN('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
AND g.[Name] = 'Bali'

--Should this be in usp?
DECLARE @itemId INT = 251
WHILE(@itemId <= 299)
BEGIN
	IF((SELECT Price
		FROM Items
		WHERE Id = @itemId) > (SELECT Cash
								FROM UsersGames
								WHERE GameId = (SELECT Id
												FROM Games
												WHERE [Name] = 'Bali') AND UserId = (SELECT Id
																					FROM Users
																					WHERE Username = 'baleremuda')))
	BEGIN 
		RETURN
	END
	ELSE
	BEGIN TRANSACTION
			INSERT INTO UserGameItems VALUES
			(@itemId, (SELECT Id
						FROM Users
						WHERE Username = 'baleremuda')) 

			UPDATE UsersGames
			SET Cash -= (SELECT Price
						FROM Items
						WHERE Id = @itemId)
			WHERE UserId = (SELECT Id
							FROM Users
							WHERE Username = 'baleremuda') AND GameId = (SELECT Id
																		FROM Games
																		WHERE [Name] = 'Bali')
	COMMIT
	SET @itemId += 1
END

--Repeat 4 more time for the other 4 users and then 5 more times for the second group of items.

SELECT u.Username, g.[Name], ug.Cash, i.[Name] AS [Item Name]
FROM Games AS g
JOIN UsersGames AS ug ON ug.GameId = g.Id
JOIN Users AS u ON u.Id = ug.UserId
JOIN UserGameItems AS ugi ON ugi.UserGameId = u.Id
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.[Name] = 'Bali'
ORDER BY u.Username, [Item Name]

--P20

DECLARE @User VARCHAR(MAX) = 'Stamat'
DECLARE @GameName VARCHAR(MAX) = 'Safflower'
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @User)
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = @GameName)
DECLARE @UserMoney MONEY = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
DECLARE @ItemsBulkPrice MONEY
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)

BEGIN TRANSACTION
	SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
	INSERT UserGameItems
	SELECT i.Id, @UserGameId FROM Items AS i
	WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)
	UPDATE UsersGames
	SET Cash = Cash - @ItemsBulkPrice
	WHERE GameId = @GameId AND UserId = @UserId

	IF(@ItemsBulkPrice > @UserMoney)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

SET @UserMoney = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
BEGIN TRANSACTION
	SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
	INSERT UserGameItems
	SELECT i.Id, @UserGameId FROM Items AS i
	WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)
	UPDATE UsersGames
	SET Cash = Cash - @ItemsBulkPrice
	WHERE GameId = @GameId AND UserId = @UserId

	IF(@ItemsBulkPrice > @UserMoney)
	BEGIN
		ROLLBACK
		RETURN
	END
COMMIT

SELECT Name AS 'Item Name' FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @UserGameId)
ORDER BY [Item Name]

--P20v2

DECLARE @User VARCHAR(MAX) = 'Stamat'
DECLARE @GameName VARCHAR(MAX) = 'Safflower'
DECLARE @UserId INT = (SELECT Id FROM Users WHERE Username = @User)
DECLARE @GameId INT = (SELECT Id FROM Games WHERE Name = @GameName)
DECLARE @UserMoney MONEY = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)
DECLARE @ItemsBulkPrice MONEY
DECLARE @UserGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)

BEGIN TRANSACTION
		SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
		IF (@UserMoney - @ItemsBulkPrice >= 0)
		BEGIN
			INSERT UserGameItems
			SELECT i.Id, @UserGameId FROM Items AS i
			WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 11 AND 12)
			UPDATE UsersGames
			SET Cash = Cash - @ItemsBulkPrice
			WHERE GameId = @GameId AND UserId = @UserId
			COMMIT
		END
		ELSE
		BEGIN
			ROLLBACK
		END
			

SET @UserMoney = (SELECT Cash FROM UsersGames WHERE UserId = @UserId AND GameId = @GameId)

BEGIN TRANSACTION
		SET @ItemsBulkPrice = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)
		IF (@UserMoney - @ItemsBulkPrice >= 0)
		BEGIN
			INSERT UserGameItems
			SELECT i.Id, @UserGameId FROM Items AS i
			WHERE i.id IN (Select Id FROM Items WHERE MinLevel BETWEEN 19 AND 21)
			UPDATE UsersGames
			SET Cash = Cash - @ItemsBulkPrice
			WHERE GameId = @GameId AND UserId = @UserId
			COMMIT
		END
		ELSE
		BEGIN
			ROLLBACK
		END


SELECT Name AS 'Item Name' FROM Items
WHERE Id IN (SELECT ItemId FROM UserGameItems WHERE UserGameId = @UserGameId)
ORDER BY [Item Name]

USE SoftUni

--P21

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	INSERT INTO EmployeesProjects
	VALUES (@emloyeeId, @projectID)

	DECLARE @projectForEmployee INT 
	SET @projectForEmployee = (
		SELECT COUNT(*) FROM EmployeesProjects
		WHERE EmployeeID = @emloyeeId
	)

	IF(@projectForEmployee > 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END
COMMIT

--P22

CREATE TABLE Deleted_Employees
(
             EmployeeId   INT IDENTITY,
             FirstName    NVARCHAR(50),
             LastName     NVARCHAR(50),
             MiddleName   NVARCHAR(50),
             JobTitle     NVARCHAR(50),
             DepartmentId INT,
             Salary       DECIMAL(15, 2),
             CONSTRAINT PK_DeletedEmployees PRIMARY KEY(EmployeeId),
             CONSTRAINT FK_DeletedEmployeesDepartments FOREIGN KEY(DepartmentId) REFERENCES Departments(DepartmentId)
)

CREATE TRIGGER tr_DeletedEmployeesSaver ON Employees
FOR DELETE
AS
     BEGIN
         INSERT INTO Deleted_Employees
                SELECT FirstName,
                       LastName,
                       MiddleName,
                       JobTitle,
                       DepartmentID,
                       Salary
                FROM deleted
     END