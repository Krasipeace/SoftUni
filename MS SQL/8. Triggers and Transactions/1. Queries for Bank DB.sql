-- 1 Create Table Logs
CREATE TABLE Logs
(
	LogId INT IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL(20, 4),
	NewSum DECIMAL(20, 4)
)

CREATE TRIGGER tr_AddToLogsWhenBalanceIsChanged
ON Accounts FOR UPDATE
AS
INSERT INTO Logs 
	VALUES
	(
		(SELECT Id FROM inserted), 
		(SELECT Balance FROM deleted), 
		(SELECT Balance FROM inserted)
	)


--	2 Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT IDENTITY PRIMARY KEY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] NVARCHAR(100),
	Body NVARCHAR(100)
)

CREATE TRIGGER tr_AddToLogsWhenEmailNotificationReceived
ON Logs
AFTER INSERT
AS 
BEGIN
    INSERT INTO NotificationEmails (Recipient, Subject, Body)
    SELECT 
		i.AccountId,
		CONCAT('Balance change for account: ', i.AccountId),
		CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum, ' to ', i.NewSum, '.')
	FROM INSERTED i
END


-- 3 Deposit Money
CREATE PROC usp_DepositMoney 
	(@AccountId INT, @MoneyAmount DECIMAL(18, 4)) 
AS
BEGIN
    BEGIN TRANSACTION
        UPDATE Accounts
		SET Balance += @MoneyAmount
		WHERE Id = @AccountId
	COMMIT
END


-- 4 Withdraw Money Procedure
CREATE PROC usp_WithdrawMoney 
	(@AccountId INT, @MoneyAmount DECIMAL(18, 4))
AS
BEGIN
    BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
    COMMIT
END


-- 5 Money Transfer
CREATE PROC usp_TransferMoney (@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18, 4))
AS
BEGIN
    BEGIN TRANSACTION
		IF (@Amount <= 0)
		BEGIN
			ROLLBACK
			RETURN
        END
		EXEC usp_DepositMoney @ReceiverId, @Amount
		EXEC usp_WithdrawMoney @SenderId, @Amount
        COMMIT
END