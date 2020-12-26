SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) FROM Employees

SELECT CONCAT_WS(' ', FirstName, MiddleName, LAstName) FROM Employees

SELECT CONCAT_WS('. ', SUBSTRING(FirstName, 1, 1), SUBSTRING(LastName, 1, 1), '') FROM Employees

SELECT REPLACE('My bad text', 'bad', 'awesome')

SELECT REPLACE(MiddleName, 'R', 'Peshov') FROM Employees

SELECT LEN(TRIM('    Pesho     '))

SELECT CONCAT(LTRIM('    Pesho     '), '...') AS ps

SELECT CONCAT(TRIM('    Pesho     '), '...') AS ps

SELECT LEN('Pesho    1213   ')

SELECT DATALENGTH('Pesho')

SELECT DATALENGTH(N'Пешо')

SELECT N'Пешо'

SELECT LEFT('Very long string', 4)

SELECT LEFT('Very long string', 100)

SELECT RIGHT('Very long string', 6)

CREATE VIEW v_PublicPaymentsInfo AS
SELECT 
	CustomerID, 
	FirstName, 
	LastName, 
	CONCAT(SUBSTRING(PaymentNumber, 1, 6), REPLICATE('*', LEN(PaymentNumber) - 6)) AS PaymentNumber
FROM Customers

SELECT * FROM v_PublicPaymentsInfo

SELECT LOWER('BULGARIA')

SELECT LOWER('BULgArIA')

SELECT UPPER('BULgArIA')

SELECT REVERSE(N'бял хляб')

SELECT CHARINDEX('is', 'This is a long text')

SELECT CHARINDEX('is', 'This is a long text', 4)

SELECT CHARINDEX('iS', 'This is a long text', 4)

SELECT CHARINDEX('iii', 'This is a long text', 4)

SELECT STUFF('This is a bad idea', 11, 0, 'very ')

SELECT STUFF('This is a bad idea', 11, 3, 'good ')

SELECT FORMAT(67.23, 'C', 'bg-BG')

SELECT FORMAT(67.2399999, 'C', 'en-US')

SELECT FORMAT(0.67, 'P', 'en-US')

SELECT FORMAT(CAST('2019-01-21' AS date), 'D', 'en-US')

SELECT FORMAT(CAST('2019-01-21' AS date), N'dd.MM.yyyy г.', 'bg-BG')

SELECT TRANSLATE(N'ав', N'абв', 'abv')

SELECT IIF(LEN(LastName) < 6, LastName, 'Too long') FROM Customers

SELECT PI()

SELECT ABS(-90)

SELECT ABS(SQUARE(12) * -1)

SELECT Id,
       SQRT(SQUARE(X1-X2) + SQUARE(Y1-Y2))
    AS Length
  FROM Lines

SELECT Id, X1, Y1, X2, Y2,
       SQRT(SQUARE(X1-X2) + SQUARE(Y1-Y2))
    AS Length
  FROM Lines

SELECT POWER(CAST(2 AS bigint), 31) - 1

SELECT POWER(CAST(2 AS DECIMAL), 63) - 1

SELECT ROUND(18.567, 2)

SELECT ROUND(18.567, -1)

SELECT ROUND(18.567, -2)

SELECT ROUND(180.567, -2)

SELECT ROUND(1.9, 0)

SELECT ROUND(1.4, 0)

SELECT FLOOR(1.9)

SELECT CEILING(1.1)

SELECT [Name], 
		CEILING(CAST(CEILING(CAST(Quantity AS float) / BoxCapacity) AS float) / PalletCapacity) AS Pallets 
FROM Products

SELECT SIGN(-2563.57)

SELECT SIGN(-2563)

SELECT SIGN(2563.235)

SELECT SIGN(0)

SELECT RAND()

SELECT DATEPART(day, '2019-01-21')

SELECT DATEPART(QUARTER, '2019-01-21')

SELECT DATEPART(WEEKDAY, '2019-01-21')

SELECT DATEPART(WEEK, '2019-01-21')

USE SoftUni

SELECT * FROM Projects
WHERE DATEPART(QUARTER, Startdate) = 3

SELECT * FROM Projects
WHERE DATEPART(WEEKDAY, Startdate) = 2

USE Orders

SELECT	ProductName,
		YEAR(OrderDate),
		MONTH(OrderDate),
		DAY(OrderDate),
		DATEPART(QUARTER, OrderDate)
FROM Orders

SELECT DATEDIFF(SECOND, '2019-01-21T21:11:48', '2019-01-21T21:11:58')

SELECT 
CONCAT_WS(', ', LastName, FirstName) AS Employee,
DATEDIFF(YEAR, HireDate, GETDATE()) AS YearsOfService
FROM Employees
ORDER BY Employee

SELECT DATENAME(WEEKDAY, GETDATE())

SELECT HireDate, DATEADD(YEAR, 5, HireDate) AS [Exp] FROM Employees

SELECT HireDate, DATEADD(DAY, 5, HireDate) AS [Exp] FROM Employees

SELECT HireDate, DATEADD(WEEK, 5, HireDate) AS [Exp] FROM Employees

SELECT EOMONTH(GETDATE(), 1)

SELECT CONVERT(date, '2019-01-21')

SELECT CONVERT(date, '01/01/2019')

SELECT	[Name], 
		ISNULL(CAST(EndDate AS varchar), 'Not finished')
FROM Projects

SELECT	[Name], 
		COALESCE(CAST(EndDate AS varchar), 'Not finished')
FROM Projects

SELECT COALESCE(NULL, NULL, 'FirstValue', NULL, NULL, 'SecondValue')

SELECT EmployeeID, FirstName, LastName
    FROM Employees
ORDER BY EmployeeID
  OFFSET 10 ROWS
   FETCH NEXT 5 ROWS ONLY

SELECT EmployeeID, FirstName, LastName, ROW_NUMBER() OVER (ORDER BY FirstName) FROM Employees

SELECT EmployeeID, FirstName, LastName, RANK() OVER (ORDER BY FirstName) FROM Employees

SELECT EmployeeID, FirstName, LastName, DENSE_RANK() OVER (ORDER BY FirstName) FROM Employees

SELECT	EmployeeID, FirstName, LastName FROM Employees
WHERE	FirstName LIKE 'An%'

SELECT	EmployeeID, FirstName, LastName FROM Employees
WHERE	FirstName LIKE '%nn%'

SELECT	EmployeeID, FirstName, LastName FROM Employees
WHERE	FirstName LIKE 'And_'

SELECT	EmployeeID, FirstName, LastName FROM Employees
WHERE	FirstName LIKE 'And[yr]%'

SELECT	EmployeeID, FirstName, LastName FROM Employees
WHERE	FirstName LIKE 'And[^r]%'

SELECT	EmployeeID, FirstName, LastName FROM Employees
WHERE	FirstName LIKE 'and[^r]%'