SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ManageRolePermissions]
    @Action NVARCHAR(50),
    @RoleId NVARCHAR(450),
    @ModuleName NVARCHAR(100),
    @CanAccess BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF @Action = 'INSERT'
        INSERT INTO RolePermissions (RoleId, ModuleName, CanAccess)
        VALUES (@RoleId, @ModuleName, @CanAccess);
    ELSE IF @Action = 'SELECT'
        SELECT Id, RoleId, ModuleName, CanAccess
        FROM RolePermissions
        WHERE RoleId = @RoleId AND ModuleName = @ModuleName;
END
GO
