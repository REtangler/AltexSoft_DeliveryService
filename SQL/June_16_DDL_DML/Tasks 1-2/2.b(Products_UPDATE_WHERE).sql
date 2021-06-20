USE [Altexsoft_Delivery]
GO

SELECT ProductID, Price FROM Products
UPDATE [dbo].[Products]
   SET [Price] = Price * 0.8
WHERE (ProductID % 2) = 0
GO


