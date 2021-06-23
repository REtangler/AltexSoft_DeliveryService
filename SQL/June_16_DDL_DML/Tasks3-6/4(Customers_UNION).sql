USE [Northwind]
GO

SELECT DISTINCT [CustomerID]
      ,[CompanyName]
      ,[ContactName]
      ,[ContactTitle]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[Phone]
      ,[Fax]
  FROM [dbo].[Customers]
  WHERE Region = 'OR'
  UNION
  SELECT DISTINCT [CustomerID]
      ,[CompanyName]
      ,[ContactName]
      ,[ContactTitle]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostalCode]
      ,[Country]
      ,[Phone]
      ,[Fax]
  FROM [dbo].[Customers]
  WHERE City = 'Sao Paulo'
GO


