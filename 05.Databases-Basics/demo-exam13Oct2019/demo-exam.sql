CREATE DATABASE Bitbucket

USE Bitbucket

CREATE TABLE Users(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id),
	ContributorId INT FOREIGN KEY REFERENCES Users(Id),
	CONSTRAINT PK_CompositeRepositoryIdContributorId
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
	Id INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	IssueId INT FOREIGN KEY REFERENCES Issues(Id),
	RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	Size DECIMAL(18, 2) NOT NULL,
	ParentId INT FOREIGN KEY REFERENCES Files(Id),
	CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

INSERT INTO Files([Name], Size, ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)

INSERT INTO Issues(Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

DELETE FROM Issues
WHERE RepositoryId IN (SELECT Id
						FROM Repositories
						WHERE [Name] = 'Softuni-Teamwork')

DELETE FROM RepositoriesContributors
WHERE RepositoryId IN (SELECT Id
						FROM Repositories
						WHERE [Name] = 'Softuni-Teamwork')

SELECT Id, [Message], RepositoryId, ContributorId
FROM Commits
ORDER BY Id, [Message], RepositoryId, ContributorId

SELECT Id, [Name], Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%html%'
ORDER BY Size DESC, Id, [Name]

SELECT i.Id, CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee

SELECT f.Id, f.[Name], CONCAT(f.Size, 'KB') AS Size
FROM Files AS f 
WHERE f.Id NOT IN (SELECT DISTINCT f2.ParentId
					FROM Files AS f2
					WHERE f2.ParentId IS NOT NULL)
ORDER BY f.Id, f.[Name], f.Size DESC

SELECT f2.Id, f2.[Name], CONCAT(f2.Size, 'KB') AS Size
FROM Files AS f
RIGHT JOIN Files AS f2 ON f.ParentId = f2.Id
WHERE f.Id IS NULL
ORDER BY f2.Id, f2.[Name], f2.Size

--SELECT TOP(5) r.Id, r.[Name], COUNT(c.Id) AS Commits
--FROM Commits AS c
--JOIN Repositories AS r ON c.RepositoryId = r.Id
--GROUP BY r.Id, r.[Name]
--ORDER BY Commits DESC, r.Id, r.[Name]

SELECT TOP(5) r.Id, r.[Name], COUNT(c.RepositoryId) AS [Commits] 
FROM Repositories AS r
JOIN Commits AS c
ON c.RepositoryId = r.Id
JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC, r.Id, r.[Name]

--Author's solution
SELECT TOP(5) r.Id, r.[Name], COUNT(*) AS Contributers
FROM RepositoriesContributors AS rc
JOIN Repositories AS r ON rc.RepositoryId = r.Id
JOIN Commits AS c ON c.RepositoryId = r.Id
GROUP BY r.Id, r.[Name]
ORDER BY Contributers DESC, r.Id, r.[Name]

SELECT *
FROM Repositories AS r
JOIN Commits AS c
ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc
ON rc.RepositoryId = r.Id

SELECT u.Username, AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON c.ContributorId = u.Id
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC, u.Username

CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @countOfCommits INT = (
	SELECT COUNT(c.Id)
	FROM Users AS u
	JOIN Commits AS c ON c.ContributorId = u.Id
	WHERE u.Username = @username)
	RETURN @countOfCommits
END

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
BEGIN
	SELECT Id, [Name], CONCAT(f.Size, 'KB')
	FROM Files AS f
	WHERE [Name] LIKE CONCAT('%', @extension)
	ORDER BY Id, [Name], f.Size DESC
END

EXEC usp_FindByExtension 'txt'