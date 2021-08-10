USE [Altexsoft_Delivery]
GO

UPDATE [dbo].[Orders]
   SET [FullPrice] = FullPrice * 1.01
FROM Orders LEFT JOIN Clients ON Orders.ClientID = Clients.ClientID
WHERE CreditCardAttached = 1
GO


