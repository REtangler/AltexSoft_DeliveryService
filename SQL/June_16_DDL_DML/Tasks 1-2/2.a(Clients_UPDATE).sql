USE [Altexsoft_Delivery]
GO

UPDATE [dbo].[Clients]
   SET [CreditCardAttached] = 0
 WHERE ClientID = 3
GO


