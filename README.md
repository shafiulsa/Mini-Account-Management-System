

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

| Stack | Description |
|-------|-------------|
| .NET 8 | ASP.NET Core Razor Pages |
| SQL Server | Database with stored procedures |
| Bootstrap 5 | UI styling |
| Identity | User + Role management |
| ClosedXML | Export Excel |
| jQuery | Dynamic form row handling |

---

## 🏗 Folder Structure

```

MiniAccountManagementSystem/
│               └── Microsoft.CodeAnalysis.Workspaces.resources.dll
├── Data
│   └── AppDbContext.cs
├── Migrations
│   ├── 20250703104524_projectSetup.cs
│   ├── 20250703104524_projectSetup.Designer.cs
│   ├── 20250704050506_InitialIdentitySchema.cs
│   ├── 20250704050506_InitialIdentitySchema.Designer.cs
│   └── AppDbContextModelSnapshot.cs
├── MiniAccountManagementSystem.csproj
├── Models
│   ├── Account.cs
│   ├── AccountTypes.cs
│   ├── RolePermission.cs
│   ├── Voucher.cs
│   └── VoucherEntry.cs
├── obj
│   ├── Debug
│   │   └── net8.0
│   │       ├── apphost
│   │       ├── MiniAcco.0D8DE692.Up2Date
│   │       ├── MiniAccountManagementSystem.AssemblyInfo.cs
│   │       ├── MiniAccountManagementSystem.AssemblyInfoInputs.cache
│   │       ├── MiniAccountManagementSystem.assets.cache
│   │       ├── MiniAccountManagementSystem.csproj.AssemblyReference.cache
│   │       ├── MiniAccountManagementSystem.csproj.CoreCompileInputs.cache
│   │       ├── MiniAccountManagementSystem.csproj.FileListAbsolute.txt
│   │       ├── MiniAccountManagementSystem.dll
│   │       ├── MiniAccountManagementSystem.GeneratedMSBuildEditorConfig.editorconfig
│   │       ├── MiniAccountManagementSystem.genruntimeconfig.cache
│   │       ├── MiniAccountManagementSystem.GlobalUsings.g.cs
│   │       ├── MiniAccountManagementSystem.MvcApplicationPartsAssemblyInfo.cache
│   │       ├── MiniAccountManagementSystem.pdb
│   │       ├── MiniAccountManagementSystem.RazorAssemblyInfo.cache
│   │       ├── MiniAccountManagementSystem.RazorAssemblyInfo.cs
│   │       ├── MiniAccountManagementSystem.sourcelink.json
│   │       ├── ref
│   │       │   └── MiniAccountManagementSystem.dll
│   │       ├── refint
│   │       │   └── MiniAccountManagementSystem.dll
│   │       ├── scopedcss
│   │       │   ├── bundle
│   │       │   │   └── MiniAccountManagementSystem.styles.css
│   │       │   ├── Pages
│   │       │   │   └── Shared
│   │       │   │       └── _Layout.cshtml.rz.scp.css
│   │       │   └── projectbundle
│   │       │       └── MiniAccountManagementSystem.bundle.scp.css
│   │       ├── staticwebassets
│   │       │   ├── msbuild.build.MiniAccountManagementSystem.props
│   │       │   ├── msbuild.buildMultiTargeting.MiniAccountManagementSystem.props
│   │       │   ├── msbuild.buildTransitive.MiniAccountManagementSystem.props
│   │       │   └── msbuild.MiniAccountManagementSystem.Microsoft.AspNetCore.StaticWebAssets.props
│   │       ├── staticwebassets.build.json
│   │       ├── staticwebassets.development.json
│   │       └── staticwebassets.pack.json
│   ├── MiniAccountManagementSystem.csproj.EntityFrameworkCore.targets
│   ├── MiniAccountManagementSystem.csproj.nuget.dgspec.json
│   ├── MiniAccountManagementSystem.csproj.nuget.g.props
│   ├── MiniAccountManagementSystem.csproj.nuget.g.targets
│   ├── project.assets.json
│   └── project.nuget.cache
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
├── Properties
│   └── launchSettings.json
├── README.md
├── Services
│   └── DatabaseService.cs
├── StoredProcedures
│   ├── CreateTables.sql
│   ├── sp_ManageChartOfAccounts.sql
│   ├── sp_ManageRolePermissions.sql
│   ├── sp_ManageUsers.sql
│   └── sp_SaveVoucher.sql
│
├── Pages/
│   ├── Account/              # Login/Register (Identity)
│   ├── ChartOfAccounts/      # COA CRUD and Tree display
│   ├── Vouchers/             # Create, Edit, Delete, View Vouchers
│   │   ├── Index.cshtml      # View all vouchers
│   │   ├── Create.cshtml     # Create voucher form
│   │   ├── Edit.cshtml       # Edit existing voucher
│   │   ├── Delete.cshtml     # Confirm and delete
│
├── Models/
│   ├── Account.cs            # Chart of account entity
│   ├── Voucher.cs            # Voucher + VoucherEntry models
│
├── Services/
│   └── DatabaseService.cs    # Executes SPs (Query/NonQuery)
│
├── Data/
│   └── AppDbContext.cs       # IdentityDbContext setup
│
├── wwwroot/                  # CSS, JS, lib folder
│
├── appsettings.json
├── Program.cs                # DI + Middleware + Seed Roles
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
    "DefaultConnection": "Server=localhost;Database=MiniAccountManagementSystem;User Id=sa;Password=shafiul*#5;TrustServerCertificate=True;"
  }
}

```

