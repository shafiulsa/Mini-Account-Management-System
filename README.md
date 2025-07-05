

```markdown
# 📘 Mini Account Management System

A role-based ASP.NET Core Razor Pages application to manage Chart of Accounts and Vouchers using SQL Server stored procedures. Built with clean structure, identity-based security, and full CRUD features.

---

## 📦 Features

- 🔐 ASP.NET Identity Authentication with custom roles (Admin, Accountant, Viewer)
- 📋 Chart of Accounts (Hierarchical)
- 💳 Voucher Management (Journal, Payment, Receipt)
- 🧾 Multi-line Debit/Credit Entries using Table-Valued Parameters (TVP)
- 🧑‍💻 Role-based access (View/Edit/Delete permissions)
- 📤 Export to Excel using ClosedXML
- 🧮 Stored procedure–based logic (no LINQ)

---

## 🧰 Technologies Used

| Stack       | Description |
|-------------|-------------|
| .NET 8      | ASP.NET Core Razor Pages |
| SQL Server  | Database with stored procedures |
| Bootstrap 5 | UI styling |
| Identity    | User + Role management |
| ClosedXML   | Export Excel |
| jQuery      | Dynamic form row handling |

---

## 🏗 Folder Structure

```

MiniAccountManagementSystem/
└── Microsoft.CodeAnalysis.Workspaces.resources.dll
├── Data
│   └── AppDbContext.cs
├── MiniAccountManagementSystem.csproj
├── Models
│   ├── Account.cs
│   ├── AccountTypes.cs
│   ├── RolePermission.cs
│   ├── Voucher.cs
│   └── VoucherEntry.cs
├── Pages
│   ├── Account
│   │   ├── AccessDenied.cshtml
│   │   ├── AccessDenied.cshtml.cs
│   │   ├── Login.cshtml
│   │   ├── Login.cshtml.cs
│   │   ├── Logout.cshtml
│   │   ├── Logout.cshtml.cs
│   │   ├── Register.cshtml
│   │   └── Register.cshtml.cs
│   ├── ChartOfAccounts
│   │   ├── All.cshtml
│   │   ├── All.cshtml.cs
│   │   ├── Create.cshtml
│   │   ├── Create.cshtml.cs
│   │   ├── Delete.cshtml
│   │   ├── Delete.cshtml.cs
│   │   ├── Edit.cshtml
│   │   ├── Edit.cshtml.cs
│   │   ├── Index.cshtml
│   │   ├── Index.cshtml.cs
│   │   ├── View.cshtml
│   │   └── View.cshtml.cs
│   ├── Error.cshtml
│   ├── Error.cshtml.cs
│   ├── Index.cshtml
│   ├── Index.cshtml.cs
│   ├── ManageUsers
│   │   ├── Delete.cshtml
│   │   ├── Delete.cshtml.cs
│   │   ├── Edit.cshtml
│   │   └── Edit.cshtml.cs
│   ├── Privacy.cshtml
│   ├── Privacy.cshtml.cs
│   ├── Shared
│   │   ├── _Layout.cshtml
│   │   ├── _Layout.cshtml.css
│   │   └── _ValidationScriptsPartial.cshtml
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   └── Vouchers
│       ├── Create.cshtml
│       ├── Create.cshtml.cs
│       ├── Delete.cshtml
│       ├── Delete.cshtml.cs
│       ├── Edit.cshtml
│       ├── Edit.cshtml.cs
│       ├── Index.cshtml
│       └── Index.cshtml.cs
├── Program.cs

└── README.md

````

---

## 🛠 Setup Instructions

### 1️⃣ Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/)
- SQL Server (LocalDB or Full)
- Visual Studio or VS Code

---

### 2️⃣ Clone and Restore

```bash
git clone https://github.com/yourname/MiniAccountManagementSystem.git
cd MiniAccountManagementSystem
dotnet restore
````

---

### 3️⃣ Update `appsettings.json`

```{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MiniAccountManagementSystem;User Id=sa;Password=your pass;TrustServerCertificate=True;"
  }
}

