CREATE DATABASE School

USE School

CREATE TABLE Students(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age SMALLINT CHECK(Age BETWEEN 5 AND 100),
	[Address] NVARCHAR(50),
	Phone NCHAR(10)
)

--CREATE TABLE Students(
--	Id INT PRIMARY KEY IDENTITY,
--	FirstName NVARCHAR(30) NOT NULL,
--	MiddleName NVARCHAR(25),
--	LastName NVARCHAR(30) NOT NULL,
--	Age SMALLINT,
--	[Address] NVARCHAR(50),
--	Phone NCHAR(10),
--	CONSTRAINT CHK_AgeBetween5And100 
--	CHECK(Age >=5 And Age <= 100)
--)

CREATE TABLE Subjects(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
	Id INT PRIMARY KEY IDENTITY,
	[Date] DATETIME2,
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(3, 2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL,
	CONSTRAINT PK_CompositeStudentIdExamId
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName  NVARCHAR(20) NOT NULL,
	[Address] NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
	StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL,
	TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL,
	CONSTRAINT PK_CompositeStudentIdTeacherId
	PRIMARY KEY(StudentId, TeacherId)
)

INSERT INTO Subjects([Name], Lessons) VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

INSERT INTO Teachers(FirstName, LastName, [Address], Phone, SubjectId) VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1, 2) AND Grade >= 5.50

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id
					FROM Teachers
					WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE CHARINDEX('72', Phone) > 0

SELECT FirstName, LastName, Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS TeachersCount
FROM Students AS s
LEFT OUTER JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM Students AS s
LEFT OUTER JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

SELECT TOP(10) s.FirstName, s.LastName, CAST(AVG(se.Grade) AS DECIMAL(3, 2)) AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

SELECT TOP(10) s.FirstName, s.LastName, CAST(ROUND(AVG(se.Grade), 2) AS DECIMAL(3, 2)) AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

--FORMAT N2?

SELECT CONCAT(s.FirstName, ' ' , s.MiddleName + ' ', s.LastName) AS [Full Name]
FROM Students AS s 
LEFT OUTER JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
WHERE ss.StudentId IS NULL
ORDER BY [Full Name]

SELECT s.[Name], AVG(ss.Grade) AS [AverageGrade]
FROM Subjects AS s
JOIN StudentsSubjects AS ss ON ss.SubjectId = s.Id
GROUP BY s.[Name], s.Id
ORDER BY s.Id

CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3, 2))
RETURNS NVARCHAR(100)
AS
BEGIN
	DECLARE @studentName NVARCHAR(30) = (SELECT TOP(1) FirstName
										FROM Students
										WHERE Id = @studentId)
	IF(@studentName IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF(@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @studentsGradeCount INT = (SELECT COUNT(Grade)
										FROM StudentsExams
										WHERE StudentId = @studentId AND (Grade >= @grade AND Grade <= (@grade + 0.50)))

	RETURN CONCAT('You have to update ', @studentsGradeCount, ' grades for the student ', @studentName)
END

CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @studentsMatchingIdCount BIT = (SELECT COUNT(*)
											FROM Students
											WHERE Id = @StudentId)
	IF(@studentsMatchingIdCount = 0)
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1)
		RETURN
	END

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END