---

### 4️⃣ SQL Setup

* Execute SQL script to create:

  * Tables: `Vouchers`, `VoucherEntries`, `AspNetUsers`, etc.
  * TVP: `VoucherEntryType`
  * Stored Procedures: `sp_SaveVoucher`, `sp_GetVoucherById`, `sp_DeleteVoucher`, `sp_ManageChartOfAccounts`

---

### 5️⃣ Run the Project

```bash
dotnet watch run
```

* Navigate to: `https://localhost:5001`
* Login or register as new user.
* Admin assigns roles via DB manually or seed logic.

---
## 📘 Screenshots
![image](https://github.com/user-attachments/assets/6e30c977-5938-48ce-b559-081256d7b463)
![image](https://github.com/user-attachments/assets/03d156c6-1b09-4d21-a9ad-49caf9681ea8)
![image](https://github.com/user-attachments/assets/a5a9a5c6-db9e-4883-b76c-c76c30ea86e3)
![image](https://github.com/user-attachments/assets/ca78bf9e-3fc9-4b39-bbdc-5509f36b6b24)

## 📘 Stored Procedure Example

### `sp_SaveVoucher`

```sql
CREATE PROCEDURE sp_SaveVoucher
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
        INSERT INTO Vouchers (VoucherType, VoucherDate, ReferenceNo)
        VALUES (@VoucherType, @VoucherDate, @ReferenceNo);

        SET @VoucherId = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        DELETE FROM VoucherEntries WHERE VoucherId = @VoucherId;
        UPDATE Vouchers
        SET VoucherType = @VoucherType,
            VoucherDate = @VoucherDate,
            ReferenceNo = @ReferenceNo
        WHERE VoucherId = @VoucherId;
    END

    INSERT INTO VoucherEntries (VoucherId, AccountId, Debit, Credit)
    SELECT @VoucherId, AccountId, Debit, Credit FROM @Entries;
END
```

---

## 🔐 Default Roles

* Admin
* Accountant
* Viewer

> Seeded in `Program.cs`. Use role-based `[Authorize(Roles = "...")]` attributes on pages.

---

## 🧪 Sample Login (Optional Seeded)

| Username                              | Password    | Role       |
| ------------------------------------- | ----------- | ---------- |
| [admin@acc.com](mailto:admin@acc.com) | `Admin@123` | Admin      |
| [acc@acc.com](mailto:acc@acc.com)     | `Account@1` | Accountant |
| [view@acc.com](mailto:view@acc.com)   | `Viewer@1`  | Viewer     |

---

## 📦 License

MIT License

---

## 🙋‍♂️ Author

**Shafiul Islam**
B.Sc in ICT – MBSTU
Email: [shafiulislam.sa@gmail.com](mailto:shafiulislam.sa@gmail.com)
GitHub: [@shafiulmbstu](https://github.com/shafiulmbstu)

```

---

Let me know if you'd like me to also generate:

- `sp_ManageChartOfAccounts` SQL
- `sp_DeleteVoucher`
- Seed users with roles via code  
- Or convert this `README.md` into Bengali 🇧🇩 for local use.
```
