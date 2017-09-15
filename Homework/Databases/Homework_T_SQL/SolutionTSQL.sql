USE TSHomework

/**

--- 1 ---

CREATE DATABASE TSHomework

CREATE TABLE Persons (
  Id INT IDENTITY,
  FirstName nvarchar(100),
  LastName nvarchar(100),
  SSN INT
  CONSTRAINT PK_Persons PRIMARY KEY(Id)
)



CREATE TABLE Accounts (
  Id INT IDENTITY,
  PersonId INT,
  Balance MONEY
  CONSTRAINT PK_Accounts PRIMARY KEY(Id),
  FOREIGN KEY (PersonId) REFERENCES Persons(Id)
)

ALTER TABLE Persons
ALTER COLUMN SSN VARCHAR(15);

INSERT INTO Persons (FirstName, LastName, SSN)
VALUES (N'Steven', N'Petrov', 'A1234A1234A1234'),
(N'John', N'Void', 'A1234A1234C1234'),
(N'Peter', N'Smith', 'F1234A1234A1234'),
(N'Asslin', N'Wiggalo', 'E1234A1234A1234'),
(N'Amanda', N'Dimoff', 'A1234A1234A1234')

INSERT INTO Accounts (PersonId, Balance)
VALUES (2, 12.0),
(2, 1200.221),
(3, 1222.0),
(1, 1216.34),
(4, 42.238)


GO
CREATE PROC usp_GetFullNameOfPerson	AS 
BEGIN
	SELECT p.FirstName + ' ' + p.LastName [Full name] FROM Persons p
END
GO

EXEC usp_GetFullNameOfPerson



--- 2 ---
GO
CREATE PROC usp_GetPersonsWithMoreThan @sum MONEY AS
BEGIN
	SELECT p.FirstName, p.LastName FROM Persons p JOIN Accounts a ON p.Id = a.PersonId
	WHERE a.Balance > @sum
END

EXEC usp_GetPersonsWithMoreThan 1000
EXEC usp_GetPersonsWithMoreThan 10002312



--- 3 ---
GO

CREATE FUNCTION uf_CalculateLumpSum(@sum MONEY, @interestRate MONEY, @months INT) 
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY;
	SET @result = @sum + @sum * @interestRate * @months / 12
	RETURN @result;
END

GO
DECLARE @ret MONEY;
EXEC @ret = uf_CalculateLumpSum 1000, 0.1, 12;
PRINT @ret;

SELECT p.LastName [Person],
	   a.Balance [Sum],
	   dbo.uf_CalculateLumpSum(a.Balance, 0.1, 12) [New Sum]
FROM Persons p
	INNER JOIN Accounts a ON p.Id = a.PersonId
ORDER BY a.Balance DESC

GO

--- 4 ---

CREATE PROC usp_GetInterestForOneMonth @AccountId INT, @interestRate MONEY AS
BEGIN
	UPDATE Accounts 
	SET Balance = dbo.uf_CalculateLumpSum(Balance, @interestRate, 1)
	WHERE Id = @AccountId
END


GO
EXEC usp_GetInterestForOneMonth @AccountId = 2,
								@interestRate = 0.1

--- 5 ---

GO
CREATE FUNCTION uf_GetNewAmountAfterWithdraw(@sum MONEY, @withdrawn MONEY) 
RETURNS MONEY
AS
BEGIN
	DECLARE @result MONEY = @sum - @withdrawn;
	IF @sum < @withdrawn 
    	RETURN 0;
	RETURN @result
END

GO
ALTER PROC usp_WithdrawMoney @AccountId INT, @sum MONEY AS
BEGIN
	UPDATE Accounts 
	SET Balance = dbo.uf_GetNewAmountAfterWithdraw(Balance, @sum)
	WHERE Id = @AccountId
END



EXEC usp_WithdrawMoney @AccountId = 2,
					   @sum = 1000

GO
CREATE PROC usp_DepositMoney @AccountId INT, @sum MONEY AS
BEGIN
	UPDATE Accounts 
	SET Balance = Balance + @sum
	WHERE Id = @AccountId
END



EXEC usp_DepositMoney @AccountId = 2,
					   @sum = 1000



--- 6 ---

CREATE TABLE Logs (
  LogID INT IDENTITY,
  AccountID INT,
  OldSum MONEY,
  NewSum MONEY
  CONSTRAINT PK_Logs PRIMARY KEY(LogID),
  FOREIGN KEY (AccountID) REFERENCES Accounts(Id)
)


GO
ALTER TRIGGER tr_LogOnChangeOfSum
	ON Accounts
	AFTER UPDATE
AS
BEGIN
	IF EXISTS (SELECT * FROM DELETED) AND EXISTS (SELECT * FROM INSERTED)
	BEGIN
		INSERT INTO Logs (AccountID, OldSum, NewSum)
		SELECT d.PersonId, d.Balance, i.Balance
		FROM DELETED d, INSERTED i
	END
END

UPDATE Accounts 
SET Balance = 4000
WHERE Id = 2;

UPDATE Accounts 
SET Balance = 7000
WHERE Id = 2;

--- 7 ---

USE TelerikAcademy

GO
CREATE FUNCTION uf_ContainsAllCharsFrom(@charSet NVARCHAR(MAX), @target NVARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @ret BIT = 1;
	DECLARE @len INT = LEN(@charSet);
	DECLARE @currentChar CHAR;

	WHILE @len > 0 BEGIN
		SET @currentChar = RIGHT(@charSet, @len);
		IF CHARINDEX(@currentChar, @target) = 0 BEGIN  
        	SET @ret = 0;
        END

		SET @len = @len - 1;
    END

	RETURN @ret;
END

GO
CREATE FUNCTION uf_GetNamesAndTownWithLettersIn(@charSet NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	Declare @query as varchar(max);

	SET @query = 
		'SELECT e.FirstName,
			   e.LastName,
			   e.MiddleName,
			   t.Name
		FROM Employees e
			JOIN Addresses a ON e.AddressID = a.AddressID
			JOIN Towns t ON a.TownID = t.TownID
		WHERE dbo.uf_ContainsAllCharsFrom(' + @charSet + ', e.FirstName) > 0
			AND dbo.uf_ContainsAllCharsFrom('+ @charSet +', e.LastName) > 0
			AND dbo.uf_ContainsAllCharsFrom('+ @charSet +', e.MiddleName) > 0
			AND dbo.uf_ContainsAllCharsFrom('+ @charSet +', t.Name) > 0'
	
	RETURN @query;
END



-- TEST
USE TelerikAcademy
PRINT(dbo.uf_GetNamesAndTownWithLettersIn('a'))

*/

--- 8 ---

