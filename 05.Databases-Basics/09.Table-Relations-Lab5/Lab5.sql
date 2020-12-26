SELECT *
FROM Comments
JOIN Authors
ON Comments.AuthorId = Authors.Id

SELECT c.Id, c.[Text], a.FirstName, a.LastName, ar.Title
FROM Comments c
JOIN Authors a
ON c.AuthorId = a.Id
JOIN Articles ar
ON c.ArticleId = ar.Id

USE [Geography]

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks p
JOIN Mountains m
ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY Elevation DESC