```

---

### 4️⃣ SQL Setup

---

### 5️⃣ Run the Project

## Note
Built using Ubuntu 22.04 LTS and Visual Studio Code with .NET SDK 8.  
Designed for scalable web development and cloud deployment on Microsoft Azure.  
Supports Azure App Service, Azure SQL, and modern CI/CD workflows.
---
## 📘 Screenshots
![image](https://github.com/user-attachments/assets/6e30c977-5938-48ce-b559-081256d7b463)
![image](https://github.com/user-attachments/assets/03d156c6-1b09-4d21-a9ad-49caf9681ea8)
![image](https://github.com/user-attachments/assets/a5a9a5c6-db9e-4883-b76c-c76c30ea86e3)

##for admin
![image](https://github.com/user-attachments/assets/ca78bf9e-3fc9-4b39-bbdc-5509f36b6b24)
![image](https://github.com/user-attachments/assets/f3e9fbae-6877-4692-9b6f-c9e72ea4877b)
![image](https://github.com/user-attachments/assets/a7b47884-abd2-4f21-8136-58c5208cff3d)
![image](https://github.com/user-attachments/assets/02102f83-9369-4c7b-a8ae-b8ebc0c90ec8)
![image](https://github.com/user-attachments/assets/3e14b0f2-d9de-462a-b728-f8d8bc982276)
![image](https://github.com/user-attachments/assets/f9d084c8-4cd1-48ca-bc9e-e9a9af971dc9)
![image](https://github.com/user-attachments/assets/1bac9226-1195-4743-8bc6-11350898602a)
![image](https://github.com/user-attachments/assets/0a51c453-fa09-4c4f-bbbd-0cc5b5f0524c)
![image](https://github.com/user-attachments/assets/286d66a4-288c-45d8-9e16-61ac5780bc55)

## for Accountant
![image](https://github.com/user-attachments/assets/e662c9f4-3f47-4a28-8d35-4ce563e1b447)
![image](https://github.com/user-attachments/assets/4c16fe17-8ff9-4ee7-ab41-446babe305e6)
![image](https://github.com/user-attachments/assets/eab8bbee-f929-4437-a896-087c6e9ef109)
![image](https://github.com/user-attachments/assets/c7f90384-973e-4332-980b-0ae4ba5d2dd5)
![image](https://github.com/user-attachments/assets/f29ece69-0004-48c7-ba7c-211a8fdad9f5)
![image](https://github.com/user-attachments/assets/e83638e2-32bd-4c47-a4f6-6d35556fa18e)
![image](https://github.com/user-attachments/assets/892cdd83-b786-4651-bb4b-bf43c8890b60)
![image](https://github.com/user-attachments/assets/40d7ad39-1efc-4847-981d-116f2631a4f4)

## for Viewer
![image](https://github.com/user-attachments/assets/3de27f71-f56d-4396-a494-803100baeab4)
![image](https://github.com/user-attachments/assets/17d3a5a7-a56e-4dd5-bfdf-f54d60c56a13)
![image](https://github.com/user-attachments/assets/ea626701-fc43-445a-81c1-f9ca6e1cf406)





## 📘 Stored Procedure & SQL

### SQL

```
CREATE TABLE [dbo].[ChartOfAccounts] (
    [AccountId]       INT             IDENTITY (1, 1) NOT NULL,
    [AccountName]     NVARCHAR (100)  NULL,
    [ParentAccountId] INT             NULL,
    [AccountBalance]  DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([AccountId] ASC)
);
CREATE TABLE [dbo].[AccountTypes] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Vouchers] (
    [VoucherId]   INT           IDENTITY (1, 1) NOT NULL,
    [VoucherType] NVARCHAR (50) NULL,
    [VoucherDate] DATE          NULL,
    [ReferenceNo] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([VoucherId] ASC)
);


CREATE TABLE [dbo].[VoucherEntries] (
    [VoucherEntryId] INT             IDENTITY (1, 1) NOT NULL,
    [VoucherId]      INT             NULL,
    [AccountId]      INT             NULL,
    [Debit]          DECIMAL (18, 2) NULL,
    [Credit]         DECIMAL (18, 2) NULL,
    PRIMARY KEY CLUSTERED ([VoucherEntryId] ASC),
    FOREIGN KEY ([VoucherId]) REFERENCES [dbo].[Vouchers] ([VoucherId])
);

CREATE TABLE [dbo].[RolePermissions] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [RoleId]     NVARCHAR (450) NULL,
    [ModuleName] NVARCHAR (100) NULL,
    [CanAccess]  BIT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id])
);
```
### sp_ManageChartOfAccounts

```
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

