SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_ManageChartOfAccounts]
    @Action NVARCHAR(20),
    @Id INT = NULL,
    @Name NVARCHAR(100) = NULL,
    @ParentAccountId INT = NULL,
    @Balance DECIMAL(18, 2) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'SELECT'
    BEGIN
        SELECT AccountId AS Id, AccountName AS Name, ParentAccountId, AccountBalance AS Balance
        FROM ChartOfAccounts;
    END

    ELSE IF @Action = 'SELECT_BY_ID'
    BEGIN
        SELECT AccountId AS Id, AccountName AS Name, ParentAccountId, AccountBalance AS Balance
        FROM ChartOfAccounts
        WHERE AccountId = @Id;
    END

    ELSE IF @Action = 'INSERT'
    BEGIN
        INSERT INTO ChartOfAccounts (AccountName, ParentAccountId, AccountBalance)
        VALUES (@Name, @ParentAccountId, @Balance);
    END

    ELSE IF @Action = 'UPDATE'
    BEGIN
        UPDATE ChartOfAccounts
        SET AccountName = @Name,
            ParentAccountId = @ParentAccountId,
            AccountBalance = @Balance
        WHERE AccountId = @Id;
    END

    ELSE IF @Action = 'DELETE'
    BEGIN
        DELETE FROM ChartOfAccounts
        WHERE AccountId = @Id;
    END
END;

GO
