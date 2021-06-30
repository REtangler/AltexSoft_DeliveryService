USE [Altexsoft_Delivery]
GO

DECLARE @newID VARCHAR(56)

EXEC dbo.IDGenerator TestTable, @newID OUTPUT;

INSERT INTO [dbo].[TestTable]
           ([TestID]
           ,[Name]
           ,[Description])
     VALUES
           (@newID
           ,'test'
           ,'testdesc')
GO