---
###sp_ManageRolePermissions
```

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
```

###
```
CREATE PROCEDURE [dbo].[sp_CreateVoucher]
    @VoucherType NVARCHAR(50),
    @VoucherDate DATE,
    @ReferenceNo NVARCHAR(50)
AS
BEGIN
    INSERT INTO Vouchers (VoucherType, VoucherDate, ReferenceNo)
    VALUES (@VoucherType, @VoucherDate, @ReferenceNo)
    
    SELECT SCOPE_IDENTITY() AS VoucherId, @VoucherType AS VoucherType, @VoucherDate AS VoucherDate, @ReferenceNo AS ReferenceNo
END
GO

CREATE PROCEDURE [dbo].[sp_AddVoucherEntry]
    @VoucherId INT,
    @AccountId INT,
    @Debit DECIMAL(18, 2),
    @Credit DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO VoucherEntries (VoucherId, AccountId, Debit, Credit)
    VALUES (@VoucherId, @AccountId, @Debit, @Credit)
END
GO

CREATE PROCEDURE [dbo].[sp_DeleteVoucher]
    @VoucherId INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM VoucherEntries WHERE VoucherId = @VoucherId;
    DELETE FROM Vouchers WHERE VoucherId = @VoucherId;
END;
GO
CREATE PROCEDURE [dbo].[sp_DeleteVoucherEntries]
    @VoucherId INT
AS
BEGIN
    DELETE FROM VoucherEntries
    WHERE VoucherId = @VoucherId
END
GO
CREATE PROCEDURE [dbo].[sp_GetVoucherBasicInfo]
    @VoucherId INT
AS
BEGIN
    SELECT 
        VoucherId, 
        VoucherType, 
        ReferenceNo 
    FROM Vouchers
    WHERE VoucherId = @VoucherId
END
GO
CREATE PROCEDURE [dbo].[sp_GetVoucherById]
    @VoucherId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Main voucher
    SELECT VoucherId, VoucherType, VoucherDate, ReferenceNo
    FROM Vouchers
    WHERE VoucherId = @VoucherId;

    -- Voucher entries
    SELECT VoucherEntryId, AccountId, Debit, Credit
    FROM VoucherEntries
    WHERE VoucherId = @VoucherId;
END;
GO

CREATE PROCEDURE [dbo].[sp_GetVoucherDetails]
    @VoucherId INT
AS
BEGIN
    -- First result set: Voucher details
    SELECT 
        VoucherId, 
        VoucherType, 
        VoucherDate, 
        ReferenceNo 
    FROM Vouchers 
    WHERE VoucherId = @VoucherId
    
    -- Second result set: Voucher entries
    SELECT 
        ve.VoucherEntryId,
        ve.AccountId,
        ve.Debit,
        ve.Credit,
        a.Name AS AccountName
    FROM VoucherEntries ve
    JOIN Accounts a ON ve.AccountId = a.Id
    WHERE ve.VoucherId = @VoucherId
END
GO

CREATE PROCEDURE [dbo].[sp_SaveVoucher]
    @VoucherId INT OUTPUT,
    @VoucherType NVARCHAR(50),
    @VoucherDate DATE,
    @ReferenceNo NVARCHAR(50),
    @Entries VoucherEntryType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    IF @VoucherId = 0
    BEGIN
        -- Insert new voucher
        INSERT INTO Vouchers (VoucherType, VoucherDate, ReferenceNo)
        VALUES (@VoucherType, @VoucherDate, @ReferenceNo);

        SET @VoucherId = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        -- Update existing voucher
        UPDATE Vouchers
        SET VoucherType = @VoucherType,
            VoucherDate = @VoucherDate,
            ReferenceNo = @ReferenceNo
        WHERE VoucherId = @VoucherId;

        -- Remove old entries
        DELETE FROM VoucherEntries WHERE VoucherId = @VoucherId;
    END

    -- Insert new entries
    INSERT INTO VoucherEntries (VoucherId, AccountId, Debit, Credit)
    SELECT @VoucherId, AccountId, Debit, Credit FROM @Entries;
END;
GO


```



## 🙋‍♂️ Author

**Shafiul Islam**
B.Sc in ICT – MBSTU

```
