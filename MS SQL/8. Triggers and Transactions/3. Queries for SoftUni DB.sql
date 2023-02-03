-- 1 Employees with Three Projects
CREATE PROC usp_AssignProject
	(@EmployeeId INT, @ProjectID INT)
AS
BEGIN
    BEGIN TRANSACTION
    DECLARE @EmployeeProjects INT

    SET @EmployeeProjects = (SELECT COUNT(ep.ProjectID)
                            FROM EmployeesProjects ep
                            WHERE ep.EmployeeID = @EmployeeId)

    IF (@EmployeeProjects >= 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
        ROLLBACK
        RETURN
    END

    INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
         VALUES 
			(@EmployeeId, @ProjectID)
    COMMIT
END


-- 2 Delete Employees
CREATE TABLE Deleted_Employees 
(
	EmployeeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    MiddleName NVARCHAR(50),
    JobTitle NVARCHAR(50),
    DepartmentId INT,
    Salary DECIMAL(18, 2)
)

CREATE TRIGGER tr_DeleteEmployees ON Employees
AFTER DELETE AS
BEGIN
    INSERT INTO 
		Deleted_Employees (FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT 
		e.FirstName,
        e.LastName,
        e.MiddleName,
        e.JobTitle,
        e.DepartmentID,
        e.Salary
    FROM DELETED e
END