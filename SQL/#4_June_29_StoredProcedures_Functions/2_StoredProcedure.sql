SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE sp_IDGenerator (@tableName VARCHAR(20), @newID VARCHAR(56) OUTPUT)
AS
BEGIN
	DECLARE @GUID VARCHAR(36)
	SET @GUID = CAST(NEWID() AS VARCHAR(36))

	SELECT @newID = @tableName + @GUID
END
GO
