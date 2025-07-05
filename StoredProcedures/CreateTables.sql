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