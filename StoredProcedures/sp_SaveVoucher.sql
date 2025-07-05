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

