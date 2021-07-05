USE [Northwind]
GO

SELECT [CategoryName]
	  ,MAX(UnitPrice) AS MaxPriceInCategory
	  ,Categories.CategoryID
	  ,Products.CategoryID
  FROM [dbo].[Categories], [dbo].[Products]
  GROUP BY CategoryName, Categories.CategoryID, Products.CategoryID
  HAVING Categories.CategoryID = Products.CategoryID
GO


