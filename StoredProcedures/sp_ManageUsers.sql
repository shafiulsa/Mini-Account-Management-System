SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_ManageUsers]
    @Action NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'SELECT'
    BEGIN
        SELECT 
            u.Id, 
            u.UserName, 
            u.Email, 
            STRING_AGG(r.Name, ', ') AS Roles  
        FROM AspNetUsers u
        LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
        LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
        GROUP BY u.Id, u.UserName, u.Email
        ORDER BY u.UserName;
    END
END
GO
