USE [Altexsoft_Delivery]
GO

DECLARE @newID VARCHAR(56)

SELECT @newID = dbo.GenerateID('TestTable', NEWID())

INSERT INTO [dbo].[TestTable]
           ([TestID]
           ,[Name]
           ,[Description])
     VALUES
           (@newID
           ,'test'
           ,'testdesc')
GO