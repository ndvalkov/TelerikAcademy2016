USE TelerikAcademy

/**
--- 4 ---

SELECT * FROM Departments d


--- 5 ---

SELECT d.Name FROM Departments d


--- 6 ---

SELECT e.FirstName, e.LastName, e.Salary FROM Employees e


--- 7 ---

SELECT e.FirstName + ' ' + e.LastName [Full Name] FROM Employees e


--- 8 ---

SELECT e.FirstName + '.' + e.LastName + '@telerik.com' [Full Email Addresses] FROM Employees e


--- 9 ---

SELECT DISTINCT e.Salary FROM Employees e


--- 10 ---

SELECT * FROM Employees e
WHERE e.JobTitle = 'Sales Representative'


--- 11 ---

SELECT e.FirstName, e.LastName FROM Employees e
WHERE e.FirstName LIKE 'SA%'



--- 12 ---

SELECT e.FirstName, e.LastName FROM Employees e
WHERE e.LastName LIKE '%ei%'



--- 13 ---

SELECT e.FirstName, e.LastName, e.Salary FROM Employees e
WHERE e.Salary BETWEEN 20000 AND 30000


--- 14 ---

SELECT e.FirstName, e.LastName FROM Employees e
WHERE e.Salary IN (25000, 14000, 12500, 23600)


--- 15 ---

SELECT e.LastName [Employee Without Manager] FROM Employees e
WHERE e.ManagerID IS NULL



--- 16 ---

SELECT e.LastName, e.Salary FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC



--- 17 ---

SELECT TOP 5 e.Salary FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC


--- 18 ---

SELECT e.LastName,
	   a.AddressText [Address]
FROM Employees e
	INNER JOIN Addresses a ON e.AddressID = a.AddressID

--- 19 ---

SELECT e.LastName,
	   a.AddressText [Address]
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--- 20 ---

SELECT e.LastName [Employee], COALESCE(e1.LastName, 'No manager') [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees e1 ON e.ManagerID = e1.EmployeeID

	

--- 21 ---

SELECT e.LastName [Employee],
	   COALESCE(e1.LastName, 'No manager') [Manager],
	   COALESCE(a.AddressText, 'No address')  [Address]
FROM Employees e
	LEFT OUTER JOIN Employees e1 ON e.ManagerID = e1.EmployeeID
	LEFT OUTER JOIN Addresses a ON e.AddressID = a.AddressID

--- 22 ---

SELECT d.Name FROM Departments d
UNION
SELECT t.Name FROM Towns t



--- 23 ---

SELECT e1.LastName [Employee], COALESCE(e.LastName, 'No manager') [Manager]
FROM Employees e
	RIGHT OUTER JOIN Employees e1 ON e.EmployeeID = e1.ManagerID
	

--- 24 ---

SELECT *
FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name = 'Finance')
	AND e.HireDate >= '1995/01/01'
	AND e.HireDate <= '2005/01/01'

*/










