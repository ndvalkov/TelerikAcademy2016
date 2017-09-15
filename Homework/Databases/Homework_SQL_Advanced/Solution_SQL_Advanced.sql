USE TelerikAcademy

/**
--- 1 ---

SELECT e.FirstName, e.LastName, e.Salary FROM Employees e
WHERE e.Salary IN
(SELECT MIN(Salary) FROM Employees)



--- 2 ---

SELECT e.FirstName, e.LastName, e.Salary FROM Employees e
WHERE e.Salary <= 1.1 *
(SELECT MIN(Salary) FROM Employees)


--- 3 ---
SELECT e.FirstName + ' ' + e.LastName [Full Name],
	   e.Salary,
	   d.Name [Department]
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE Salary = 
  (SELECT MIN(Salary) FROM Employees 
   WHERE DepartmentID = e.DepartmentID)
   


--- 4 ---

SELECT AVG(e.Salary) [Average Salary] FROM Employees e
   WHERE e.DepartmentID = 1

   
--- 5 ---


SELECT AVG(e.Salary) [Average Salary] FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'



--- 6 ---

SELECT Count(*) [Employee Count] FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'

--- 7 ---

SELECT COUNT(*) [Employees with manager] FROM Employees e
INNER JOIN Employees e1 ON e.ManagerID = e1.EmployeeID


--- 8 ---

SELECT COUNT(*) [Employees without manager] FROM Employees e
WHERE e.ManagerID IS NULL



--- 9 ---

SELECT d.Name [Department],
	   AVG(e.Salary) [Average Salary]
FROM Departments d
	INNER JOIN Employees e ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name



--- 10 ---

SELECT d.Name [Department],
	   t.Name [Town],
	   COUNT(*) [Employees]
FROM Departments d
	INNER JOIN Employees e ON d.DepartmentID = e.DepartmentID
	INNER JOIN Addresses a ON e.AddressID = a.AddressID
	INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name, d.Name



--- 11 ---

SELECT e.FirstName + ' ' + e.LastName [Manager],
	   COUNT(e.FirstName + ' ' + e.LastName) [Employees]
FROM Employees e
	INNER JOIN Employees e1 ON e.EmployeeID = e1.ManagerID
GROUP BY e.FirstName + ' ' + e.LastName
HAVING COUNT(e.FirstName + ' ' + e.LastName) = 5



--- 12 ---

SELECT e.LastName [Employee],
	   COALESCE(e1.LastName, 'No manager') [Manager]
FROM Employees e
	LEFT OUTER JOIN Employees e1 ON e.ManagerID = e1.EmployeeID

	

--- 13 ---

SELECT e.LastName FROM Employees e
WHERE LEN(e.LastName) = 5



--- 14 ---
SELECT CONVERT(VARCHAR(12), GETDATE(), 114)



--- 15 ---

CREATE TABLE Users (
  UserID int IDENTITY,
  Username nvarchar(100) NOT NULL,
  Password nvarchar(100),
  LastLoginTime DATETIME,
  CONSTRAINT PK_Users PRIMARY KEY(UserID),
  CONSTRAINT UC_Users UNIQUE (Username),
  CHECK (LEN(Password) >= 5)
)

--- 16 ---

CREATE VIEW [Users Logged Today] AS
SELECT *
FROM Users u
WHERE CONVERT(VARCHAR(10), u.LastLoginTime, 120) = CONVERT(VARCHAR(10), GETDATE(), 120)



--- 17 ---

CREATE TABLE Groups (
  GroupID int IDENTITY,
  Name nvarchar(100) NOT NULL
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID),
  CONSTRAINT UC_Groups UNIQUE (Name)
)

--- 18 ---

ALTER TABLE Users ADD GroupID int

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)

SELECT * FROM Users u INNER JOIN Groups g ON u.GroupID = g.GroupID



--- 19 ---

INSERT INTO Users (Username, Password, LastLoginTime, GroupID)
VALUES ('Pesho', 'asdasdasd', GETDATE(), 5);
INSERT INTO Users (Username, Password, LastLoginTime, GroupID)
VALUES ('Stavri', 'qwerty', GETDATE(),6);
INSERT INTO Users (Username, Password, LastLoginTime, GroupID)
VALUES ('Anna', 'princess123', GETDATE(),5);

INSERT INTO Groups (Name)
VALUES ('Lostpedia');

--- 20 ---

UPDATE Users 
SET Password = 'wedding123',
	LastLoginTime = GETDATE(),
	GroupID = 5
WHERE Username = 'Anna';

UPDATE Groups
SET Name = 'Darkufo'
WHERE GroupID = 7;



--- 21 ---

DELETE FROM Users WHERE Username = 'Stavri'



--- 22 ---

INSERT INTO Users (Username, Password, LastLoginTime, GroupID)
SELECT LEFT(e.FirstName, 1) + LOWER(e.LastName) + CAST(e.EmployeeID AS VARCHAR(100)),
	   LEFT(e.FirstName, 1) + '____' + LOWER(e.LastName),
	   NULL,
	   5
FROM Employees e



--- 23 ---

UPDATE Users
SET Password = NULL
WHERE LastLoginTime > '10.03.2010';

--- 24 ---

DELETE FROM Users WHERE Password IS NULL



--- 25 ---

SELECT e.JobTitle, d.Name [Department],
	   AVG(e.Salary) [Avg]
FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name
	
	

--- 26 ---

SELECT e.FirstName, e.LastName, e.Salary FROM Employees e WHERE e.Salary IN
(SELECT DISTINCT MIN(e.Salary) [Min Salary]
FROM Employees e
	INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name,
		 e.JobTitle)



--- 27 ---

SELECT TOP 1 r.Town
FROM (
	SELECT t.Name [Town],
		   COUNT(*) [Employees]
	FROM Employees e
		INNER JOIN Addresses a ON e.AddressID = a.AddressID
		INNER JOIN Towns t ON a.TownID = t.TownID
	GROUP BY t.Name
) r
GROUP BY r.Employees, r.Town
ORDER BY r.Employees DESC



--- 28 ---

SELECT DISTINCT t.Name [Town], Count(*) [Managers in town]
FROM Employees e
	INNER JOIN Employees e1 ON e.ManagerID = e1.EmployeeID
	INNER JOIN Addresses a ON e1.AddressID = a.AddressID
	INNER JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name



--- 29 ---

CREATE TABLE WorkHours (
  WorkHoursID int IDENTITY,
  Date DATETIME,
  Task NVARCHAR(100),
  Hours INT,
  Comments NVARCHAR(100),
  EmloyeeID INT,
  CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursID),
  FOREIGN KEY (EmloyeeID) REFERENCES Employees(EmployeeID)
)

INSERT INTO WorkHours (Date, Task, Hours, Comments, EmloyeeID)
VALUES (GETDATE(), 'Todo dishes', 12, 'I don''t feel like doing it', 12),
(GETDATE(), 'Todo dishes', 12, 'I don''t feel like doing it', 2),
(GETDATE(), 'Todo dishes', 14, 'I don''t feel like doing it', 1),
(GETDATE(), 'Todo dishes', 12, 'OK', 3),
(GETDATE(), 'Todo dishes', 13, 'It''s great', 4),
(GETDATE(), 'Todo dishes', 1, 'I don''t feel like doing it', 6)

UPDATE WorkHours 
SET Task = 'Clean bedroom',
	Hours = 2
WHERE EmloyeeID = 12;

DELETE WorkHours WHERE EmloyeeID = 12;

CREATE TABLE WorkHoursLogs (
  WorkHoursLogsID int IDENTITY,
  OldRecord NVARCHAR(100),
  NewRecord NVARCHAR(100),
  Command NVARCHAR(100),
  CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(WorkHoursLogsID)
)



GO

CREATE TRIGGER tr_LogWorkHoursChange
	ON WorkHours
	AFTER INSERT, UPDATE, DELETE
AS

	DECLARE @HistoryType CHAR(1) --"I"=insert, "U"=update, "D"=delete

	SET @HistoryType = NULL

	IF EXISTS (SELECT * FROM INSERTED)
	BEGIN
		IF EXISTS (SELECT * FROM DELETED)
		BEGIN
			--UPDATE
			SET @HistoryType = 'U'
		END
		ELSE
		BEGIN
			--INSERT
			SET @HistoryType = 'I'
		END

		INSERT INTO WorkHoursLogs (OldRecord, NewRecord, Command)
		SELECT NULL,
			   CAST(i.Date AS VARCHAR(30)) + '---' + i.Task + '---' + CAST(i.Hours AS VARCHAR(30)) + '---' + i.Comments,
			   @HistoryType
		FROM INSERTED i
	END
	ELSE
	IF EXISTS (SELECT * FROM DELETED)
	BEGIN
		--DELETE
		SET @HistoryType = 'D'

		INSERT INTO WorkHoursLogs (OldRecord, NewRecord, Command)
		SELECT NULL,
			   CAST(d.Date AS VARCHAR(30)) + '---' + d.Task + '---' + CAST(d.Hours AS VARCHAR(30)) + '---' + d.Comments,
			   @HistoryType
		FROM DELETED d
	END

	

	---TEST Trigger ---

	DELETE FROM WorkHours WHERE EmloyeeID = 2

	INSERT INTO WorkHours (Date, Task, Hours, Comments, EmloyeeID)
		VALUES (GETDATE(), 'Kill Moon', 23, 'Sudden Departure', 15);


--- 30 ---


BEGIN TRAN
	ALTER TABLE Employees
	DROP CONSTRAINT FK_Employees_Departments
	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees
	DELETE FROM Employees
	WHERE EmployeeID IN (
			SELECT e.EmployeeID
			FROM Employees e
				INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
			WHERE d.Name = 'Sales'
		)
	DELETE FROM Departments
	WHERE Name = 'Sales'
ROLLBACK TRAN



--- 31 ---

BEGIN TRAN
DROP TABLE EmployeesProjects


--- magic ---
ROLLBACK TRAN



--- 32 ---

IF OBJECT_ID('tempdb.dbo.#work_hours_temp') IS NOT NULL
       	DROP TABLE #work_hours_temp
       GO
       
       CREATE TABLE #work_hours_temp
       (
       	ID INT PRIMARY KEY,
       	Name VARCHAR(50)
       )
       

select top 0 *
into #work_hours_temp1
from WorkHours

???
*/
